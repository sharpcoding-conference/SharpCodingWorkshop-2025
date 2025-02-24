import React, { useState } from "react";
import PatientList from "../components/patients/PatientList";
import PatientForm from "../components/patients/PatientForm";

const PatientsPage = () => {
  const [refresh, setRefresh] = useState(false);

  const handleRefresh = () => setRefresh(!refresh);

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">Patients</h1>
      <div className="row">
        <div className="col-md-4">
          <PatientForm onPatientAdded={handleRefresh} />
        </div>
        <div className="col-md-8">
          <PatientList key={refresh} />
        </div>
      </div>
    </div>
  );
};

export default PatientsPage;
