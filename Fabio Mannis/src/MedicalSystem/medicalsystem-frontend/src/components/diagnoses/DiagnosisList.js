import React, { useEffect, useState } from "react";
import { getDiagnoses, deleteDiagnosis } from "../../api/diagnosisService";
import { getAppointments } from "../../api/appointmentService";
import EditDiagnosisModal from "./EditDiagnosisModal";

const DiagnosisList = () => {
  const [diagnoses, setDiagnoses] = useState([]);
  const [appointments, setAppointments] = useState([]);
  const [selectedDiagnosis, setSelectedDiagnosis] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadDiagnoses();
    loadAppointments();
  }, []);

  const loadDiagnoses = async () => {
    const data = await getDiagnoses();
    setDiagnoses(data);
  };

  const loadAppointments = async () => {
    const data = await getAppointments();
    setAppointments(data);
  };

  const handleDelete = async (id) => {
    await deleteDiagnosis(id);
    loadDiagnoses();
  };

  const handleEdit = (diagnosis) => {
    setSelectedDiagnosis(diagnosis);
    setShowEditModal(true);
  };

  const handleModalClose = () => {
    setShowEditModal(false);
    clearSelection();
  };

  const clearSelection = () => {
    setTimeout(() => setSelectedDiagnosis(null), 300);
  };

  const getAppointmentDetails = (appointmentId) => {
    const appointment = appointments.find(a => a.id === appointmentId);
    return appointment ? `Patient: ${appointment.patientId}, Date: ${new Date(appointment.dateTime).toLocaleString()}` : "Unknown";
  };

  return (
    <div className="card p-4 mt-3">
      <h4 className="mb-3">Diagnoses List</h4>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Appointment</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {diagnoses.map((diagnosis) => (
            <tr key={diagnosis.id}>
              <td>{getAppointmentDetails(diagnosis.appointmentId)}</td>
              <td>{diagnosis.description}</td>
              <td>
                <button className="btn btn-warning btn-sm me-2" onClick={() => handleEdit(diagnosis)}>Edit</button>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(diagnosis.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedDiagnosis && (
        <EditDiagnosisModal show={showEditModal} onClose={handleModalClose} diagnosis={selectedDiagnosis} onDiagnosisUpdated={loadDiagnoses} />
      )}
    </div>
  );
};

export default DiagnosisList;
