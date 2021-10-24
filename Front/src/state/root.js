import { combineReducers } from "@reduxjs/toolkit";
import session from "./session";
import constants from "./constants";

const rootReducer = combineReducers({ session, constants });

export default rootReducer;
