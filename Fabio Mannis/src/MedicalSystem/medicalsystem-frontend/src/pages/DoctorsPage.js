import React, { useState } from "react";
import DoctorList from "../components/doctors/DoctorList";
import DoctorForm from "../components/doctors/DoctorForm";

const DoctorsPage = () => {
  const [refresh, setRefresh] = useState(false);

  const handleRefresh = () => setRefresh(!refresh);

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">Doctors</h1>
      <div className="row">
        <div className="col-md-4">
          <DoctorForm onDoctorAdded={handleRefresh} />
        </div>
        <div className="col-md-8">
          <DoctorList key={refresh} />
        </div>
      </div>
    </div>
  );
};

export default DoctorsPage;
