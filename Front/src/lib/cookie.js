import cookies from "js-cookie";

export const getRefreshUserFromCookie = () => {
  const cookie = cookies.get("refresh");

  if (!cookie) {
    return null;
  }
  return cookie;
};

export const setUserCookie = (refreshUser) => {
  cookies.set("refresh", refreshUser, { expires: 365 });
};

export const removeUserCookie = () => {
  cookies.remove("refresh");
};
