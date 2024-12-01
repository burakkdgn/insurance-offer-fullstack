// redux/travelSlice.js
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  option1: false,
  option2: false,
  dateRange: [null, null],
};

const travelSlice = createSlice({
  name: 'travel',
  initialState,
  reducers: {
    toggleOption1: (state) => {
      state.option1 = !state.option1;
    },
    toggleOption2: (state) => {
      state.option2 = !state.option2;
    },
    setDateRange: (state, action) => {
      state.dateRange = action.payload;
    },
  },
});

export const { toggleOption1, toggleOption2, setDateRange } = travelSlice.actions;

export default travelSlice.reducer;
