import React, { useEffect, useState } from "react";
import { getReports, deleteReport } from "../../api/reportService";
import { getDiagnoses } from "../../api/diagnosisService";
import EditReportModal from "./EditReportModal";

const ReportList = () => {
  const [reports, setReports] = useState([]);
  const [diagnoses, setDiagnoses] = useState([]);
  const [selectedReport, setSelectedReport] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadReports();
    loadDiagnoses();
  }, []);

  const loadReports = async () => {
    const data = await getReports();
    setReports(data);
  };

  const loadDiagnoses = async () => {
    const data = await getDiagnoses();
    setDiagnoses(data);
  };

  const handleDelete = async (id) => {
    await deleteReport(id);
    loadReports();
  };

  const handleEdit = (report) => {
    setSelectedReport(report);
    setShowEditModal(true);
  };

  const handleModalClose = () => {
    setShowEditModal(false);
    setTimeout(() => setSelectedReport(null), 300);
  };

  const getDiagnosisDescription = (diagnosisId) => {
    const diagnosis = diagnoses.find(d => d.id === diagnosisId);
    return diagnosis ? diagnosis.description : "Unknown";
  };

  return (
    <div className="card p-4 mt-3">
      <h4 className="mb-3">Reports List</h4>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Diagnosis</th>
            <th>File Path</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {reports.map((report) => (
            <tr key={report.id}>
              <td>{getDiagnosisDescription(report.diagnosisId)}</td>
              <td>{report.filePath}</td>
              <td>
                <button className="btn btn-warning btn-sm me-2" onClick={() => handleEdit(report)}>Edit</button>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(report.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {selectedReport && (
        <EditReportModal show={showEditModal} onClose={handleModalClose} report={selectedReport} onReportUpdated={loadReports} />
      )}
    </div>
  );
};

export default ReportList;
