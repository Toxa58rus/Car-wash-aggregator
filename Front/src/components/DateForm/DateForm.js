import React, { useState } from "react";
import PropTypes from "prop-types";
import ReactCalendar from "react-calendar";
import cn from "classnames";
import "react-calendar/dist/Calendar.css";
import { getDate } from "../../helpers/dateFormatter";

import Input from "../Input/Input";
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

  return (
    <div className={styles.container}>
      <img src={calendarIcon} alt="calendar" />
      <Input
        value={value}
        placeholder="Дата *"
        meta={meta}
        {...rest}
        readOnly
      />
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
