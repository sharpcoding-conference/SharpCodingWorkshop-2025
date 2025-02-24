import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter as Router } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

// Creiamo la root dell'applicazione
const root = ReactDOM.createRoot(document.getElementById('root'));

// Rendering dell'app con il Router per la gestione delle rotte
root.render(
    <App />
);
