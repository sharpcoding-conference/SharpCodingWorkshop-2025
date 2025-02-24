import React, { useState } from "react";
import { addPatient } from "../../api/patientService";

const PatientForm = ({ onPatientAdded }) => {
  const [patient, setPatient] = useState({
    firstName: "",
    lastName: "",
    taxCode: "",
    email: "",
    phone: "",
  });

  const handleChange = (e) => {
    setPatient({ ...patient, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await addPatient(patient);
    onPatientAdded();
    clearSelection(); // ✅ Reset form fields
  };

  const clearSelection = () => {
    setPatient({
      firstName: "",
      lastName: "",
      taxCode: "",
      email: "",
      phone: "",
    });
  };

  return (
    <div className="card p-4">
      <h4 className="mb-3">Add Patient</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <input className="form-control" name="firstName" value={patient.firstName} onChange={handleChange} placeholder="First Name" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="lastName" value={patient.lastName} onChange={handleChange} placeholder="Last Name" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="taxCode" value={patient.taxCode} onChange={handleChange} placeholder="Tax Code" required />
        </div>
        <div className="mb-3">
          <input className="form-control" type="email" name="email" value={patient.email} onChange={handleChange} placeholder="Email" required />
        </div>
        <div className="mb-3">
          <input className="form-control" name="phone" value={patient.phone} onChange={handleChange} placeholder="Phone" required />
        </div>
        <button className="btn btn-primary w-100" type="submit">Add Patient</button>
      </form>
    </div>
  );
};

export default PatientForm;
