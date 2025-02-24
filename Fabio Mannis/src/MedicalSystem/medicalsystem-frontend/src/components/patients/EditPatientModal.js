import React, { useState, useEffect } from "react";
import { updatePatient } from "../../api/patientService";

const EditPatientModal = ({ show, onClose, patient, onPatientUpdated }) => {
  const [updatedPatient, setUpdatedPatient] = useState({ ...patient });

  useEffect(() => {
    setUpdatedPatient({ ...patient });
  }, [patient]);

  const handleChange = (e) => {
    setUpdatedPatient({ ...updatedPatient, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updatePatient(updatedPatient.id, updatedPatient);
    onPatientUpdated();
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Edit Patient</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <input className="form-control" name="firstName" value={updatedPatient.firstName} onChange={handleChange} placeholder="First Name" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="lastName" value={updatedPatient.lastName} onChange={handleChange} placeholder="Last Name" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="taxCode" value={updatedPatient.taxCode} onChange={handleChange} placeholder="Tax Code" required />
              </div>
              <div className="mb-3">
                <input className="form-control" type="email" name="email" value={updatedPatient.email} onChange={handleChange} placeholder="Email" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="phone" value={updatedPatient.phone} onChange={handleChange} placeholder="Phone" required />
              </div>
              <button className="btn btn-primary w-100" type="submit">Save Changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditPatientModal;
