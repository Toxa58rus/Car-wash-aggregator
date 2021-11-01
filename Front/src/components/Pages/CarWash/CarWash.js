import React, { useEffect, useState } from "react";
import { Form, Field } from "react-final-form";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import { useDispatch, useSelector } from "react-redux";
import { selectSession, setSession } from "../../../state/session";
import { ROLES } from "../../../constants/ROLES";
import { toast } from "react-toastify";
import {
  getDate,
  getMilliseconds,
  getTime,
} from "../../../helpers/dateFormatter";
import { required } from "../../../helpers/validations";
import api from "../../../lib/api";
import sources from "../../../helpers/sources";
import { selectConstants } from "../../../state/constants";
import { STATUSES } from "../../../constants/STATUSES";
import { selectDate } from "../../../state/date";
import { CATEGORIES_OPTIONS } from "../../../constants/CAR-CATEGORIES";
import routes from "../../../helpers/routes";

import Button from "../../Button/Button";
import Header from "../../Header/Header";
import DateForm from "../../DateForm/DateForm";
import Select from "../../Select/Select";
import Spinner from "../../Spinner/Spinner";
import CommentCard from "../../CommentCard/CommentCard";
import Tabs from "../../Tabs/Tabs";
import OrderCard from "../../OrderCard/OrderCard";
import styles from "./CarWash.module.scss";

import locationIcon from "../../../icons/location.svg";
import timeIcon from "../../../icons/time.svg";

const CarWash = ({ history, match }) => {
  const searchVal = useSelector(selectDate);
  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    updateTimeFields: true,
    sendOrder: false,
    isLoading: true,
    comments: null,
    data: null,
    orders: [],
    timeField: TIME_FIELDS,
  });
  let currentForm = null;
  let filtredArr = [];
  const session = useSelector(selectSession);
  const role = session && session.role;
  const constants = useSelector(selectConstants);

  const dispatch = useDispatch();

  const getOrders = (date) => {
    api
      .get(sources.carWashTimeStatuses(match.params.id), {
        params: {
          filterDate: date,
        },
      })
      .then((response) => {
        filterTimeFields(response.data.orders, date);

        const value = response.data.orders;
        const reverseArr = value.reverse();

        setState((prevState) => ({
          ...prevState,
          orders: reverseArr,
          updateTimeFields: false,
          timeField: filtredArr,
        }));

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch(() => toast.error("Error orders"));
  };

  const filterTimeFields = (orders, date) => {
    TIME_FIELDS.forEach((timeField) => {
      let obj = timeField;
      let nowTime = getTime(new Date());

      if (orders) {
        orders.map((order) => {
          let formatTime = order.dateReservation.split("T");
          if (
            formatTime[1] === timeField.id &&
            order.status === STATUSES.BOOKED
          ) {
            obj.status = STATUSES.BOOKED;
          }
          return order;
        });
      }
      if (
        getDate(new Date()) === date &&
        getMilliseconds(nowTime) > getMilliseconds(timeField.name)
      ) {
      } else {
        filtredArr.push(obj);
      }
      return obj;
    });
    return filtredArr;
  };

  const getComments = () => {
    api
      .get(sources.comments(match.params.id))
      .then((response) => {
        const value = response.data.reviews;
        const reverseArr = value.reverse();
        setState((prevState) => ({
          ...prevState,
          comments: reverseArr,
        }));

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch(() => toast.error("Error comment"));
  };

  const getWash = () => {
    api
      .get(sources.carWash(match.params.id))
      .then((response) => {
        setState((prevState) => ({
          ...prevState,
          data: { ...response.data, washId: response.data.id },
          isLoading: false,
        }));

        if (response.user) {
          dispatch(setSession(response.user));
        }

        if (role === ROLES.CLIENT) {
          getOrders(getDate(new Date()));
        }
        if (role === ROLES.PARTNER) {
          getOrders();
        }
        getComments();
      })
      .catch((err) => !err.status === 401 && toast.error("Error"));
  };

  useEffect(() => {
    if (state.isLoading) {
      getWash();
    }
    if (!session || !session.token) {
      history.push(routes.login);
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
    api
      .post(sources.orederCreate, {
        userId: session.id,
        carWashId: match.params.id,
        carCategory: values.carCategory.name,
        dateReservation: `${values.date} ${values.time.name}`,
        price: "100",
        status: STATUSES.BOOKED,
      })
      .then(() => {
        toast.success("Слот забронирован");
      })
      .catch(() => toast.error("Erorr"));
  };

  const handleChangeDate = (date) => {
    currentForm.change("date", date);
    setCalendar(false);
    setState((prevState) => ({
      ...prevState,
      updateTimeFields: true,
    }));

    getOrders(date);
  };

  const initialValues = {
    date: searchVal.date || getDate(new Date()),
    time:
      searchVal.time && filtredArr.find((item) => searchVal.time === item.name),
  };

  const washCity =
    state.data &&
    constants.cities.find((item) => item.id === state.data.cityId);

  return (
    <div className={styles.page} onClick={handleCloseCalendar}>
      <Header />
      {state.isLoading ? (
        <Spinner center />
      ) : (
        <div className={styles.wrap}>
          <h2 className={styles.tittlePage}>Бронирование автомойки</h2>
          <div className={styles.inner}>
            {state.data && state.data.img && (
              <img
                className={styles.carWashIMG}
                src={state.data.img}
                alt="car wash IMG"
              />
            )}
            <h2 className={styles.carWashTitle}>{state.data.name}</h2>
            <div className={styles.description}>{state.data.description}</div>
            <div className={styles.address}>
              <img src={locationIcon} alt="address" />
              {washCity.name}, {state.data.address}
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
                                  setValue={handleChangeDate}
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
                                      options={state.timeField}
                                      meta={meta}
                                      {...input}
                                    />
                                  )}
                                />
                              </>
                            )}
                          </div>
                          <div className={styles.formInner}>
                            <Field
                              name="carCategory"
                              validate={required}
                              render={({ input, meta }) => (
                                <Select
                                  placeholder="Car category *"
                                  options={CATEGORIES_OPTIONS}
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
                  <CommentCard key={item.id} comment={item} />
                ))}
              </div>
            )}
            {role === ROLES.PARTNER && (
              <div className={styles.section}>
                <Tabs>
                  <div
                    label="История бронирования"
                    className={styles.tabSection}
                  >
                    {state.orders &&
                      state.orders.map((item) => (
                        <OrderCard key={item} item={item} />
                      ))}
                  </div>
                  <div label="Коментарии" className={styles.tabSection}>
                    {state.comments &&
                      state.comments.map((item) => (
                        <CommentCard key={item.id} comment={item} />
                      ))}
                  </div>
                </Tabs>
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
};

export default CarWash;
