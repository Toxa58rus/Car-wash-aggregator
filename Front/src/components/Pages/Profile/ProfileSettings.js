import React, { useEffect, useState } from "react";
import { Field, Form } from "react-final-form";
import { useSelector } from "react-redux";
import sources from "../../../helpers/sources";
import api from "../../../lib/api";
import cn from "classnames";
import { selectSession } from "../../../state/session";
import { selectConstants } from "../../../state/constants";
import { ROLES_OPTIONS } from "../../../constants/ROLES";

import Button from "../../Button/Button";
import Input from "../../Input/Input";
import styles from "./ProfilePage.module.scss";
import Select from "../../Select/Select";
import CITIES from "../../../constants/CITIES";

const ProfileSettings = () => {
  const user = useSelector(selectSession);

  const saveSettings = (val) => {
    console.log({
      ...val,
      city: val.city.name,
      role: val.role.id,
      userId: user.id,
    });
    api
      .put(sources.profileSettings, {
        ...val,
        city: val.city.name,
        role: val.role.id,
        userId: user.id,
      })
      .then((response) => {})
      .catch((error) => error);
  };

  const constants = useSelector(selectConstants);

  return (
    <div className={styles.tabWrap}>
      <Form
        onSubmit={saveSettings}
        initialValues={{
          ...user,
          city: constants.cities.find((city) => city.name === user.city),
        }}
        render={({ handleSubmit }) => (
          <form onSubmit={handleSubmit} className={styles.form}>
            <div className={styles.inputs}>
              <div className={styles.inputsWrap}>
                <Field name="firstName" type="firstName">
                  {({ input, meta }) => (
                    <Input
                      className={styles.input}
                      placeholder="Имя"
                      meta={meta}
                      {...input}
                    />
                  )}
                </Field>
              </div>
              <div className={styles.inputsWrap}>
                <Field name="lastName" type="lastName">
                  {({ input, meta }) => (
                    <Input
                      className={styles.input}
                      placeholder="Фамилия"
                      meta={meta}
                      {...input}
                    />
                  )}
                </Field>
              </div>
            </div>
            <div className={styles.field}>
              <Field name="phone" type="phone">
                {({ input, meta }) => (
                  <Input
                    className={styles.input}
                    placeholder="Номер телефона"
                    meta={meta}
                    {...input}
                  />
                )}
              </Field>
            </div>
            <div className={cn(styles.field, styles.unborder)}>
              <Field name="city">
                {({ input, meta }) => (
                  <Select
                    placeholder="Город"
                    options={constants.cities}
                    defaultValue={user.city}
                    meta={meta}
                    {...input}
                  />
                )}
              </Field>
            </div>
            <div className={cn(styles.field, styles.unborder)}>
              <Field name="role">
                {({ input, meta }) => (
                  <Select
                    placeholder="Роль"
                    options={ROLES_OPTIONS}
                    defaultValue={user.city}
                    meta={meta}
                    {...input}
                  />
                )}
              </Field>
            </div>
            <Button size="maxWidth" type="submit" increased>
              Сохранить измененния
            </Button>
          </form>
        )}
      />
    </div>
  );
};

export default ProfileSettings;
