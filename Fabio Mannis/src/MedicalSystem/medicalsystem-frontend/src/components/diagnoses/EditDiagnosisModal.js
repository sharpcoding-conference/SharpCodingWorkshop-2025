import React, { useState, useEffect } from "react";
import { updateDiagnosis } from "../../api/diagnosisService";
import { getAppointments } from "../../api/appointmentService";

const EditDiagnosisModal = ({ show, onClose, diagnosis, onDiagnosisUpdated }) => {
  const [updatedDiagnosis, setUpdatedDiagnosis] = useState({ ...diagnosis });
  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    setUpdatedDiagnosis({ ...diagnosis });
    loadAppointments();
  }, [diagnosis]);

  const loadAppointments = async () => {
    const data = await getAppointments();
    setAppointments(data);
  };

  const handleChange = (e) => {
    setUpdatedDiagnosis({ ...updatedDiagnosis, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateDiagnosis(updatedDiagnosis.id, updatedDiagnosis);
    onDiagnosisUpdated();
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Edit Diagnosis</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label className="form-label">Appointment</label>
                <select className="form-select" name="appointmentId" value={updatedDiagnosis.appointmentId} onChange={handleChange} required>
                  <option value="">Select Appointment</option>
                  {appointments.map((appointment) => (
                    <option key={appointment.id} value={appointment.id}>
                      {appointment.patientId} - {new Date(appointment.dateTime).toLocaleString()} ({appointment.status})
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Diagnosis Description</label>
                <textarea className="form-control" name="description" value={updatedDiagnosis.description} onChange={handleChange} required />
              </div>
              <button className="btn btn-primary w-100" type="submit">Save Changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditDiagnosisModal;
