import React, { useEffect, useState } from 'react';
import { getPatients } from '../services/patientService';
import { Button, Table } from 'react-bootstrap';

const PatientList = ({ onEdit }) => {
  const [patients, setPatients] = useState([]);

  useEffect(() => {
    const fetchPatients = async () => {
      const patientsData = await getPatients();
      setPatients(patientsData);
    };

    fetchPatients();
  }, []);

  return (
    <div>
      <Table striped bordered hover className="mt-4">
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
                <Button variant="warning" onClick={() => onEdit(patient)}>Modifica</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default PatientList;
