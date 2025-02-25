import React, { useState } from "react";
import DiagnosisList from "../components/diagnoses/DiagnosisList";
import DiagnosisForm from "../components/diagnoses/DiagnosisForm";

const DiagnosesPage = () => {
  const [refresh, setRefresh] = useState(false);

  const handleRefresh = () => setRefresh(!refresh);

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">Diagnoses Management</h1>
      <div className="row">
        <div className="col-md-4">
          <DiagnosisForm onDiagnosisAdded={handleRefresh} />
        </div>
        <div className="col-md-8">
          <DiagnosisList key={refresh} />
        </div>
      </div>
    </div>
  );
};

export default DiagnosesPage;
