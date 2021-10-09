import { BrowserRouter, Switch, Route } from "react-router-dom";
import "normalize.css";
import "../styles/global.scss";

import IndexPage from "../components/Pages/IndexPage/IndexPage";
import CarWash from "../components/Pages/CarWash/CarWash";

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={IndexPage} />
        <Route exact path="/car-wash/:id" component={CarWash} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
