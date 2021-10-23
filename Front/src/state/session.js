import { createAction, createSlice, createSelector } from "@reduxjs/toolkit";

const initialState = {
  data: null,
};

export const setSession = createAction("session/set", (value) => ({
  payload: {
    value,
  },
}));

const sessionSlice = createSlice({
  name: "session",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(setSession, (state, action) => {
      const { value } = action.payload;

      state.data = value;
    });
  },
});

export const selectSession = createSelector(
  (state) => state.session,
  (session) => session.data
);

export default sessionSlice.reducer;
