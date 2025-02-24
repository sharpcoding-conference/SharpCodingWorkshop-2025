import React, { useState, useEffect } from 'react';
import { Modal, Button, Form } from 'react-bootstrap';

const PatientModal = ({ show, onHide, onSave, patientData }) => {
  // Stati per il modulo del paziente
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');
  const [fiscalCode, setFiscalCode] = useState('');
  const [address, setAddress] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  useEffect(() => {
    if (patientData) {
      setFirstName(patientData.firstName || '');
      setLastName(patientData.lastName || '');
      setDateOfBirth(patientData.dateOfBirth || '');
      setFiscalCode(patientData.fiscalCode || '');
      setAddress(patientData.address || '');
      setPhoneNumber(patientData.phoneNumber || '');
    }
  }, [patientData]);

  const handleSave = () => {
    const newPatient = {
      firstName,
      lastName,
      dateOfBirth,
      fiscalCode,
      address,
      phoneNumber,
    };
    onSave(newPatient);
    onHide();
  };

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>{patientData ? 'Modifica Paziente' : 'Aggiungi Paziente'}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="firstName">
            <Form.Label>Nome</Form.Label>
            <Form.Control
              type="text"
              placeholder="Inserisci il nome"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="lastName">
            <Form.Label>Cognome</Form.Label>
            <Form.Control
              type="text"
              placeholder="Inserisci il cognome"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="dateOfBirth">
            <Form.Label>Data di Nascita</Form.Label>
            <Form.Control
              type="date"
              value={dateOfBirth}
              onChange={(e) => setDateOfBirth(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="fiscalCode">
            <Form.Label>Codice Fiscale</Form.Label>
            <Form.Control
              type="text"
              placeholder="Inserisci il codice fiscale"
              value={fiscalCode}
              onChange={(e) => setFiscalCode(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="address">
            <Form.Label>Indirizzo</Form.Label>
            <Form.Control
              type="text"
              placeholder="Inserisci l'indirizzo"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="phoneNumber">
            <Form.Label>Numero di Telefono</Form.Label>
            <Form.Control
              type="text"
              placeholder="Inserisci il numero di telefono"
              value={phoneNumber}
              onChange={(e) => setPhoneNumber(e.target.value)}
            />
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onHide}>Annulla</Button>
        <Button variant="primary" onClick={handleSave}>Salva</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default PatientModal;
