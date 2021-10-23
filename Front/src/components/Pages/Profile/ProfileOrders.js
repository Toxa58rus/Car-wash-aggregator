import React from "react";
import { useHistory, useLocation } from "react-router";
import { replaceCurrentQuery } from "../../../helpers/routes";
import { ORDER_STATUS_ARRAY } from "../../../constants/ORDER-STATUS";

import OrderCard from "../../OrderCard/OrderCard";
import Tabs from "../../Tabs/Tabs";
import Tab from "../../Tabs/Tab";
import styles from "./ProfilePage.module.scss";

const ProfileOrders = () => {
  const history = useHistory();
  const location = useLocation();

  const onChangeTab = (status) => {
    replaceCurrentQuery(history, {
      pathname: location.pathname,
      query: { status },
    });
  };

  const renderTabs = (tabs, activeTab, onClick) => (
    <div className={styles.tabWrap}>
      <div className={styles.inner}>
        {tabs.map((tab) => {
          const { id, name } = tab;

          return (
            <Tab
              activeTab={activeTab}
              id={id}
              key={id}
              label={name}
              onClick={onClick}
            />
          );
        })}
      </div>
    </div>
  );
  return (
    <div>
      <Tabs
        onlyChildren
        selected={1}
        tabsRenderer={renderTabs}
        tabs={ORDER_STATUS_ARRAY}
        onChangeTab={onChangeTab}
      >
        <div>
          {ORDER_STATUS_ARRAY.map((item) => (
            <OrderCard status={item.id} key={item.id} />
          ))}
        </div>
      </Tabs>
    </div>
  );
};

export default ProfileOrders;
