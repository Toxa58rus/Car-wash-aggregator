import { BrowserRouter, Switch, Route } from "react-router-dom";
import "normalize.css";
import "../styles/global.scss";

import IndexPage from "../components/Pages/IndexPage/IndexPage";

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={IndexPage} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
