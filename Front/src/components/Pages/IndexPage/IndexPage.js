import React, { useEffect, useState } from "react";
import { Form, Field } from "react-final-form";
import { getDate } from "../../../helpers/dateFormatter";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import api from "../../../lib/api";
import { useDispatch, useSelector } from "react-redux";
import sources from "../../../helpers/sources";
import { setSession, selectSession } from "../../../state/session";
import { selectConstants } from "../../../state/constants";
import get from "lodash/get";
import { toast } from "react-toastify";

import MapMark from "../../../icons/Vector.svg";
import Clock from "../../../icons/Clock.svg";

import Spinner from "../../Spinner/Spinner";
import WashCard from "../../WashCard/WashCard";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import DateForm from "../../DateForm/DateForm";
import Header from "../../Header/Header";
import Select from "../../Select/Select";
import styles from "./IndexPage.module.scss";
import { setDate } from "../../../state/date";
import { CATEGORIES_OPTIONS } from "../../../constants/CAR-CATEGORIES";

const IndexPage = () => {
  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    washes: null,
    loading: true,
    sohouldUpdate: false,
    serch: false,
  });
  const [initialValues, setValues] = useState({ date: getDate(new Date()) });
  const storage = JSON.parse(window.sessionStorage.getItem("redux"));
  const session = useSelector(selectSession);
  const constants = useSelector(selectConstants);
  const cities = !constants ? null : constants.cities;

  const dispatch = useDispatch();

  let currentForm = null;
  const handleOpenCalendar = (event) => {
    event.stopPropagation();
    setCalendar(true);
  };
  const handleCloseCalendar = () => {
    setCalendar(false);
  };
  const setValue = (date) => {
    currentForm.change("date", date);
    setCalendar(false);
  };

  const getData = (data) => {
    setState((prevState) => ({
      ...prevState,
      loading: false,
      sohouldUpdate: true,
    }));
    dispatch(
      setDate({
        date: data.date && data.date,
        time: data.time && data.time.name,
        carCategory: data.carCategory && data.carCategory.id,
      })
    );

    api
      .get(sources.search, {
        params: {
          ...data,
          cityId: data.cityId && data.cityId.id,
          carCategory: data.carCategory && data.carCategory.id,
          time: data.time && data.time.name,
          date: !data.time ? null : data.time,
        },
      })
      .then((response) => {
        setState((prevState) => ({
          ...prevState,
          washes: response.data.carWashes,
          sohouldUpdate: false,
          loading: false,
          serch: true,
        }));

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch((err) => !err.status === 401 && toast.error("Error"));
  };

  useEffect(() => {
    if (state.loading && get(storage, "session.data")) {
      getData({
        cityId: constants.cities.reduce((i) => session.city === i.name),
      });

      setValues((prevState) => ({
        ...prevState,
        cityId: constants.cities.reduce((i) => session.city === i.name),
      }));
    }

    if (state.loading && !get(storage, "session.data")) {
      getData({});
    }
  }, [storage]);

  return (
    <div className={styles.page} onClick={handleCloseCalendar}>
      <Header />
      <div className={styles.washSearch}>
        <div className={styles.searchUpperBlock}>
          <h2>Поиск моек</h2>
        </div>
        <Form
          onSubmit={getData}
          initialValues={initialValues}
          render={({ handleSubmit, form, values }) => {
            currentForm = form;
            return (
              <form onSubmit={handleSubmit}>
                <div className={styles.searchBlock}>
                  <span className={styles.blockStr}>
                    Воспользуйтесь поиском
                  </span>
                  <div className={styles.innerBlock}>
                    <Field
                      name="carWashName"
                      render={({ input, meta }) => (
                        <Input
                          placeholder="Поиск по названию мойки"
                          meta={meta}
                          {...input}
                        />
                      )}
                    />
                  </div>
                  <div className={styles.nearestWash}>
                    <div className={styles.citySelect}>
                      <img src={MapMark} alt="MapMark" />
                      <Field
                        name="cityId"
                        render={({ input, meta }) => (
                          <Select
                            placeholder="Город"
                            options={cities}
                            meta={meta}
                            {...input}
                          />
                        )}
                      />
                    </div>
                  </div>
                </div>
                <div className={styles.searchBlock}>
                  <span className={styles.blockStr}>
                    Выберите конкретную дату и время
                  </span>
                  <div className={styles.innerBlock}>
                    <div className={styles.field} onClick={handleOpenCalendar}>
                      <Field name="date">
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
                    <div className={styles.field}>
                      <img src={Clock} alt="time" />
                      <Field
                        name="time"
                        render={({ input, meta }) => (
                          <Select
                            placeholder="Время"
                            options={TIME_FIELDS}
                            meta={meta}
                            disabled={!values.date}
                            {...input}
                          />
                        )}
                      />
                    </div>
                    <div className={styles.field}>
                      <Field
                        name="carCategory"
                        render={({ input, meta }) => (
                          <Select
                            placeholder="Автомобиль"
                            options={CATEGORIES_OPTIONS}
                            meta={meta}
                            {...input}
                          />
                        )}
                      />
                    </div>
                  </div>
                  <Button
                    type="submit"
                    className={styles.innerBlockButton}
                    increased
                  >
                    Подобрать мойку
                  </Button>
                </div>
              </form>
            );
          }}
        />
      </div>
      <div className={styles.section}>
        <h2 className={styles.cityWashes}>Мойки</h2>
        <div className={styles.washList}>
          {!state.washes || state.loading || state.sohouldUpdate ? (
            <Spinner center />
          ) : (
            state.washes.map((item) => (
              <div className={styles.card} key={item.id}>
                <WashCard id={item.id} item={item} />
              </div>
            ))
          )}
        </div>
      </div>
    </div>
  );
};

export default IndexPage;
