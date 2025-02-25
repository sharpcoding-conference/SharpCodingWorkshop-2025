import React, { useState } from "react";
import ReportList from "../components/reports/ReportList";
import ReportForm from "../components/reports/ReportForm";

const ReportsPage = () => {
  const [refresh, setRefresh] = useState(false);

  const handleRefresh = () => setRefresh(!refresh);

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">Reports Management</h1>
      <div className="row">
        <div className="col-md-4">
          <ReportForm onReportAdded={handleRefresh} />
        </div>
        <div className="col-md-8">
          <ReportList key={refresh} />
        </div>
      </div>
    </div>
  );
};

export default ReportsPage;
