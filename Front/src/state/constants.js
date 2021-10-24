import { createAction, createSlice, createSelector } from "@reduxjs/toolkit";

const initialState = {
  data: null,
};

export const setConstants = createAction("constants/set", (value) => ({
  payload: {
    value,
  },
}));

const constantsSlice = createSlice({
  name: "constants",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(setConstants, (state, action) => {
      const { value } = action.payload;

      state.data = value;
    });
  },
});

export const selectConstants = createSelector(
  (state) => state.constants,
  (constants) => constants.data
);

export default constantsSlice.reducer;
