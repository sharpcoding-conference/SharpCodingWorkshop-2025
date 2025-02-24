import React, { useEffect, useState } from "react";
import { getAppointments, deleteAppointment } from "../../api/appointmentService";
import EditAppointmentModal from "./EditAppointmentModal";

const AppointmentList = () => {
  const [appointments, setAppointments] = useState([]);
  const [selectedAppointment, setSelectedAppointment] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadAppointments();
  }, []);

  const loadAppointments = async () => {
    const data = await getAppointments();
    setAppointments(data);
  };

  const handleDelete = async (id) => {
    await deleteAppointment(id);
    loadAppointments();
  };

  const handleEdit = (appointment) => {
    setSelectedAppointment(appointment);
    setShowEditModal(true);
  };

  const handleModalClose = () => {
    setShowEditModal(false);
    setSelectedAppointment(null);
  };

  return (
    <div className="card p-4 mt-3">
      <h4 className="mb-3">Appointments List</h4>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Patient ID</th>
            <th>Doctor ID</th>
            <th>Date & Time</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {appointments.map((appointment) => (
            <tr key={appointment.id}>
              <td>{appointment.patientId}</td>
              <td>{appointment.doctorId}</td>
              <td>{new Date(appointment.dateTime).toLocaleString()}</td>
              <td>
                <span className={`badge ${appointment.status === "Completed" ? "bg-success" : appointment.status === "Canceled" ? "bg-danger" : "bg-warning"}`}>
                  {appointment.status}
                </span>
              </td>
              <td>
                <button className="btn btn-warning btn-sm me-2" onClick={() => handleEdit(appointment)}>Edit</button>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(appointment.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedAppointment && (
        <EditAppointmentModal show={showEditModal} onClose={handleModalClose} appointment={selectedAppointment} onAppointmentUpdated={loadAppointments} />
      )}
    </div>
  );
};

export default AppointmentList;
