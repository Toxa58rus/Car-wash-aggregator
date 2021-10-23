import React, { useState } from "react";
import { Form, Field } from "react-final-form";
import { getDate } from "../../../helpers/dateFormatter";
import { TIME_FIELDS } from "../../../constants/TIME-FIELDS";
import WASHES from "../../../constants/WASHES";

import MapMark from "../../../icons/Vector.svg";
import Clock from "../../../icons/Clock.svg";

import WashCard from "../../WashCard/WashCard";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import DateForm from "../../DateForm/DateForm";
import Header from "../../Header/Header";
import Select from "../../Select/Select";
import styles from "./IndexPage.module.scss";

const IndexPage = () => {
  const [calendarIsOpen, setCalendar] = useState(false);

  const getData = async (data) => {
    // api.get(sources.search, { params: {...data}}).then((response) => setState({washes: response.data}))
  };

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

  const initialValues = { date: getDate(new Date()) };
  return (
    <div className={styles.page} onClick={handleCloseCalendar}>
      <Header />
      <div className={styles.washSearch}>
        <div className={styles.searchUpperBlock}>
          <h2>Поиск моек</h2>
          <div className={styles.inner}>
            <div className={styles.citySelect}>
              <img src={MapMark} alt="MapMark" />
              <Select placeholder="Город" transparent />
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
                      name="Text"
                      render={({ input, meta }) => (
                        <Input
                          placeholder="Поиск по названию, адресу, услуге"
                          meta={meta}
                          {...input}
                        />
                      )}
                    />
                  </div>
                  <div className={styles.nearestWash}>
                    <div className={styles.citySelect}>
                      <img src={MapMark} alt="MapMark" />
                      <Select placeholder="Город" />
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
                      <img src={Clock} alt="Clock" />
                      <Field
                        name="Time"
                        render={({ input, meta }) => (
                          <Select
                            placeholder="Время *"
                            options={TIME_FIELDS}
                            meta={meta}
                            {...input}
                          />
                        )}
                      />
                    </div>
                    <Button
                      type="submit"
                      className={styles.innerBlockButton}
                      increased
                    >
                      Подобрать мойку
                    </Button>
                  </div>
                </div>
              </form>
            );
          }}
        />
      </div>
      <div className={styles.section}>
        <h2 className={styles.cityWashes}>Мойки в Москве</h2>
        <div className={styles.washList}>
          {WASHES.map((item) => (
            <div className={styles.card} key={item.id}>
              <WashCard id={item.id} item={item} />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default IndexPage;
