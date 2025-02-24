import axios from "axios";

const API_BASE_URL = "https://localhost:7231/api"; // Adjust according to your API URL

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export default apiClient;
