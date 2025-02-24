import React, { useEffect, useState } from "react";
import { Table, Button } from "react-bootstrap";
import { getDoctors, deleteDoctor } from "../services/doctorService";
import DoctorModal from "./DoctorModal"; // Modale per aggiungere/modificare dottori

const DoctorList = () => {
  const [doctors, setDoctors] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [doctorToEdit, setDoctorToEdit] = useState(null);

  // Recupera la lista dei dottori all'avvio
  useEffect(() => {
    fetchDoctors();
  }, []);

  const fetchDoctors = async () => {
    try {
      const data = await getDoctors();
      setDoctors(data);
    } catch (error) {
      console.error("Errore nel recupero dei dottori:", error);
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

  // 🔹 Cancella un dottore
  const handleDeleteDoctor = async (id) => {
    if (window.confirm("Sei sicuro di voler eliminare questo dottore?")) {
      try {
        await deleteDoctor(id);
        fetchDoctors(); // Aggiorna la lista dopo la cancellazione
      } catch (error) {
        console.error("Errore nell'eliminazione del dottore:", error);
      }
    }
  };

  return (
    <div>
      <h2>Gestione Dottori</h2>
      <Button variant="primary" onClick={handleAddDoctor} className="mb-3">
        Aggiungi Dottore
      </Button>

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
                  onClick={() => handleDeleteDoctor(doctor.id)}
                >
                  Elimina
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Modale per aggiungere/modificare dottori */}
      <DoctorModal
        show={showModal}
        onHide={() => setShowModal(false)}
        doctorData={doctorToEdit}
        refreshDoctors={fetchDoctors} // Ricarica la lista dopo salvataggio
      />
    </div>
  );
};

export default DoctorList;
