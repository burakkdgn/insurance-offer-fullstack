import React from 'react';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { StaticDateRangePicker } from '@mui/x-date-pickers-pro/StaticDateRangePicker';
import { useDispatch, useSelector } from 'react-redux';
import { toggleOption1, toggleOption2, setDateRange } from '../redux/travelSlice';
import { Grid, Paper } from '@mui/material';
import dayjs from 'dayjs';

const TravelInformation = ({ onBack, onNext }) => {
  const dispatch = useDispatch();
  const { option1, option2, dateRange } = useSelector((state) => state.travel);

  const handleOption1Change = () => {
    dispatch(toggleOption1());
  };

  const handleOption2Change = () => {
    dispatch(toggleOption2());
  };

  const handleDateChange = (newDateRange) => {
    const serializedDateRange = newDateRange.map(date => date ? date.toISOString() : null);
    dispatch(setDateRange(serializedDateRange));
  };
  // State'teki string tarihleri dayjs nesnesine dönüştürme
  const formattedDateRange = dateRange.map(date => date ? dayjs(date) : null);

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Grid 
        container
        justifyContent="center"
        alignItems="center"
        sx={{
          minHeight: '100vh',
          bgcolor: '#ffffff', 
          padding: 2,
          mt: 0,
        }}
      >
        <Grid item xs={12} sm={8} md={6} lg={4}>
          <Box 
            sx={{
              p: 3,
              bgcolor: 'f0f0f0',
              borderRadius: 2,
              boxShadow: 2,
              marginTop: -85,
            }}
          >
            <Typography variant="h6" gutterBottom align="center">
              Lütfen seyahatle ilgili bilgileri girin.
            </Typography>
            
            <Box mb={2}>
              <Paper elevation={1} sx={{ mb: 2, p: 0.2 }}>
                <FormControlLabel
                  control={
                    <Checkbox 
                      checked={option1} 
                      onChange={handleOption1Change} 
                    />
                  }
                  label="Schengen ve Tüm Dünya (ABD, Japonya Hariç)"
                  sx={{ width: '100%' }}
                />
              </Paper>
              <Paper elevation={1} sx={{ p: 0.2 }}>
                <FormControlLabel
                  control={
                    <Checkbox 
                      checked={option2} 
                      onChange={handleOption2Change} 
                    />
                  }
                  label="Schengen ve Tüm Dünya (ABD, Japonya Dahil)"
                  sx={{ width: '100%' }}
                />
              </Paper>
            </Box>

            <StaticDateRangePicker
                value={formattedDateRange}
                onChange={handleDateChange}
                calendars={1}
                displayStaticWrapperAs="desktop"
                sx={{
                  width: '100%',
                  [`& .MuiPickersDateRangeCalendar-root`]: {
                    justifyContent: 'center',
                  },
                  [`& .MuiPickersStaticWrapper-root`]: {
                    width: '100%',
                  },
                }}
              />

            <Typography variant="caption" color="error" align="center" display="block" mt={2} mb={2}>
              Lütfen gidiş ve dönüş tarihlerini ayrı ayrı seçiniz.
            </Typography>

            <Box display="flex" justifyContent="space-between">
              <Button variant="outlined" onClick={onBack} sx={{ width: '48%' }}>
                Geri
              </Button>
              <Button variant="contained" color="primary" onClick={onNext} sx={{ width: '48%', bgcolor: "#273a7e", color: "#fff", "&:hover": { bgcolor: "#273a7e" } }}>
                Devam
              </Button>
            </Box>
          </Box>
        </Grid>
      </Grid>
    </LocalizationProvider>
  );
};

export default TravelInformation;
