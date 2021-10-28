import axios from "axios";
import get from "lodash/get";
import { removeUserCookie, setUserCookie } from "../lib/cookie";
import routes from "./routes";

export const refreshRequest = async (response, config) => {
  let updatedData = null;
  await axios({
    ...config,
    headers: {
      ...config.headers,
      Authorization: `JwtAccessToken ${response.data.accessToken}`,
    },
  })
    .then((refreshResponse) => {
      updatedData = {
        data: {
          ...refreshResponse.data,
        },
        user: {
          ...response.data.user,
          token: response.data.accessToken,
        },
      };
    })
    .catch((error) => error);
  return updatedData;
};

export const getAccess = async (config, refresh) => {
  return await axios({
    ...config,
    headers: {
      ...config.headers,
      Authorization: `JwtRefreshToken ${refresh}`,
    },
  })
    .then(async (accessResponse) => {
      setUserCookie(accessResponse.data.refreshToken);
      return refreshRequest(accessResponse, config);
    })
    .catch((error) => {
      if (get(error, "response.data.message") === "refresh_token_not_valid") {
        // removeUserCookie();
        // window.location.replace(routes.root);
      }
    });
};
