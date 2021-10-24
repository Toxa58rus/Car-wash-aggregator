import axios from "axios";
import { getRefreshUserFromCookie, setUserCookie } from "./cookie";
import get from "lodash/get";
import { useDispatch } from "react-redux";
import { setSession } from "../state/session";

const api = axios.create({
  baseURL: process.env.REACT_APP_BASE_URL,
  responseType: "json",
});

let config = null;
const storage = JSON.parse(window.sessionStorage.getItem("redux"));
const access = storage && get(storage, "session.data.token");
const refresh = getRefreshUserFromCookie();

api.interceptors.request.use(
  (axiosConfig) => {
    config = axiosConfig;

    if (!access && !refresh) {
      return axiosConfig;
    }
    if (!access && refresh) {
      return {
        ...axiosConfig,
        headers: {
          ...axiosConfig.headers,
          Authorization: `JwtRefreshToken ${refresh}`,
        },
      };
    }

    return {
      ...axiosConfig,
      headers: {
        ...axiosConfig.headers,
        Authorization: `JwtAccessToken ${access}`,
      },
    };
  },
  (error) => Promise.reject(error)
);

api.interceptors.response.use(
  (response) => {
    if (response.accessToken && response.refreshToken) {
      useDispatch(
        setSession({ ...response.user, token: response.accessToken })
      );
      setUserCookie(response.refreshToken);
      console.log("kshjdbgiwsbdgisjdbgkisjdbvkisjdvnbgkisjdnksdjb");
    }
  },
  (error) => {
    if (error.response.data.message === "access_token_life_time_expired") {
      console.log(error.response);
      console.log(config);
      axios({
        ...config,
        headers: {
          ...config.headers,
          Authorization: `JwtRefreshToken ${refresh}`,
        },
      });
    }
  }
);

export default api;
