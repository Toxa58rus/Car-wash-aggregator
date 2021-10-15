import React from "react";
import routes from "../../../helpers/routes";
import cn from "classnames";
import { ORDERS_STATUS } from "../../../constants/ORDER-STATUS";

import Button from "../../Button/Button";
import Header from "../../Header/Header";
import OrderCard from "../../OrderCard/OrderCard";
import styles from "./ProfilePage.module.scss";

const ProfilePage = ({ history }) => {
  const setSettingsTab = () => {
    history.replace(routes.profileSettings);
  };
  const setOrdersTab = () => {
    history.replace(routes.profileOrders);
  };
  console.log(history);

  const settingsBtn = cn(styles.menuBtn, {
    [styles.activeMenuBtn]:
      history.location.pathname === routes.profileSettings,
  });
  const ordersBtn = cn(styles.menuBtn, {
    [styles.activeMenuBtn]: history.location.pathname === routes.profileOrders,
  });

  return (
    <div className={styles.page}>
      <Header />
      <div className={styles.wrap}>
        <h2 className={styles.title}>Title PAge</h2>
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
          </div>
          <div className={styles.containerWrap}>
            <OrderCard status={ORDERS_STATUS.BOOKED} />
            <OrderCard status={ORDERS_STATUS.FINISHED} />
            <OrderCard status={ORDERS_STATUS.CANCELED} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;
