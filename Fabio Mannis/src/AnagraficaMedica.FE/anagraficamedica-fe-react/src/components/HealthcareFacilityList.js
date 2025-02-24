import React, { useState, useEffect } from 'react';
import { Table, Button } from 'react-bootstrap';
import { getHealthcareFacilities, deleteHealthcareFacility } from '../services/healthcareFacilityService'; // Importa il servizio
import HealthcareFacilityModal from './HealthcareFacilityModal'; // Modale per aggiungere/modificare struttura sanitaria

const HealthcareFacilityList = () => {
  const [facilities, setFacilities] = useState([]); // Stato per la lista delle strutture sanitarie
  const [showModal, setShowModal] = useState(false); // Stato per mostrare la modale
  const [facilityToEdit, setFacilityToEdit] = useState(null); // Stato per la struttura da modificare

  // Recupera la lista delle strutture sanitarie all'avvio del componente
  useEffect(() => {
    fetchHealthcareFacilities();
  }, []);

  // Funzione per ottenere la lista delle strutture sanitarie
  const fetchHealthcareFacilities = async () => {
    try {
      const data = await getHealthcareFacilities(); // Chiama il servizio per ottenere i dati
      setFacilities(data); // Salva i dati ottenuti nello stato
    } catch (error) {
      console.error('Errore nel recupero delle strutture sanitarie:', error);
    }
  };

  // Funzione per aprire la modale di aggiunta di una nuova struttura sanitaria
  const handleAddHealthcareFacility = () => {
    setFacilityToEdit(null); // Imposta null per non pre-caricare dati nella modale
    setShowModal(true); // Mostra la modale
  };

  // Funzione per aprire la modale per modificare una struttura sanitaria esistente
  const handleEditHealthcareFacility = (facility) => {
    setFacilityToEdit(facility); // Imposta la struttura da modificare
    setShowModal(true); // Mostra la modale
  };

  // Funzione per eliminare una struttura sanitaria
  const handleDeleteHealthcareFacility = async (id) => {
    if (window.confirm("Sei sicuro di voler eliminare questa struttura sanitaria?")) {
      try {
        await deleteHealthcareFacility(id); // Chiama il servizio per eliminare
        fetchHealthcareFacilities(); // Ricarica la lista delle strutture sanitarie
      } catch (error) {
        console.error("Errore nell'eliminazione della struttura sanitaria:", error);
      }
    }
  };

  return (
    <div>
      <h2>Gestione Strutture Sanitarie</h2>
      <Button variant="primary" onClick={handleAddHealthcareFacility} className="mb-3">
        Aggiungi Struttura Sanitaria
      </Button>

      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Indirizzo</th>
            <th>Telefono</th>
            <th>Azioni</th>
          </tr>
        </thead>
        <tbody>
          {facilities.map((facility) => (
            <tr key={facility.id}>
              <td>{facility.name}</td>
              <td>{facility.address}</td>
              <td>{facility.phoneNumber}</td>
              <td>
                <Button
                  variant="warning"
                  className="me-2"
                  onClick={() => handleEditHealthcareFacility(facility)} // Assicurati che venga passato l'oggetto
                >
                  Modifica
                </Button>
                <Button
                  variant="danger"
                  onClick={() => handleDeleteHealthcareFacility(facility.id)}
                >
                  Elimina
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Modale per aggiungere/modificare struttura sanitaria */}
      <HealthcareFacilityModal
        show={showModal}
        onHide={() => setShowModal(false)}
        facilityData={facilityToEdit} // Passa i dati della struttura sanitaria alla modale
        refreshFacilities={fetchHealthcareFacilities} // Ricarica la lista dopo salvataggio
      />
    </div>
  );
};

export default HealthcareFacilityList;
