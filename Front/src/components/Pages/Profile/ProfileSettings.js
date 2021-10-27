import React, { useEffect, useState } from "react";
import { Field, Form } from "react-final-form";
import { useSelector } from "react-redux";
import sources from "../../../helpers/sources";
import api from "../../../lib/api";
import { selectSession } from "../../../state/session";

import Button from "../../Button/Button";
import Input from "../../Input/Input";
import styles from "./ProfilePage.module.scss";
import { getRefreshUserFromCookie } from "../../../lib/cookie";

const ProfileSettings = () => {
  const [state, setState] = useState(false);
  const requestUser = () => {
    api
      .get(sources.profileSettings)
      .then((response) => {
        // console.log(response);
      })
      .catch((error) => error);

    setState(true);
  };

  const refresh = getRefreshUserFromCookie();
  console.log(refresh);

  useEffect(() => {
    if (!state) {
      requestUser();
    }
  });

  const saveSettings = () => {};
  const user = useSelector(selectSession);
  console.log(user);

  return (
    <div className={styles.tabWrap}>
      <Form
        onSubmit={saveSettings}
        initialValues={user}
        render={({ handleSubmit }) => (
          <form onSubmit={handleSubmit} className={styles.form}>
            <div className={styles.field}>
              <Field name="email" type="email">
                {({ input, meta }) => (
                  <Input
                    className={styles.input}
                    placeholder="Ваш Email"
                    meta={meta}
                    {...input}
                  />
                )}
              </Field>
            </div>
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
            <Button size="maxWidth" increased>
              Сохранить измененния
            </Button>
          </form>
        )}
      />
    </div>
  );
};

export default ProfileSettings;
