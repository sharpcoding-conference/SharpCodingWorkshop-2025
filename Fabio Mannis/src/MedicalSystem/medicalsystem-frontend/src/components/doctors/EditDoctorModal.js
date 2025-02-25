import React, { useState, useEffect } from "react";
import { updateDoctor } from "../../api/doctorService";

const EditDoctorModal = ({ show, onClose, doctor, onDoctorUpdated }) => {
  const [updatedDoctor, setUpdatedDoctor] = useState({ ...doctor });

  useEffect(() => {
    setUpdatedDoctor({ ...doctor });
  }, [doctor]);

  const handleChange = (e) => {
    setUpdatedDoctor({ ...updatedDoctor, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateDoctor(updatedDoctor.id, updatedDoctor);
    onDoctorUpdated();
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Edit Doctor</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <input className="form-control" name="firstName" value={updatedDoctor.firstName} onChange={handleChange} placeholder="First Name" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="lastName" value={updatedDoctor.lastName} onChange={handleChange} placeholder="Last Name" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="specialization" value={updatedDoctor.specialization} onChange={handleChange} placeholder="Specialization" required />
              </div>
              <div className="mb-3">
                <input className="form-control" type="email" name="email" value={updatedDoctor.email} onChange={handleChange} placeholder="Email" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="phone" value={updatedDoctor.phone} onChange={handleChange} placeholder="Phone" required />
              </div>
              <div className="mb-3">
                <input className="form-control" name="medicalFacilityId" value={updatedDoctor.medicalFacilityId} onChange={handleChange} placeholder="Facility ID" required />
              </div>
              <button className="btn btn-primary w-100" type="submit">Save Changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditDoctorModal;
