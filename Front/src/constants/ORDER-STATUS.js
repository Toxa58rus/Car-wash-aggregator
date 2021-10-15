export const ORDERS_STATUS = {
  BOOKED: 1,
  FREE: 2,
  CANCELED: 3,
  FINISHED: 4,
};

export const ORDERS_STATUS_NAMES = {
  [ORDERS_STATUS.BOOKED]: "Забронировано вами",
  [ORDERS_STATUS.FREE]: "Свободно",
  [ORDERS_STATUS.CANCELED]: "Отменено",
  [ORDERS_STATUS.FINISHED]: "Завершен",
};
