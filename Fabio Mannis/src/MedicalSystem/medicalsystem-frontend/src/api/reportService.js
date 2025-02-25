import apiClient from "./apiClient";

const BASE_URL = "/reports";

export const getReports = async () => {
  const response = await apiClient.get(BASE_URL);
  return response.data;
};

export const getReportById = async (id) => {
  const response = await apiClient.get(`${BASE_URL}/${id}`);
  return response.data;
};

export const addReport = async (report) => {
  await apiClient.post(BASE_URL, report);
};

export const updateReport = async (id, report) => {
  await apiClient.put(`${BASE_URL}/${id}`, report);
};

export const deleteReport = async (id) => {
  await apiClient.delete(`${BASE_URL}/${id}`);
};
