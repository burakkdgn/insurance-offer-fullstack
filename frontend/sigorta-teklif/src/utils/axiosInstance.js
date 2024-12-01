import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7175', // Backend base URL'nizi buraya yazın
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosInstance;
