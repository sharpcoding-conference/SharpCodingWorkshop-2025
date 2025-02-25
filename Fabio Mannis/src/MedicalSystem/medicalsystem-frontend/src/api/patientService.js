import apiClient from "./apiClient";

export const getPatients = async () => {
  const response = await apiClient.get("/patients");
  return response.data;
};

export const getPatientById = async (id) => {
  const response = await apiClient.get(`/patients/${id}`);
  return response.data;
};

export const addPatient = async (patient) => {
  await apiClient.post("/patients", patient);
};

export const updatePatient = async (id, patient) => {
  await apiClient.put(`/patients/${id}`, patient);
};

export const deletePatient = async (id) => {
  await apiClient.delete(`/patients/${id}`);
};
