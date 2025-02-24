import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import { createHealthcareFacility, updateHealthcareFacility } from "../services/healthcareFacilityService";

const HealthcareFacilityModal = ({ show, onHide, facilityData, refreshFacilities }) => {
  const [facility, setFacility] = useState({
    id: "",
    name: "",
    address: "",
    phoneNumber: "",
  });

  // Se arriva una struttura sanitaria da modificare, popola i campi
  useEffect(() => {
    if (facilityData) {
      setFacility(facilityData);
    } else {
      setFacility({
        id: "",
        name: "",
        address: "",
        phoneNumber: "",
      });
    }
  }, [facilityData]);

  // Gestisce il cambiamento dei campi
  const handleChange = (e) => {
    setFacility({ ...facility, [e.target.name]: e.target.value });
  };

  // Gestisce l'invio del form
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (facility.id) {
        await updateHealthcareFacility(facility.id, facility); // Modifica esistente
      } else {
        await createHealthcareFacility(facility); // Nuova struttura sanitaria
      }
      refreshFacilities(); // Ricarica la lista dopo il salvataggio
      onHide(); // Chiude la modale
    } catch (error) {
      console.error("Errore nel salvataggio della struttura sanitaria:", error);
    }
  };

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>{facility.id ? "Modifica Struttura Sanitaria" : "Aggiungi Struttura Sanitaria"}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={handleSubmit}>
          <Form.Group className="mb-3">
            <Form.Label>Nome</Form.Label>
            <Form.Control
              type="text"
              name="name"
              value={facility.name}
              onChange={handleChange}
              required
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Indirizzo</Form.Label>
            <Form.Control
              type="text"
              name="address"
              value={facility.address}
              onChange={handleChange}
              required
            />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Telefono</Form.Label>
            <Form.Control
              type="text"
              name="phoneNumber"
              value={facility.phoneNumber}
              onChange={handleChange}
            />
          </Form.Group>

          <div className="text-end">
            <Button variant="secondary" onClick={onHide} className="me-2">
              Annulla
            </Button>
            <Button variant="primary" type="submit">
              {facility.id ? "Salva Modifiche" : "Aggiungi"}
            </Button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default HealthcareFacilityModal;
