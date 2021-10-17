import React, { useState } from "react";
import cn from "classnames";
import { Form, Field } from "react-final-form";
import routes from "../../../helpers/routes";
import { useDispatch } from "react-redux";
import { setSession } from "../../../state/session";
import { ROLES_OPTIONS } from "../../../constants/ROLES";
import {
  composeValidators,
  required,
  validEmail,
  minValue,
} from "../../../helpers/validations";

import Button from "../../Button/Button";
import Select from "../../Select/Select";
import Input from "../../Input/Input";
import Header from "../../Header/Header";
import styles from "./LoginPage.module.scss";

const LoginPage = (props) => {
  const { history } = props;

  const [tab, setTab] = useState(history.location.pathname);
  const [state, setState] = useState({
    token: "aljkhsdbefisuwasjdebswvcoijknokwqalpmgfv",
    name: "ra",
    pass: "asdas",
    role: 2,
  });
  const dispatch = useDispatch();

  const setLoginTab = () => {
    setTab(routes.login);
    history.replace(routes.login);
  };

  const setRegisterTab = () => {
    setTab(routes.register);
    history.replace(routes.register);
  };

  const login = (data) => {
    setState((prevState) => ({
      ...prevState,
      name: data.email,
      data: data.password,
    }));

    dispatch(setSession(state));
    history.push(routes.root);
  };
  const register = (data) => {
    console.log(data);
  };

  const loginBtnCn = cn(styles.containerBoxBtn, {
    [styles.containerBoxBtnActive]: tab === routes.login,
  });
  const registerBtnCn = cn(styles.containerBoxBtn, {
    [styles.containerBoxBtnActive]: tab === routes.register,
  });
  return (
    <div className={styles.login}>
      <Header />
      <div className={styles.wrap}>
        <div className={styles.header}>
          <div className={styles.headerContaner}>
            <div className={styles.containerBox}>
              <Button
                className={loginBtnCn}
                onClick={setLoginTab}
                size="maxWidth"
              >
                Личный кабинет
              </Button>
            </div>
            <div className={styles.containerBox}>
              <Button
                className={registerBtnCn}
                onClick={setRegisterTab}
                size="maxWidth"
              >
                Регистрация
              </Button>
            </div>
          </div>
        </div>
        <div className={styles.loginForm}>
          {tab === routes.login && (
            <Form
              onSubmit={login}
              render={({ handleSubmit }) => (
                <form onSubmit={handleSubmit}>
                  <div className={styles.inputs}>
                    <div className={cn(styles.inner, styles.mobileInner)}>
                      <Field
                        name="email"
                        validate={composeValidators(required, validEmail)}
                        render={({ input, meta }) => (
                          <Input
                            className={styles.input}
                            placeholder="Username or email"
                            meta={meta}
                            {...input}
                          />
                        )}
                      />
                    </div>

                    <div className={cn(styles.inner, styles.mobileInner)}>
                      <Field
                        name="password"
                        type="password"
                        validate={composeValidators(required, minValue(6))}
                        render={({ input, meta }) => (
                          <Input
                            className={styles.input}
                            placeholder="Password"
                            meta={meta}
                            {...input}
                          />
                        )}
                      />
                    </div>
                  </div>
                  <Button
                    className={styles.sigInBtn}
                    type="submit"
                    size="maxWidth"
                  >
                    Войти
                  </Button>
                </form>
              )}
            />
          )}
          {tab === routes.register && (
            <Form
              onSubmit={register}
              validate={(values) => {
                const errors = {};
                if (
                  values.password &&
                  values.confirm_password &&
                  values.password !== values.confirm_password
                ) {
                  errors.password = "Пароли не совпадают";
                  errors.confirm_password = "Пароли не совпадают";
                }

                return errors;
              }}
              render={({ handleSubmit }) => (
                <form onSubmit={handleSubmit}>
                  <div className={styles.field}>
                    <Field
                      name="email"
                      type="email"
                      validate={composeValidators(required, validEmail)}
                    >
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
                  <div className={styles.field}>
                    <Field
                      name="password"
                      type="password"
                      validate={composeValidators(required, minValue(6))}
                    >
                      {({ input, meta }) => (
                        <Input
                          className={styles.input}
                          placeholder="Пароль"
                          meta={meta}
                          {...input}
                        />
                      )}
                    </Field>
                  </div>
                  <div className={styles.field}>
                    <Field
                      name="confirm_password"
                      type="password"
                      validate={required}
                    >
                      {({ input, meta }) => (
                        <Input
                          className={styles.input}
                          placeholder="Поторите пароль"
                          meta={meta}
                          {...input}
                        />
                      )}
                    </Field>
                  </div>
                  <Field name="role" validate={required}>
                    {({ input, meta }) => (
                      <Select
                        options={ROLES_OPTIONS}
                        placeholder="Выбирите метод регистрации"
                        meta={meta}
                        {...input}
                      />
                    )}
                  </Field>
                  <Button
                    className={styles.sigInBtn}
                    type="submit"
                    size="maxWidth"
                  >
                    Зарегистрироваться
                  </Button>
                </form>
              )}
            />
          )}
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
