const sources = {
  register: "/register",
  login: "/login",

  constants: "/constants",
  search: "/car-wash/Search",

  profileSettings: "/user/settings",
  profileOrders: "/profile/orders",
  profileCarWashes: "/profile/car-washes",

  orederCreate: "/orders/add",
  orders: (UserId) => `/orders/getByUserId/${UserId}`,
  orderStatuses: `/orders/statuses`,

  carWashAdd: "/car-wash/add",
  carWashList: (id) => `/car-wash/getByUserId/${id}`,
  carWash: (id) => `/car-wash/getById/${id}`,
  carWashTimeStatuses: (CarWashId) => `/orders/getByCarWashId/${CarWashId}`,

  comments: (id) => `/reviews/getByCarWashId/${id}`,
  getReview: "/reviews/add",
  users: (id) => `/user/getById/${id}`,
};

export default sources;
