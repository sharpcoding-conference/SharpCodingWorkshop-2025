import React, { useEffect, useState } from "react";
import { getPatients, deletePatient } from "../../api/patientService";
import EditPatientModal from "./EditPatientModal";

const PatientList = () => {
  const [patients, setPatients] = useState([]);
  const [selectedPatient, setSelectedPatient] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadPatients();
  }, []);

  const loadPatients = async () => {
    const data = await getPatients();
    setPatients(data);
  };

  const handleDelete = async (id) => {
    await deletePatient(id);
    loadPatients();
  };

  const handleEdit = (patient) => {
    setSelectedPatient(patient);
    setShowEditModal(true);
  };

  const handleModalClose = () => {
    setShowEditModal(false);
    clearSelection(); // ✅ Reset selection
  };

  const clearSelection = () => {
    setTimeout(() => setSelectedPatient(null), 300); // ✅ Clears after modal animation
  };

  return (
    <div className="card p-4 mt-3">
      <h4 className="mb-3">Patients List</h4>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Name</th>
            <th>Tax Code</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {patients.map((patient) => (
            <tr key={patient.id}>
              <td>{patient.firstName} {patient.lastName}</td>
              <td>{patient.taxCode}</td>
              <td>{patient.email}</td>
              <td>{patient.phone}</td>
              <td>
                <button className="btn btn-warning btn-sm me-2" onClick={() => handleEdit(patient)}>Edit</button>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(patient.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedPatient && (
        <EditPatientModal show={showEditModal} onClose={handleModalClose} patient={selectedPatient} onPatientUpdated={loadPatients} />
      )}
    </div>
  );
};

export default PatientList;
