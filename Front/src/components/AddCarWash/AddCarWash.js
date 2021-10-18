import React from "react";
import { Form, Field } from "react-final-form";

import Input from "../Input/Input";
import Button from "../Button/Button";
import Select from "../Select/Select";
import styles from "./AddCarWash.module.scss";

const AddCarWash = () => {
  const saveCarWash = () => {};
  return (
    <div className={styles.contain}>
      <div className={styles.title}>Заполните форму</div>
      <Form
        onSubmit={saveCarWash}
        render={({ handleSubmit }) => (
          <form onSubmit={handleSubmit}>
            <div className={styles.inner}>
              <Field
                name="carWashName"
                render={({ input, meta }) => {
                  return (
                    <Input
                      placeholder="Название Мойки*"
                      className={styles.input}
                      meta={meta}
                      {...input}
                    />
                  );
                }}
              />
            </div>
            <div className={styles.inner}>
              <Field
                name="city"
                render={({ input, meta }) => {
                  return <Select placeholder="Город*" meta={meta} {...input} />;
                }}
              />
            </div>
            <div className={styles.inner}>
              <Field
                name="address"
                render={({ input, meta }) => {
                  return (
                    <Input
                      placeholder="Адресс*"
                      className={styles.input}
                      meta={meta}
                      {...input}
                    />
                  );
                }}
              />
            </div>
            <div className={styles.inner}>
              <Field
                name="categories"
                render={({ input, meta }) => {
                  return (
                    <Select
                      placeholder="Категории автомобилей*"
                      meta={meta}
                      {...input}
                    />
                  );
                }}
              />
            </div>
            <Field
              name="description"
              render={({ input, meta }) => (
                <textarea
                  className={styles.textarea}
                  placeholder="Описание"
                  {...input}
                  meta={meta}
                />
              )}
            />
            <Button type="submit" size="maxWidth" className={styles.reviewBtn}>
              Сохранить мойку
            </Button>
          </form>
        )}
      />
    </div>
  );
};

export default AddCarWash;
