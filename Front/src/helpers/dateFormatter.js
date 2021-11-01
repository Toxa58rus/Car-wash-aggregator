import format from "date-fns/format";

export const getDate = (date) => format(date, "yyyy-MM-dd");

export const getTime = (date) => format(date, "HH:mm");

export const formattDataTime = (date) => {
  const arr = date.split(`T`);
  return arr.join(" ");
};

export const getMilliseconds = (time) => {
  let split = time.split(":");
  return split[0] * 60000 + split[1] * 1000;
};
