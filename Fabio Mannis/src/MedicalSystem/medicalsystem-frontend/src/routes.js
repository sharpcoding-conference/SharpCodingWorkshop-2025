import React from "react";
import { Routes, Route } from "react-router-dom";
import PatientsPage from "./pages/PatientsPage";
import DoctorsPage from "./pages/DoctorsPage";
import AppointmentsPage from "./pages/AppointmentsPage";
import DiagnosesPage from "./pages/DiagnosesPage";
import ReportsPage from "./pages/ReportsPage";


const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/patients" element={<PatientsPage />} />
      <Route path="/doctors" element={<DoctorsPage />} />
      <Route path="/appointments" element={<AppointmentsPage />} />
      <Route path="/diagnoses" element={<DiagnosesPage />} />
      <Route path="/reports" element={<ReportsPage />} />
    </Routes>
  );
};

export default AppRoutes;
