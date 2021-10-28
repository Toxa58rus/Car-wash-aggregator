import { trim } from "lodash";

/* eslint-disable */
const validEmailRegExp = new RegExp(
  /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
);
/* eslint-enable */

const required = (value) => (trim(value) ? undefined : "Обязательное поле");
const requiredWithMessage = (message) => (value) => value ? undefined : message;
const minValue = (min) => (value) =>
  value.length >= min ? undefined : `Меньше ${min} сиволов`;
const maxValue = (max) => (value) =>
  (value ? value.length : 0) <= max ? undefined : `Больше ${max} символов`;
const mustBeNumber = (value) =>
  value && Number.isNaN(Number(value))
    ? "В это поле вводятся числа"
    : undefined;
const composeValidators =
  (...validators) =>
  (value, formValues, meta) =>
    validators.reduce(
      (error, validator) => error || validator(value, formValues, meta),
      undefined
    );

const validEmail = (value) => {
  if (!value) return undefined;

  return validEmailRegExp.test(value) ? undefined : " Не корректный E-mail";
};

export {
  required,
  requiredWithMessage,
  minValue,
  maxValue,
  mustBeNumber,
  composeValidators,
  validEmail,
};
