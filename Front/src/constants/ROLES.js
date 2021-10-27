export const ROLES = {
  CLIENT: "0",
  PARTNER: "1",
};

export const ROLES_NAMES = {
  [ROLES.CLIENT]: "Клиент",
  [ROLES.PARTNER]: "Партнер",
};

export const ROLES_OPTIONS = [
  { id: ROLES.CLIENT, name: ROLES_NAMES[ROLES.CLIENT] },
  { id: ROLES.PARTNER, name: ROLES_NAMES[ROLES.PARTNER] },
];
