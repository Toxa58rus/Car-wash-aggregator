import React, { useEffect, useState } from "react";
import { Form, Field } from "react-final-form";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import {
  required,
  mustBeNumber,
  composeValidators,
} from "../../../helpers/validations";
import { getDate } from "../../../helpers/dateFormatter";

import Button from "../../Button/Button";
import Header from "../../Header/Header";
import Input from "../../Input/Input";
import DateForm from "../../DateForm/DateForm";
import Select from "../../Select/Select";
import Spinner from "../../Spinner/Spinner";
import styles from "./CarWash.module.scss";

import locationIcon from "../../../icons/location.svg";
import timeIcon from "../../../icons/time.svg";
import phoneIcon from "../../../icons/phone.svg";

const CarWash = () => {
  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    updateTimeFields: true,
    sendOrder: false,
  });
  let currentForm = null;

  const requestTimeFields = async () => {
    setTimeout(() => {
      setState({
        updateTimeFields: false,
        sendOrder: false,
      });
    }, 2000);
  };

  useEffect(() => {
    if (state.updateTimeFields) {
      requestTimeFields();
    }
  });

  const handleOpenCalendar = (event) => {
    event.stopPropagation();
    setCalendar(true);
  };
  const handleCloseCalendar = () => {
    setCalendar(false);
  };

  const createOrder = (values) => {
    setState({
      updateTimeFields: false,
      sendOrder: true,
    });
    setTimeout(() => {
      setState({
        updateTimeFields: false,
        sendOrder: false,
      });
    }, 2000);
  };

  const setValue = (date) => {
    currentForm.change("date", date);
    setCalendar(false);
    setState({
      updateTimeFields: true,
      sendOrder: false,
    });
  };

  const initialValues = { date: getDate(new Date()) };
  return (
    <div className={styles.page} onClick={handleCloseCalendar}>
      <Header />
      <div className={styles.wrap}>
        <h2 className={styles.tittlePage}>Бронирование автомойки</h2>
        <div className={styles.inner}>
          <img className={styles.carWashIMG} alt="car wash IMG" />
          <h2 className={styles.carWashTitle}>Апельсин</h2>
          <div className={styles.description}>
            Автомойка Апельсин предоставляет широкий спектор услуг по уборке
            вашего автомобиля. Действуют скидки. ПРИЕЗЖАЙТЕ К НАМ
          </div>
          <div className={styles.address}>
            <img src={locationIcon} alt="address" />
            Димитровград, Октябрьская улица, 21Б
          </div>
          <Form
            onSubmit={createOrder}
            initialValues={initialValues}
            render={({ handleSubmit, form }) => {
              currentForm = form;
              return (
                <form onSubmit={handleSubmit} className={styles.form}>
                  {state.sendOrder ? (
                    <Spinner size={4} center />
                  ) : (
                    <>
                      <div
                        className={styles.formInner}
                        onClick={handleOpenCalendar}
                      >
                        <Field name="date" validate={required}>
                          {({ input, meta }) => (
                            <DateForm
                              calendarIsOpen={calendarIsOpen}
                              setValue={setValue}
                              meta={meta}
                              {...input}
                            />
                          )}
                        </Field>
                      </div>

                      <div className={styles.formInner}>
                        {state.updateTimeFields ? (
                          <Spinner size={2} center />
                        ) : (
                          <>
                            <img src={timeIcon} alt="calendar" />
                            <Field
                              name="time"
                              validate={required}
                              render={({ input, meta }) => (
                                <Select
                                  placeholder="Время *"
                                  options={TIME_FIELDS}
                                  meta={meta}
                                  {...input}
                                />
                              )}
                            />
                          </>
                        )}
                      </div>
                      <div className={styles.formInner}>
                        <img src={phoneIcon} alt="phone" />
                        <Field
                          name="phone"
                          validate={composeValidators(required, mustBeNumber)}
                          render={({ input, meta }) => (
                            <Input
                              className={styles.input}
                              placeholder="Телефон *"
                              meta={meta}
                              {...input}
                            />
                          )}
                        />
                      </div>
                      <Button
                        className={styles.submit}
                        size="maxWidth"
                        type="submit"
                      >
                        Забронировать
                      </Button>
                    </>
                  )}
                </form>
              );
            }}
          />
        </div>
      </div>
    </div>
  );
};

export default CarWash;
