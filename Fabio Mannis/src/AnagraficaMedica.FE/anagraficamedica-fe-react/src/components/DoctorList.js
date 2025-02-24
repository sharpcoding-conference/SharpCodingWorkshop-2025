import React, { useEffect, useState } from "react";
import { Table, Button, Alert, Spinner } from "react-bootstrap";
import { getDoctors, deleteDoctor } from "../services/doctorService";
import DoctorModal from "./DoctorModal"; // Modale per aggiungere/modificare dottori
import ConfirmModal from "./ConfirmModal"; // Nuovo modale per confermare la cancellazione

const DoctorList = () => {
  const [doctors, setDoctors] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [doctorToEdit, setDoctorToEdit] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [showConfirmModal, setShowConfirmModal] = useState(false);
  const [doctorToDelete, setDoctorToDelete] = useState(null);

  // Recupera la lista dei dottori all'avvio
  useEffect(() => {
    fetchDoctors();
  }, []);

  const fetchDoctors = async () => {
    setLoading(true);
    try {
      const data = await getDoctors();
      setDoctors(data);
      setError(null); // Resetta l'errore se la chiamata ha successo
    } catch (error) {
      setError("Errore nel recupero dei dottori.");
      console.error("Errore nel recupero dei dottori:", error);
    } finally {
      setLoading(false);
    }
  };

  // 🔹 Apre la modale per aggiungere un nuovo dottore
  const handleAddDoctor = () => {
    setDoctorToEdit(null);
    setShowModal(true);
  };

  // 🔹 Apre la modale per modificare un dottore esistente
  const handleEditDoctor = (doctor) => {
    setDoctorToEdit(doctor);
    setShowModal(true);
  };

  // 🔹 Apre la modale di conferma per eliminare un dottore
  const handleDeleteDoctor = (doctor) => {
    setDoctorToDelete(doctor);
    setShowConfirmModal(true);
  };

  // 🔹 Conferma la cancellazione del dottore
  const confirmDeleteDoctor = async () => {
    if (doctorToDelete) {
      try {
        await deleteDoctor(doctorToDelete.id);
        fetchDoctors(); // Aggiorna la lista dopo la cancellazione
      } catch (error) {
        setError("Errore nell'eliminazione del dottore.");
        console.error("Errore nell'eliminazione del dottore:", error);
      }
      setShowConfirmModal(false);
      setDoctorToDelete(null);
    }
  };

  return (
    <div>
      <h2>Gestione Dottori</h2>
      
      {/* Messaggio di errore */}
      {error && <Alert variant="danger">{error}</Alert>}

      <Button variant="primary" onClick={handleAddDoctor} className="mb-3">
        Aggiungi Dottore
      </Button>

      {loading ? (
        <Spinner animation="border" variant="primary" />
      ) : (
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Cognome</th>
              <th>Specializzazione</th>
              <th>Azioni</th>
            </tr>
          </thead>
          <tbody>
            {doctors.map((doctor) => (
              <tr key={doctor.id}>
                <td>{doctor.firstName}</td>
                <td>{doctor.lastName}</td>
                <td>{doctor.specialty}</td>
                <td>
                  <Button
                    variant="warning"
                    className="me-2"
                    onClick={() => handleEditDoctor(doctor)}
                  >
                    Modifica
                  </Button>
                  <Button
                    variant="danger"
                    onClick={() => handleDeleteDoctor(doctor)}
                  >
                    Elimina
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      )}

      {/* Modale per aggiungere/modificare dottori */}
      <DoctorModal
        show={showModal}
        onHide={() => setShowModal(false)}
        doctorData={doctorToEdit}
        refreshDoctors={fetchDoctors} // Ricarica la lista dopo salvataggio
      />

      {/* Modale di conferma eliminazione */}
      <ConfirmModal
        show={showConfirmModal}
        onHide={() => setShowConfirmModal(false)}
        onConfirm={confirmDeleteDoctor}
        message="Sei sicuro di voler eliminare questo dottore?"
      />
    </div>
  );
};

export default DoctorList;
