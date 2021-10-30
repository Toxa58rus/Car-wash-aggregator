import { createAction, createSlice, createSelector } from "@reduxjs/toolkit";

const initialState = {
  data: null,
};

export const setDate = createAction("date/set", (value) => ({
  payload: {
    value,
  },
}));

const dateSlice = createSlice({
  name: "date",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(setDate, (state, action) => {
      const { value } = action.payload;

      state.data = value;
    });
  },
});

export const selectDate = createSelector(
  (state) => state.date,
  (date) => date.data
);

export default dateSlice.reducer;
