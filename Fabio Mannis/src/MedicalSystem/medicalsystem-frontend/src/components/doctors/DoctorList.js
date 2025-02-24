import React, { useEffect, useState } from "react";
import { getDoctors, deleteDoctor } from "../../api/doctorService";
import EditDoctorModal from "./EditDoctorModal";

const DoctorList = () => {
  const [doctors, setDoctors] = useState([]);
  const [selectedDoctor, setSelectedDoctor] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadDoctors();
  }, []);

  const loadDoctors = async () => {
    const data = await getDoctors();
    setDoctors(data);
  };

  const handleDelete = async (id) => {
    await deleteDoctor(id);
    loadDoctors();
  };

  const handleEdit = (doctor) => {
    setSelectedDoctor(doctor);
    setShowEditModal(true);
  };

  const handleModalClose = () => {
    setShowEditModal(false);
    setSelectedDoctor(null);
  };

  return (
    <div className="card p-4 mt-3">
      <h4 className="mb-3">Doctors List</h4>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Name</th>
            <th>Specialization</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Facility ID</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {doctors.map((doctor) => (
            <tr key={doctor.id}>
              <td>{doctor.firstName} {doctor.lastName}</td>
              <td>{doctor.specialization}</td>
              <td>{doctor.email}</td>
              <td>{doctor.phone}</td>
              <td>{doctor.medicalFacilityId}</td>
              <td>
                <button className="btn btn-warning btn-sm me-2" onClick={() => handleEdit(doctor)}>Edit</button>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(doctor.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedDoctor && (
        <EditDoctorModal show={showEditModal} onClose={handleModalClose} doctor={selectedDoctor} onDoctorUpdated={loadDoctors} />
      )}
    </div>
  );
};

export default DoctorList;
