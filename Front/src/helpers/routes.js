import { parse, stringify } from "query-string";

const routes = {
  root: "/",
  login: "/login",
  register: "/register",

  carWash: (id) => `/car-wash/${id}`,

  profileSettings: "/profile/settings",
  profileOrders: "/profile/orders",
  profileCarWashes: "/profile/car-washes",
};

export const getQuery = (route) => {
  const qs = route.split("?")[1];
  return qs ? parse(qs, { arrayFormat: "comma" }) : {};
};

export const replaceCurrentQuery = (history, { pathname, query }) => {
  history.replace({ pathname: pathname, search: stringify(query) });
};

export default routes;
