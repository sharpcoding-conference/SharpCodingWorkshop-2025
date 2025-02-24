import apiClient from "./apiClient";

export const getDoctors = async () => {
  const response = await apiClient.get("/doctors");
  return response.data;
};

export const getDoctorById = async (id) => {
  const response = await apiClient.get(`/doctors/${id}`);
  return response.data;
};

export const getDoctorsBySpecialization = async (specialization) => {
  const response = await apiClient.get(`/doctors/specialization/${specialization}`);
  return response.data;
};

export const addDoctor = async (doctor) => {
  await apiClient.post("/doctors", doctor);
};

export const updateDoctor = async (id, doctor) => {
  await apiClient.put(`/doctors/${id}`, doctor);
};

export const deleteDoctor = async (id) => {
  await apiClient.delete(`/doctors/${id}`);
};
