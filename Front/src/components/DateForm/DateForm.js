import React, { useState } from "react";
import PropTypes from "prop-types";
import ReactCalendar from "react-calendar";
import cn from "classnames";
import "react-calendar/dist/Calendar.css";
import { getDate } from "../../helpers/dateFormatter";

import styles from "./DateForm.module.scss";

import calendarIcon from "../../icons/calendar.svg";

const DateForm = (props) => {
  const { calendarIsOpen, setValue, meta, value, ...rest } = props;
  const [date, setDate] = useState();

  const handleChange = (data) => {
    setDate(data);
    setValue(getDate(data));
  };

  const calendarCn = cn(styles.calendar, {
    [styles.active]: Boolean(calendarIsOpen),
  });

  const inputCn = cn(styles.input, {
    [styles.error]: meta && (meta.error || meta.submitError) && meta.touched,
  });

  return (
    <div className={styles.container}>
      <img src={calendarIcon} alt="calendar" />
      {meta && (meta.error || meta.submitError) && meta.touched && (
        <div className={styles.errorText}>{meta.error}</div>
      )}
      <input className={inputCn} value={value} {...rest} readOnly />
      <div className={calendarCn}>
        <ReactCalendar
          value={date}
          minDate={new Date()}
          onChange={handleChange}
        />
      </div>
    </div>
  );
};

DateForm.defaultProps = {
  meta: null,
};

DateForm.propTypes = {
  meta: PropTypes.oneOfType([PropTypes.object, PropTypes.bool]),
  setValue: PropTypes.func.isRequired,
  calendarIsOpen: PropTypes.bool.isRequired,
  value: PropTypes.string.isRequired,
};

export default DateForm;
