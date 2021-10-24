import { BrowserRouter, Switch, Route } from "react-router-dom";
import "normalize.css";
import "../styles/global.scss";

import IndexPage from "../components/Pages/IndexPage/IndexPage";
import CarWash from "../components/Pages/CarWash/CarWash";
import LoginPage from "../components/Pages/LoginPage/LoginPage";
import ProfilePage from "../components/Pages/Profile/ProfilePage";
import { useEffect } from "react";
import api from "../lib/api";
import sources from "../helpers/sources";

function App() {
  useEffect(() => {
    const getConstants = () => {
      api.get(sources.constants).then((respose) => {
        console.log(respose);
      });
    };

    getConstants();
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
