import { compose, createStore } from "redux";
import rootReducer from "./state/root";
import persistState from "redux-sessionstorage";

const createPersistentStore = compose(persistState(["session", "constants"]))(
  createStore
);

const store = createPersistentStore(rootReducer, {});

export default store;
