import React, { useState, useEffect } from "react";
import { addReport } from "../../api/reportService";
import { getDiagnoses } from "../../api/diagnosisService";

const ReportForm = ({ onReportAdded }) => {
  const [report, setReport] = useState({
    diagnosisId: "",
    filePath: "",
  });

  const [diagnoses, setDiagnoses] = useState([]);

  useEffect(() => {
    loadDiagnoses();
  }, []);

  const loadDiagnoses = async () => {
    const data = await getDiagnoses();
    setDiagnoses(data);
  };

  const handleChange = (e) => {
    setReport({ ...report, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await addReport(report);
    onReportAdded();
    clearSelection();
  };

  const clearSelection = () => {
    setReport({
      diagnosisId: "",
      filePath: "",
    });
  };

  return (
    <div className="card p-4">
      <h4 className="mb-3">Add Report</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <select className="form-select" name="diagnosisId" value={report.diagnosisId} onChange={handleChange} required>
            <option value="">Select Diagnosis</option>
            {diagnoses.map((diagnosis) => (
              <option key={diagnosis.id} value={diagnosis.id}>
                {diagnosis.description}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-3">
          <input className="form-control" name="filePath" value={report.filePath} onChange={handleChange} placeholder="Report File Path" required />
        </div>
        <button className="btn btn-primary w-100" type="submit">Add Report</button>
      </form>
    </div>
  );
};

export default ReportForm;
