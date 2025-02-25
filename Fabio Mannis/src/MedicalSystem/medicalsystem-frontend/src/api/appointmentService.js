import apiClient from "./apiClient";

export const getAppointments = async () => {
  const response = await apiClient.get("/appointments");
  return response.data;
};

export const getAppointmentById = async (id) => {
  const response = await apiClient.get(`/appointments/${id}`);
  return response.data;
};

export const getAppointmentsByDoctor = async (doctorId) => {
  const response = await apiClient.get(`/appointments/doctor/${doctorId}`);
  return response.data;
};

export const getAppointmentsByPatient = async (patientId) => {
  const response = await apiClient.get(`/appointments/patient/${patientId}`);
  return response.data;
};

export const addAppointment = async (appointment) => {
  await apiClient.post("/appointments", appointment);
};

export const updateAppointment = async (id, appointment) => {
  await apiClient.put(`/appointments/${id}`, appointment);
};

export const deleteAppointment = async (id) => {
  await apiClient.delete(`/appointments/${id}`);
};
