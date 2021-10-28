import React, { useEffect, useState } from "react";
import { Form, Field } from "react-final-form";
import { getDate } from "../../../helpers/dateFormatter";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import WASHES from "../../../constants/WASHES";
import api from "../../../lib/api";
import { useDispatch, useSelector } from "react-redux";
import sources from "../../../helpers/sources";
import { setSession, selectSession } from "../../../state/session";
import { selectConstants } from "../../../state/constants";
import get from "lodash/get";

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
import userEvent from "@testing-library/user-event";

const IndexPage = () => {
  const [calendarIsOpen, setCalendar] = useState(false);
  const [state, setState] = useState({
    washes: null,
    loading: true,
    sohouldUpdate: false,
  });
  const [initialValues, setValues] = useState({ date: getDate(new Date()) });
  const storage = JSON.parse(window.sessionStorage.getItem("redux"));
  const session = useSelector(selectSession);
  const constants = useSelector(selectConstants);
  const cities = !constants ? null : constants.cities;
  const cars = !constants ? null : constants.cars;

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
    console.log(date);
  };

  const getData = (data) => {
    setState((prevState) => ({
      ...prevState,
      sohouldUpdate: true,
    }));
    dispatch(
      setSession({
        ...get(session, "data"),
        date: data.date && data.date,
        time: data.time && data.time,
      })
    );

    api
      .get(sources.search, {
        params: {
          ...data,
          date: data.date ? data.date : getDate(new Date()),
          city: !data.city ? "Moscow" : data.city.name,
        },
      })
      .then((response) => {
        setState({ washes: WASHES });
      });

    setState({ washes: WASHES, loading: false, sohouldUpdate: false });
  };

  console.log(storage);

  useEffect(() => {
    if (state.loading && get(storage, "session")) {
      getData({});
      setValues((prevState) => ({
        ...prevState,
        city: session && session.sity ? session.city : null,
      }));
    }
  }, [storage]);

  return (
    <div className={styles.page} onClick={handleCloseCalendar}>
      <Header />
      <div className={styles.washSearch}>
        <div className={styles.searchUpperBlock}>
          <h2>Поиск моек</h2>
          <div className={styles.inner}>
            <div className={styles.citySelect}>
              <img src={MapMark} alt="MapMark" />
              <Select
                placeholder="Город"
                defaultValue={
                  cities &&
                  cities.reduce((city) => city.name === userEvent.city)
                }
                transparent
                options={cities}
              />
            </div>
          </div>
        </div>
        <Form
          onSubmit={getData}
          initialValues={initialValues}
          render={({ handleSubmit, form }) => {
            currentForm = form;
            return (
              <form onSubmit={handleSubmit}>
                <div className={styles.searchBlock}>
                  <span className={styles.blockStr}>
                    Воспользуйтесь поиском
                  </span>
                  <div className={styles.innerBlock}>
                    <Field
                      name="text"
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
                      <Select placeholder="Город" options={cities} />
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
                            options={cars}
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
        <h2 className={styles.cityWashes}>Мойки в Москве</h2>
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
