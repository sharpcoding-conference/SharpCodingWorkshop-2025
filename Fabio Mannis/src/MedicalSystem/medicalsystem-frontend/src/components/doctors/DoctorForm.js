import React, { useState } from "react";
import { addDoctor } from "../../api/doctorService";

const DoctorForm = ({ onDoctorAdded }) => {
  const [doctor, setDoctor] = useState({
    firstName: "",
    lastName: "",
    specialization: "",
    email: "",
    phone: "",
    medicalFacilityId: "",
  });

  const handleChange = (e) => {
    setDoctor({ ...doctor, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await addDoctor(doctor);
    onDoctorAdded();
    setDoctor({
      firstName: "",
      lastName: "",
      specialization: "",
      email: "",
      phone: "",
      medicalFacilityId: "",
    });
  };

  return (
    <div className="card p-4">
      <h4 className="mb-3">Add Doctor</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <input className="form-control" name="firstName" value={doctor.firstName} onChange={handleChange} placeholder="First Name" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="lastName" value={doctor.lastName} onChange={handleChange} placeholder="Last Name" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="specialization" value={doctor.specialization} onChange={handleChange} placeholder="Specialization" required />
        </div>
        <div className="mb-3">
          <input className="form-control" type="email" name="email" value={doctor.email} onChange={handleChange} placeholder="Email" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="phone" value={doctor.phone} onChange={handleChange} placeholder="Phone" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="medicalFacilityId" value={doctor.medicalFacilityId} onChange={handleChange} placeholder="Facility ID" required />
        </div>
        <button className="btn btn-primary w-100" type="submit">Add Doctor</button>
      </form>
    </div>
  );
};

export default DoctorForm;
