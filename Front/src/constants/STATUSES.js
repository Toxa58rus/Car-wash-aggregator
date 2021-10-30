export const STATUSES = {
  All: "All",
  BOOKED: "Booked",
  CANCELED: "Cancelled",
  COMPLETED: "Completed",
};

export const STATUSES_NAMES = {
  [STATUSES.All]: "Все",
  [STATUSES.BOOKED]: "Забронировано",
  [STATUSES.CANCELED]: "Отменено",
  [STATUSES.COMPLETED]: "Завершено",
};

export const STATUSES_OPTIONS = [
  { id: STATUSES.All, name: STATUSES_NAMES[STATUSES.All] },
  { id: STATUSES.BOOKED, name: STATUSES_NAMES[STATUSES.BOOKED] },
  { id: STATUSES.CANCELED, name: STATUSES_NAMES[STATUSES.CANCELED] },
  { id: STATUSES.COMPLETED, name: STATUSES_NAMES[STATUSES.COMPLETED] },
];
