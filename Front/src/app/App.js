import { useEffect, useState } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import "normalize.css";
import "../styles/global.scss";
import api from "../lib/api";
import get from "lodash/get";
import sources from "../helpers/sources";
import { useDispatch } from "react-redux";
import { setConstants } from "../state/constants";
import { setSession } from "../state/session";
import { getRefreshUserFromCookie, removeUserCookie } from "../lib/cookie";
import { toast } from "react-toastify";

import IndexPage from "../components/Pages/IndexPage/IndexPage";
import CarWash from "../components/Pages/CarWash/CarWash";
import LoginPage from "../components/Pages/LoginPage/LoginPage";
import ProfilePage from "../components/Pages/Profile/ProfilePage";
import "react-toastify/dist/ReactToastify.css";

toast.configure();

function App() {
  const [state, setState] = useState(false);
  const dispatch = useDispatch();
  const storage = JSON.parse(window.sessionStorage.getItem("redux"));

  const getConstants = () => {
    api
      .get(sources.constants)
      .then((response) => {
        dispatch(setConstants(response.data));

        if (response.user) {
          dispatch(setSession(response.user));
        }
      })
      .catch((err) => {
        if (err.status === 401) {
          setState(true);
        }
      });
  };

  useEffect(() => {
    if (getRefreshUserFromCookie() === "not_valid") {
      dispatch(setSession(null));
      removeUserCookie();
    }
    if (!storage || (!get(storage, "constants.data") && !state)) {
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
