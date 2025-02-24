import React from "react";
import AppRoutes from "./routes";
import Navbar from "./components/Navbar"; // Import Navbar
import "bootstrap/dist/css/bootstrap.min.css";

const App = () => {
  return (
    <div>
      <Navbar />
      <div className="container">
        <AppRoutes />
      </div>
    </div>
  );
};

export default App;
