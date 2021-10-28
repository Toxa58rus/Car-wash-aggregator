import React from "react";
import { Form, Field } from "react-final-form";
import { required } from "../../helpers/validations";
import { useSelector } from "react-redux";
import { selectConstants } from "../../state/constants";

import Input from "../Input/Input";
import Button from "../Button/Button";
import Select from "../Select/Select";
import styles from "./AddCarWash.module.scss";
import AddPhoto from "../AddPhoto/AddPhoto";

const AddCarWash = () => {
  const saveCarWash = (values) => {
    console.log(values);
  };
  let currentForm = null;

  const constants = useSelector(selectConstants);

  const formChange = (image) => {
    console.log(image);
    currentForm.change("photo", image);
  };

  return (
    <div className={styles.contain}>
      <div className={styles.title}>Заполните форму</div>
      <Form
        onSubmit={saveCarWash}
        render={({ handleSubmit, form }) => {
          currentForm = form;
          return (
            <form onSubmit={handleSubmit}>
              <div className={styles.inner}>
                <Field
                  name="carWashName"
                  validate={required}
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
                  validate={required}
                  render={({ input, meta }) => {
                    return (
                      <Select
                        placeholder="Город*"
                        options={constants.cities}
                        meta={meta}
                        {...input}
                      />
                    );
                  }}
                />
              </div>
              <div className={styles.inner}>
                <Field
                  name="address"
                  validate={required}
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
                        options={constants.cars}
                        isMulti
                        meta={meta}
                        {...input}
                      />
                    );
                  }}
                />
              </div>
              <div className={styles.inner}>
                <Field
                  name="photo"
                  render={({ input, meta }) => {
                    return (
                      <AddPhoto
                        placeholder="Фото *"
                        formChange={formChange}
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
              <Button
                type="submit"
                size="maxWidth"
                className={styles.reviewBtn}
              >
                Сохранить мойку
              </Button>
            </form>
          );
        }}
      />
    </div>
  );
};

export default AddCarWash;
