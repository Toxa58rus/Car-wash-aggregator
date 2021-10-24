import axios from "axios";
import { getRefreshUserFromCookie } from "./cookie";

const api = axios.create({
  baseURL: process.env.REACT_APP_BASE_URL,
  responseType: "json",
});

api.interceptors.request.use(
  (axiosConfig) => {
    const session = JSON.parse(window.sessionStorage.getItem("redux"));
    const user = session && session.session.data.token;
    const refresh = getRefreshUserFromCookie();
    console.log(axiosConfig);

    if (!user && !refresh) {
      return axiosConfig;
    }
    if (!user && refresh) {
      return {
        ...axiosConfig,
        url: "/register",
        headers: {
          ...axiosConfig.headers,
          Refresh: `${refresh}`,
        },
      };
    }

    return {
      ...axiosConfig,
      headers: {
        ...axiosConfig.headers,
        Auth: `${user}`,
      },
    };
  },
  (error) => Promise.reject(error)
);

export default api;
