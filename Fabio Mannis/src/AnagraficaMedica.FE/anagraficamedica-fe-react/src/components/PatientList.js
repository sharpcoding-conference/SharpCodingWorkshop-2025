import React, { useState, useEffect } from "react";
import { Table, Button } from "react-bootstrap";
import { getPatients, deletePatient } from "../services/patientService"; // Importa il servizio dei pazienti
import PatientModal from "./PatientModal"; // Modale per aggiungere/modificare pazienti

const PatientList = () => {
  const [patients, setPatients] = useState([]); // Stato per la lista dei pazienti
  const [showModal, setShowModal] = useState(false); // Stato per mostrare la modale
  const [patientToEdit, setPatientToEdit] = useState(null); // Stato per il paziente da modificare

  // Recupera la lista dei pazienti all'avvio del componente
  useEffect(() => {
    fetchPatients();
  }, []);

  // Funzione per ottenere la lista dei pazienti
  const fetchPatients = async () => {
    try {
      const data = await getPatients(); // Chiama il servizio per ottenere i dati
      setPatients(data); // Salva i dati ottenuti nello stato
    } catch (error) {
      console.error("Errore nel recupero dei pazienti:", error);
    }
  };

  // Funzione per aprire la modale di aggiunta di un nuovo paziente
  const handleAddPatient = () => {
    setPatientToEdit(null); // Imposta null per non pre-caricare dati nella modale
    setShowModal(true); // Mostra la modale
  };

  // Funzione per aprire la modale per modificare un paziente esistente
  const handleEditPatient = (patient) => {
    setPatientToEdit(patient); // Imposta il paziente da modificare
    setShowModal(true); // Mostra la modale
  };

  // Funzione per eliminare un paziente
  const handleDeletePatient = async (id) => {
    if (window.confirm("Sei sicuro di voler eliminare questo paziente?")) {
      try {
        await deletePatient(id); // Chiama il servizio per eliminare
        fetchPatients(); // Ricarica la lista dei pazienti
      } catch (error) {
        console.error("Errore nell'eliminazione del paziente:", error);
      }
    }
  };

  return (
    <div>
      <h2>Gestione Pazienti</h2>
      <Button variant="primary" onClick={handleAddPatient} className="mb-3">
        Aggiungi Paziente
      </Button>

      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Cognome</th>
            <th>Data di Nascita</th>
            <th>Azioni</th>
          </tr>
        </thead>
        <tbody>
          {patients.map((patient) => (
            <tr key={patient.id}>
              <td>{patient.firstName}</td>
              <td>{patient.lastName}</td>
              <td>{patient.dateOfBirth}</td>
              <td>
                <Button
                  variant="warning"
                  className="me-2"
                  onClick={() => handleEditPatient(patient)} // Assicurati che venga passato il paziente
                >
                  Modifica
                </Button>
                <Button
                  variant="danger"
                  onClick={() => handleDeletePatient(patient.id)} // Passa l'id del paziente
                >
                  Elimina
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Modale per aggiungere/modificare paziente */}
      <PatientModal
        show={showModal}
        onHide={() => setShowModal(false)}
        patientData={patientToEdit} // Passa i dati del paziente alla modale
        refreshPatients={fetchPatients} // Ricarica la lista dopo salvataggio
      />
    </div>
  );
};

export default PatientList;
