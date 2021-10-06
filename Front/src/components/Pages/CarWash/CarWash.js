import React from "react";
import { Form, Field } from "react-final-form";

import Header from "../../Header/Header";
import Input from "../../Input/Input";
import styles from "./CarWash.module.scss";

import locationIcon from "../../../icons/location.svg";
import calendarIcon from "../../../icons/calendar.svg";
import timeIcon from "../../../icons/time.svg";

const CarWash = () => {
  const createOrder = (val) => {
    console.log(val);
  };

  return (
    <div className={styles.page}>
      <Header />
      <div className={styles.wrap}>
        <div className={styles.tittlePage}>
          <h2>Бронирование автомойки</h2>
          <div className={styles.location}>
            <img src={locationIcon} alt="location" />
            <input type="select" />
          </div>
        </div>
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
            render={({ handleSubmit }) => (
              <form onSubmit={handleSubmit} className={styles.form}>
                <div className={styles.formInner}>
                  <img src={calendarIcon} alt="calendar" />
                  <Field
                    name="date"
                    render={({ input, meta }) => (
                      <Input
                        className={styles.input}
                        placeholder="Выберете дату"
                        meta={meta}
                        {...input}
                      />
                    )}
                  />
                </div>
                <div className={styles.formInner}>
                  <img src={timeIcon} alt="calendar" />
                  <Field
                    name="time"
                    render={({ input, meta }) => (
                      <Input
                        className={styles.input}
                        placeholder="Выберете время"
                        meta={meta}
                        {...input}
                      />
                    )}
                  />
                </div>
                <div className={styles.formInner}>
                  <Field
                    name="phone"
                    render={({ input, meta }) => (
                      <Input
                        className={styles.input}
                        placeholder="+7-(___)-___-__-__"
                        meta={meta}
                        {...input}
                      />
                    )}
                  />
                </div>
                <button className={styles.submit}>Забронировать</button>
              </form>
            )}
          />
        </div>
      </div>
    </div>
  );
};

export default CarWash;
