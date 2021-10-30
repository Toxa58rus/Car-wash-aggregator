import { combineReducers } from "@reduxjs/toolkit";
import session from "./session";
import constants from "./constants";
import date from "./date";

const rootReducer = combineReducers({ session, constants, date });

export default rootReducer;
