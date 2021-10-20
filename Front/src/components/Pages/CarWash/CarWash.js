import React, { useEffect, useState } from "react";
import { Form, Field } from "react-final-form";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import { useSelector } from "react-redux";
import { selectSession } from "../../../state/session";
import { ROLES } from "../../../constants/ROLES";
import { getDate } from "../../../helpers/dateFormatter";
import {
  required,
  mustBeNumber,
  composeValidators,
} from "../../../helpers/validations";

import Button from "../../Button/Button";
import Header from "../../Header/Header";
import Input from "../../Input/Input";
import DateForm from "../../DateForm/DateForm";
import Select from "../../Select/Select";
import Spinner from "../../Spinner/Spinner";
import CommentCard from "../../CommentCard/CommentCard";
import Tabs from "../../Tabs/Tabs";
import OrderCard from "../../OrderCard/OrderCard";
import styles from "./CarWash.module.scss";

import locationIcon from "../../../icons/location.svg";
import timeIcon from "../../../icons/time.svg";
import phoneIcon from "../../../icons/phone.svg";

const CarWash = () => {
  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    updateTimeFields: true,
    sendOrder: false,
    comments: [1, 2, 3],
    data: null,
    orders: [13, 23, 33],
  });
  let currentForm = null;

  const session = useSelector(selectSession);
  const role = session && session.role;

  const requestTimeFields = async () => {
    setState((prevState) => ({
      ...prevState,
      updateTimeFields: false,
      sendOrder: false,
    }));
  };

  useEffect(() => {
    if (state.updateTimeFields) {
      setTimeout(() => requestTimeFields(), 2000);
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
          {role !== ROLES.PARTNER && (
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
          )}
          {role !== ROLES.PARTNER && state.comments && (
            <div className={styles.section}>
              {state.comments.map((item) => (
                <CommentCard key={item} />
              ))}
            </div>
          )}
          {role === ROLES.PARTNER && (
            <div className={styles.section}>
              <Tabs>
                <div label="История бронирования">
                  {state.orders.map((item) => (
                    <OrderCard key={item} />
                  ))}
                </div>
                <div label="Коментарии">
                  {state.comments.map((item) => (
                    <CommentCard key={item} />
                  ))}
                </div>
              </Tabs>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default CarWash;
