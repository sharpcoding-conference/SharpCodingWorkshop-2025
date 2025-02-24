import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Container, Button } from 'react-bootstrap';
import Navigation from './components/Navbar';
import PatientList from './components/PatientList';
import DoctorList from './components/DoctorList';
import PatientModal from './components/PatientModal'; // Modal per pazienti
import DoctorModal from './components/DoctorModal'; // Modal per dottori

const App = () => {
  const [showPatientModal, setShowPatientModal] = useState(false);
  const [showDoctorModal, setShowDoctorModal] = useState(false);
  const [patientToEdit, setPatientToEdit] = useState(null);
  const [doctorToEdit, setDoctorToEdit] = useState(null);

  const handleAddPatient = () => {
    setPatientToEdit(null);
    setShowPatientModal(true);
  };

  const handleAddDoctor = () => {
    setDoctorToEdit(null);
    setShowDoctorModal(true);
  };

  const handleSavePatient = (patient) => {
    console.log('Salvato paziente:', patient);
  };

  const handleSaveDoctor = (doctor) => {
    console.log('Salvato dottore:', doctor);
  };

  return (
    <Router>
      <Navigation />
      <Container className="my-4">
        <Routes>
          <Route path="/patients" element={
            <>
              <Button variant="primary" onClick={handleAddPatient}>Aggiungi Paziente</Button>
              <PatientList onEdit={setPatientToEdit} />
            </>
          } />
          <Route path="/doctors" element={
            <>
              <DoctorList onEdit={setDoctorToEdit} />
            </>
          } />
          <Route path="/" element={<h2>Benvenuto nell'Anagrafica Medica</h2>} />
        </Routes>
      </Container>

      {/* Modali */}
      <PatientModal 
        show={showPatientModal} 
        onHide={() => setShowPatientModal(false)} 
        patientData={patientToEdit} 
        onSave={handleSavePatient} 
      />
      <DoctorModal 
        show={showDoctorModal} 
        onHide={() => setShowDoctorModal(false)} 
        doctorData={doctorToEdit} 
        onSave={handleSaveDoctor} 
      />
    </Router>
  );
};

export default App;
