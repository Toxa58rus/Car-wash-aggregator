export const ORDERS_STATUS = {
  ALL: 1,
  BOOKED: 2,
  CANCELED: 3,
  FINISHED: 4,
};

export const ORDERS_STATUS_NAMES = {
  [ORDERS_STATUS.ALL]: "Все",
  [ORDERS_STATUS.BOOKED]: "Забронировано",
  [ORDERS_STATUS.CANCELED]: "Отменено",
  [ORDERS_STATUS.FINISHED]: "Завершен",
};

export const ORDER_STATUS_ARRAY = [
  { id: ORDERS_STATUS.ALL, name: "Все" },
  { id: ORDERS_STATUS.BOOKED, name: "Забронировано" },
  { id: ORDERS_STATUS.CANCELED, name: "Отменено" },
  { id: ORDERS_STATUS.FINISHED, name: "Завершен" },
];
