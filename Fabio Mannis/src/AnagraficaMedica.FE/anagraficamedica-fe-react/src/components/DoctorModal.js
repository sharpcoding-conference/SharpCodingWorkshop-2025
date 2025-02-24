import React, { useState, useEffect } from "react";
import { Modal, Button, Form, Alert } from "react-bootstrap";
import { addDoctor, updateDoctor } from "../services/doctorService";

const DoctorModal = ({ show, onHide, doctorData, refreshDoctors }) => {
  // Stato per gestire i dati del dottore
  const [doctor, setDoctor] = useState({
    id: "",
    firstName: "",
    lastName: "",
    specialization: "",
    phoneNumber: "",
    email: "",
  });

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Se arriva un dottore da modificare, popola i campi
  useEffect(() => {
    if (doctorData) {
      setDoctor(doctorData);
    } else {
      setDoctor({
        id: "",
        firstName: "",
        lastName: "",
        specialization: "",
        phoneNumber: "",
        email: "",
      });
    }
  }, [doctorData]);

  // Gestisce l'aggiornamento dei campi
  const handleChange = (e) => {
    setDoctor({ ...doctor, [e.target.name]: e.target.value });
  };

  // Gestisce l'invio del form
  const handleSubmit = async (e) => {
    e.preventDefault();

    // Resetta l'errore precedente
    setError(null);
    setLoading(true);

    try {
      if (doctorData) {
        await updateDoctor(doctor.id, doctor); // Modifica esistente
      } else {
        await addDoctor(doctor); // Nuovo dottore
      }

      refreshDoctors(); // Aggiorna la lista dei dottori
      onHide(); // Chiude la modale
    } catch (error) {
      console.error("Errore nel salvataggio del dottore:", error);
      setError("Si è verificato un errore durante il salvataggio del dottore.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>{doctorData ? "Modifica Dottore" : "Aggiungi Dottore"}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {/* Visualizza l'errore se presente */}
        {error && <Alert variant="danger">{error}</Alert>}

        <Form onSubmit={handleSubmit}>
          {/* Nome */}
          <Form.Group className="mb-3">
            <Form.Label>Nome</Form.Label>
            <Form.Control
              type="text"
              name="firstName"
              value={doctor.firstName}
              onChange={handleChange}
              required
            />
          </Form.Group>

          {/* Cognome */}
          <Form.Group className="mb-3">
            <Form.Label>Cognome</Form.Label>
            <Form.Control
              type="text"
              name="lastName"
              value={doctor.lastName}
              onChange={handleChange}
              required
            />
          </Form.Group>

          {/* Specializzazione */}
          <Form.Group className="mb-3">
            <Form.Label>Specializzazione</Form.Label>
            <Form.Control
              type="text"
              name="specialization"
              value={doctor.specialization}
              onChange={handleChange}
              required
            />
          </Form.Group>

          {/* Numero di telefono */}
          <Form.Group className="mb-3">
            <Form.Label>Telefono</Form.Label>
            <Form.Control
              type="text"
              name="phoneNumber"
              value={doctor.phoneNumber}
              onChange={handleChange}
            />
          </Form.Group>

          {/* Email */}
          <Form.Group className="mb-3">
            <Form.Label>Email</Form.Label>
            <Form.Control
              type="email"
              name="email"
              value={doctor.email}
              onChange={handleChange}
            />
          </Form.Group>

          {/* Pulsanti */}
          <div className="text-end">
            <Button variant="secondary" onClick={onHide} className="me-2" disabled={loading}>
              Annulla
            </Button>
            <Button variant="primary" type="submit" disabled={loading}>
              {loading ? "Caricamento..." : doctorData ? "Salva Modifiche" : "Aggiungi"}
            </Button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default DoctorModal;
