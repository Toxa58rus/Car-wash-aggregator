import React, { useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router";
import { getQuery, replaceCurrentQuery } from "../../../helpers/routes";
import { toast } from "react-toastify";
import OrderCard from "../../OrderCard/OrderCard";
import Tabs from "../../Tabs/Tabs";
import Tab from "../../Tabs/Tab";
import styles from "./ProfilePage.module.scss";
import api from "../../../lib/api";
import sources from "../../../helpers/sources";
import { useDispatch, useSelector } from "react-redux";
import { selectSession, setSession } from "../../../state/session";
import Spinner from "../../Spinner/Spinner";
import { STATUSES, STATUSES_OPTIONS } from "../../../constants/STATUSES";

const ProfileOrders = () => {
  const [state, setState] = useState({ data: null, isLoading: true });
  const history = useHistory();
  const location = useLocation();
  const session = useSelector(selectSession);
  const dispatch = useDispatch();
  const query = getQuery(location.search);

  const getOrders = () => {
    api
      .get(sources.orders(session.id), {
        params: {
          status: query.status === STATUSES.All ? null : query.status,
        },
      })
      .then((response) => {
        const value = response.data.orders;
        const reverseArr = value.reverse();

        setState({ data: reverseArr, isLoading: false });

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch(() => toast.error("Error orders"));
  };

  const onChangeTab = (status) => {
    replaceCurrentQuery(history, {
      pathname: location.pathname,
      query: { status },
    });
    setState((prevState) => ({
      ...prevState,
      isLoading: true,
    }));
  };

  useEffect(() => {
    if (state.isLoading) {
      getOrders();
    }
  }, [state.isLoading]);

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
        selected={+getQuery(location.search).status || 1}
        tabsRenderer={renderTabs}
        tabs={STATUSES_OPTIONS}
        onChangeTab={onChangeTab}
      >
        <div className={styles.tabInner}>
          {state.isLoading ? (
            <Spinner center />
          ) : (
            state.data &&
            state.data.map((item) => (
              <OrderCard
                status={item.id}
                key={item.id}
                item={item}
                udateOrders={getOrders}
              />
            ))
          )}
        </div>
      </Tabs>
    </div>
  );
};

export default ProfileOrders;
