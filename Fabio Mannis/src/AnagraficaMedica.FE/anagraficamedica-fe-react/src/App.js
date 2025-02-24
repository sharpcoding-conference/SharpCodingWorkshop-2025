import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Container, Button } from 'react-bootstrap';
import Navigation from './components/Navbar';
import PatientList from './components/PatientList';
import DoctorList from './components/DoctorList';
import PatientModal from './components/PatientModal';
import DoctorModal from './components/DoctorModal';
import HealthcareFacilityList from './components/HealthcareFacilityList';
import HealthcareFacilityModal from './components/HealthcareFacilityModal';

const App = () => {
  const [showPatientModal, setShowPatientModal] = useState(false);
  const [showDoctorModal, setShowDoctorModal] = useState(false);
  const [showFacilityModal, setShowFacilityModal] = useState(false);
  const [patientToEdit, setPatientToEdit] = useState(null);
  const [doctorToEdit, setDoctorToEdit] = useState(null);
  const [facilityToEdit, setFacilityToEdit] = useState(null);
  
  const [facilities, setFacilities] = useState([]);

  const handleAddPatient = () => {
    setPatientToEdit(null);
    setShowPatientModal(true);
  };

  const handleAddDoctor = () => {
    setDoctorToEdit(null);
    setShowDoctorModal(true);
  };

  const handleAddFacility = () => {
    setFacilityToEdit(null);
    setShowFacilityModal(true);
  };

  const handleSavePatient = (patient) => {
    console.log('Salvato paziente:', patient);
  };

  const handleSaveDoctor = (doctor) => {
    console.log('Salvato dottore:', doctor);
  };

  const handleSaveFacility = (facility) => {
    if (facilityToEdit) {
      setFacilities(facilities.map(f => f.id === facilityToEdit.id ? facility : f));
    } else {
      setFacilities([...facilities, { ...facility, id: Date.now() }]);
    }
  };

  return (
    <Router>
      <Navigation />
      <Container className="my-4">
        <Routes>
          <Route path="/patients" element={
            <>
              <PatientList onEdit={setPatientToEdit} />
            </>
          } />
          <Route path="/doctors" element={
            <>
              <DoctorList onEdit={setDoctorToEdit} />
            </>
          } />
          <Route path="/healthcare-facilities" element={
            <>
              <HealthcareFacilityList 
                facilities={facilities} 
                onEdit={setFacilityToEdit} 
                onDelete={(id) => setFacilities(facilities.filter(f => f.id !== id))} 
              />
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
      <HealthcareFacilityModal 
        show={showFacilityModal} 
        onHide={() => setShowFacilityModal(false)} 
        facilityData={facilityToEdit} 
        onSave={handleSaveFacility} 
      />
    </Router>
  );
};

export default App;
