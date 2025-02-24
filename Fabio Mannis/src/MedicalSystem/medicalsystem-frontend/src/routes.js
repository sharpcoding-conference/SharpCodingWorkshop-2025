import React from "react";
import { Routes, Route } from "react-router-dom";
import PatientsPage from "./pages/PatientsPage";
import DoctorsPage from "./pages/DoctorsPage";
import AppointmentsPage from "./pages/AppointmentsPage";


const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/patients" element={<PatientsPage />} />
      <Route path="/doctors" element={<DoctorsPage />} />
      <Route path="/appointments" element={<AppointmentsPage />} />
      <Route path="*" element={<PatientsPage />} /> {/* Default Route */}
    </Routes>
  );
};

export default AppRoutes;
