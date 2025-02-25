import apiClient from "./apiClient";

const BASE_URL = "/diagnoses"; // Percorso base delle diagnosi

export const getDiagnoses = async () => {
  const response = await apiClient.get(BASE_URL);
  return response.data;
};

export const getDiagnosisById = async (id) => {
  const response = await apiClient.get(`${BASE_URL}/${id}`);
  return response.data;
};

export const addDiagnosis = async (diagnosis) => {
  await apiClient.post(BASE_URL, diagnosis);
};

export const updateDiagnosis = async (id, diagnosis) => {
  await apiClient.put(`${BASE_URL}/${id}`, diagnosis);
};

export const deleteDiagnosis = async (id) => {
  await apiClient.delete(`${BASE_URL}/${id}`);
};
