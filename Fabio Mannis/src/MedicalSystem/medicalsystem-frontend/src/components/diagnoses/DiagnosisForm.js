import React, { useState, useEffect } from "react";
import { addDiagnosis } from "../../api/diagnosisService";
import { getAppointments } from "../../api/appointmentService";

const DiagnosisForm = ({ onDiagnosisAdded }) => {
  const [diagnosis, setDiagnosis] = useState({
    appointmentId: "",
    description: "",
  });

  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    loadAppointments();
  }, []);

  const loadAppointments = async () => {
    const data = await getAppointments();
    setAppointments(data);
  };

  const handleChange = (e) => {
    setDiagnosis({ ...diagnosis, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!diagnosis.appointmentId || !diagnosis.description) {
      alert("Please fill in all required fields.");
      return;
    }

    await addDiagnosis(diagnosis);
    onDiagnosisAdded();
    clearSelection();
  };

  const clearSelection = () => {
    setDiagnosis({
      appointmentId: "",
      description: "",
    });
  };

  return (
    <div className="card p-4">
      <h4 className="mb-3">Add Diagnosis</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <select className="form-select" name="appointmentId" value={diagnosis.appointmentId} onChange={handleChange} required>
            <option value="">Select Appointment</option>
            {appointments.map((appointment) => (
              <option key={appointment.id} value={appointment.id}>
                {appointment.patientId} - {new Date(appointment.dateTime).toLocaleString()} ({appointment.status})
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <textarea className="form-control" name="description" value={diagnosis.description} onChange={handleChange} placeholder="Diagnosis Description" required />
        </div>
        <button className="btn btn-primary w-100" type="submit">Add Diagnosis</button>
      </form>
    </div>
  );
};

export default DiagnosisForm;
