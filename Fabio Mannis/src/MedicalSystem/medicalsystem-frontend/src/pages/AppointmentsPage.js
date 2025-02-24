import React, { useState } from "react";
import AppointmentList from "../components/appointments/AppointmentList";
import AppointmentForm from "../components/appointments/AppointmentForm";

const AppointmentsPage = () => {
  const [refresh, setRefresh] = useState(false);

  const handleRefresh = () => setRefresh(!refresh);

  return (
    <div>
      <h1>Appointments</h1>
      <AppointmentForm onAppointmentAdded={handleRefresh} />
      <AppointmentList key={refresh} />
    </div>
  );
};

export default AppointmentsPage;
