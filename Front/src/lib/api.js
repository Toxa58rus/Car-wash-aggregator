import axios from "axios";
import { getRefreshUserFromCookie, setUserCookie } from "./cookie";
import get from "lodash/get";
import routes from "../helpers/routes";
import { getAccess, refreshRequest } from "../helpers/request";
import sources from "../helpers/sources";

const api = axios.create({
  baseURL: process.env.REACT_APP_BASE_URL,
  responseType: "json",
});

api.interceptors.request.use(
  (axiosConfig) => {
    const refresh = getRefreshUserFromCookie();
    const storage = JSON.parse(window.sessionStorage.getItem("redux"));
    const access =
      storage && storage.session.data
        ? get(storage, "session.data.token")
        : null;

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
    if (
      response.data.accessToken &&
      response.data.refreshToken &&
      response.config.url !== sources.login &&
      response.config.url !== sources.register
    ) {
      return refreshRequest(response, response.config);
    }
    return response;
  },
  (error) => {
    const refresh = getRefreshUserFromCookie();

    if (get(error, "response.data.message") === "refresh_token_not_valid") {
      setUserCookie("not_valid");
      window.location.replace(routes.root);
    }

    if (
      get(error, "response.data.message") === "access_token_life_time_expired"
    ) {
      return getAccess(error.config, refresh);
    }

    return Promise.reject(error);
  }
);

export default api;
