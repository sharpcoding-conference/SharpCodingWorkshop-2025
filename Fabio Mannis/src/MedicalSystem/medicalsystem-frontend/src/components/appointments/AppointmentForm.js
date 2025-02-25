import React, { useState, useEffect } from "react";
import { addAppointment } from "../../api/appointmentService";
import { getDoctors } from "../../api/doctorService";

const AppointmentForm = ({ onAppointmentAdded }) => {
  const [appointment, setAppointment] = useState({
    patientId: "",
    doctorId: "",
    dateTime: "",
    status: "Booked",
  });

  const [doctors, setDoctors] = useState([]);

  useEffect(() => {
    loadDoctors();
  }, []);

  const loadDoctors = async () => {
    const data = await getDoctors();
    setDoctors(data);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setAppointment((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Controllo per evitare invio di campi vuoti
    if (!appointment.patientId || !appointment.doctorId || !appointment.dateTime) {
      alert("Please fill in all required fields.");
      return;
    }

    await addAppointment(appointment);
    onAppointmentAdded();
    clearSelection();
  };

  const clearSelection = () => {
    setAppointment({
      patientId: "",
      doctorId: "",
      dateTime: "",
      status: "Booked",
    });
  };

  return (
    <div className="card p-4">
      <h4 className="mb-3">Add Appointment</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <input className="form-control" name="patientId" value={appointment.patientId} onChange={handleChange} placeholder="Patient ID" required />
        </div>
        <div className="mb-3">
          <select className="form-select" name="doctorId" value={appointment.doctorId} onChange={handleChange} required>
            <option value="">Select Doctor</option>
            {doctors.map((doctor) => (
              <option key={doctor.id} value={doctor.id}>
                {doctor.firstName} {doctor.lastName} - {doctor.specialization}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <input className="form-control" type="datetime-local" name="dateTime" value={appointment.dateTime} onChange={handleChange} required />
        </div>
        <div className="mb-3">
          <select className="form-select" name="status" value={appointment.status} onChange={handleChange}>
            <option value="0">Booked</option>
            <option value="1">Completed</option>
            <option value="2">Canceled</option>
          </select>
        </div>
        <button className="btn btn-primary w-100" type="submit">Add Appointment</button>
      </form>
    </div>
  );
};

export default AppointmentForm;
