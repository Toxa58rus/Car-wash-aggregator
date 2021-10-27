import React from "react";
import routes from "../../../helpers/routes";
import cn from "classnames";
import { ROLES } from "../../../constants/ROLES";
import { selectSession, setSession } from "../../../state/session";
import { useDispatch, useSelector } from "react-redux";
import { removeUserCookie } from "../../../lib/cookie";

import Button from "../../Button/Button";
import Header from "../../Header/Header";
import ProfileOrders from "./ProfileOrders";
import ProfileCarWashes from "./ProfileCarWashes";
import ProfileSettings from "./ProfileSettings";
import styles from "./ProfilePage.module.scss";

const ProfilePage = ({ history }) => {
  const session = useSelector(selectSession);
  const role = session.role;

  const setSettingsTab = () => {
    history.replace(routes.profileSettings);
  };
  const setOrdersTab = () => {
    history.replace(routes.profileOrders);
  };
  const setCarWashTab = () => {
    history.replace(routes.profileCarWashes);
  };
  const dispatch = useDispatch();

  const logOut = () => {
    removeUserCookie();
    dispatch(setSession(null));
    history.push(routes.root);
  };

  const settingsBtn = cn(styles.menuBtn, {
    [styles.activeMenuBtn]:
      history.location.pathname === routes.profileSettings,
  });
  const ordersBtn = cn(styles.menuBtn, {
    [styles.activeMenuBtn]: history.location.pathname === routes.profileOrders,
  });
  const carWashBtn = cn(styles.menuBtn, {
    [styles.activeMenuBtn]:
      history.location.pathname === routes.profileCarWashes,
  });

  return (
    <div className={styles.page}>
      <Header />
      <div className={styles.wrap}>
        <h2 className={styles.title}>
          {history.location.pathname === routes.profileSettings &&
            "Настройки профиля"}
          {history.location.pathname === routes.profileOrders &&
            "История бронирования"}
          {history.location.pathname === routes.profileCarWashes && "Мойки"}
        </h2>
        <div className={styles.container}>
          <div className={styles.profileMenu}>
            <Button
              className={settingsBtn}
              size="maxWidth"
              onClick={setSettingsTab}
            >
              Настройки профиля
            </Button>
            <Button
              className={ordersBtn}
              size="maxWidth"
              onClick={setOrdersTab}
            >
              История бронирования
            </Button>
            {role === ROLES.PARTNER && (
              <Button
                className={carWashBtn}
                size="maxWidth"
                onClick={setCarWashTab}
              >
                Мойки
              </Button>
            )}
            <Button className={styles.menuBtn} size="maxWidth" onClick={logOut}>
              Выход
            </Button>
          </div>
          <div className={styles.containerWrap}>
            {history.location.pathname === routes.profileSettings && (
              <ProfileSettings />
            )}
            {history.location.pathname === routes.profileOrders && (
              <ProfileOrders />
            )}
            {role === ROLES.PARTNER &&
              history.location.pathname === routes.profileCarWashes && (
                <ProfileCarWashes />
              )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;
