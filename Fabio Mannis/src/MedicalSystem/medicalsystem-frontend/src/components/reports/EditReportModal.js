import React, { useState, useEffect } from "react";
import { updateReport } from "../../api/reportService";
import { getDiagnoses } from "../../api/diagnosisService";

const EditReportModal = ({ show, onClose, report, onReportUpdated }) => {
  const [updatedReport, setUpdatedReport] = useState({ ...report });
  const [diagnoses, setDiagnoses] = useState([]);

  useEffect(() => {
    setUpdatedReport({ ...report });
    loadDiagnoses();
  }, [report]);

  const loadDiagnoses = async () => {
    const data = await getDiagnoses();
    setDiagnoses(data);
  };

  const handleChange = (e) => {
    setUpdatedReport({ ...updatedReport, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateReport(updatedReport.id, updatedReport);
    onReportUpdated();
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Edit Report</h5>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label className="form-label">Diagnosis</label>
                <select className="form-select" name="diagnosisId" value={updatedReport.diagnosisId} onChange={handleChange} required>
                  <option value="">Select Diagnosis</option>
                  {diagnoses.map((diagnosis) => (
                    <option key={diagnosis.id} value={diagnosis.id}>
                      {diagnosis.description}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">File Path</label>
                <input className="form-control" name="filePath" value={updatedReport.filePath} onChange={handleChange} required />
              </div>
              <button className="btn btn-primary w-100" type="submit">Save Changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditReportModal;
