import React, { useState } from "react";
import { addAppointment } from "../../api/appointmentService";

const AppointmentForm = ({ onAppointmentAdded }) => {
  const [appointment, setAppointment] = useState({
    patientId: "",
    doctorId: "",
    dateTime: "",
    status: "Booked",
  });

  const handleChange = (e) => {
    setAppointment({ ...appointment, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await addAppointment(appointment);
    onAppointmentAdded();
    setAppointment({ patientId: "", doctorId: "", dateTime: "", status: "Booked" });
  };

  return (
    <form onSubmit={handleSubmit}>
      <input name="patientId" value={appointment.patientId} onChange={handleChange} placeholder="Patient ID" required />
      <input name="doctorId" value={appointment.doctorId} onChange={handleChange} placeholder="Doctor ID" required />
      <input type="datetime-local" name="dateTime" value={appointment.dateTime} onChange={handleChange} required />
      <select name="status" value={appointment.status} onChange={handleChange}>
        <option value="Booked">Booked</option>
        <option value="Completed">Completed</option>
        <option value="Canceled">Canceled</option>
      </select>
      <button type="submit">Add Appointment</button>
    </form>
  );
};

export default AppointmentForm;
