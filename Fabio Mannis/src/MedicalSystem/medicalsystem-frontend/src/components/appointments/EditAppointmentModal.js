import React, { useState, useEffect } from "react";
import { updateAppointment } from "../../api/appointmentService";

const EditAppointmentModal = ({ show, onClose, appointment, onAppointmentUpdated }) => {
  const [updatedAppointment, setUpdatedAppointment] = useState({ ...appointment });

  useEffect(() => {
    setUpdatedAppointment({ ...appointment });
  }, [appointment]);

  const handleChange = (e) => {
    setUpdatedAppointment({ ...updatedAppointment, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateAppointment(updatedAppointment.id, updatedAppointment);
    onAppointmentUpdated();
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Edit Appointment</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <input className="form-control" name="patientId" value={updatedAppointment.patientId} onChange={handleChange} placeholder="Patient ID" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="doctorId" value={updatedAppointment.doctorId} onChange={handleChange} placeholder="Doctor ID" required />
              </div>
              <div className="mb-3">
                <input className="form-control" type="datetime-local" name="dateTime" value={updatedAppointment.dateTime} onChange={handleChange} required />
              </div>
              <div className="mb-3">
                <select className="form-select" name="status" value={updatedAppointment.status} onChange={handleChange}>
                  <option value="Booked">Booked</option>
                  <option value="Completed">Completed</option>
                  <option value="Canceled">Canceled</option>
                </select>
              </div>
              <button className="btn btn-primary w-100" type="submit">Save Changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditAppointmentModal;
