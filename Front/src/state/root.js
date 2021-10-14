import { combineReducers } from "@reduxjs/toolkit";
import session from "./session";

const rootReducer = combineReducers({ session });

export default rootReducer;
