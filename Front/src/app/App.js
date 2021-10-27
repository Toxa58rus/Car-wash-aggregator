import { useEffect } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import "normalize.css";
import "../styles/global.scss";
import api from "../lib/api";
import get from "lodash/get";
import sources from "../helpers/sources";
import { useDispatch, useSelector } from "react-redux";
import { selectConstants, setConstants } from "../state/constants";
import { selectSession, setSession } from "../state/session";

import IndexPage from "../components/Pages/IndexPage/IndexPage";
import CarWash from "../components/Pages/CarWash/CarWash";
import LoginPage from "../components/Pages/LoginPage/LoginPage";
import ProfilePage from "../components/Pages/Profile/ProfilePage";
import { getRefreshUserFromCookie } from "../lib/cookie";

function App() {
  const dispatch = useDispatch();
  const constantsCONS = useSelector(selectConstants);
  const session = useSelector(selectSession);
  const storage = JSON.parse(window.sessionStorage.getItem("redux"));
  console.log(getRefreshUserFromCookie());
  console.log(constantsCONS);
  console.log(session);
  console.log(storage);

  const getConstants = () => {
    api.get(sources.constants).then((response) => {
      console.log(response);
      dispatch(setConstants(response.data));

      if (response.user) {
        dispatch(setSession(response.user));
      }
    });
  };

  useEffect(() => {
    if (!getRefreshUserFromCookie()) {
      dispatch(setSession(null));
    }
    if (!storage || !get(storage, "constants.data")) {
      getConstants();
    }
  });

  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={IndexPage} />
        <Route exact path="/car-wash/:id" component={CarWash} />
        <Route exact path="/login" component={LoginPage} />
        <Route exact path="/register" component={LoginPage} />
        <Route exact path="/profile/settings" component={ProfilePage} />
        <Route exact path="/profile/orders" component={ProfilePage} />
        <Route exact path="/profile/car-washes" component={ProfilePage} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
