import axios from 'axios';

const API_URL = 'http://localhost:5001/api/Patients'; // Modifica l'URL se necessario

// Funzione per ottenere tutti i pazienti
export const getPatients = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        console.error("Errore nel recupero dei pazienti", error);
        throw error;
    }
};

// Funzione per ottenere un paziente per ID
export const getPatientById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    } catch (error) {
        console.error("Errore nel recupero del paziente", error);
        throw error;
    }
};

// Funzione per aggiungere un nuovo paziente
export const createPatient = async (patient) => {
    try {
        const response = await axios.post(API_URL, patient);
        return response.data;
    } catch (error) {
        console.error("Errore nell'aggiungere il paziente", error);
        throw error;
    }
};

// Funzione per aggiornare un paziente
export const updatePatient = async (id, patient) => {
    try {
        const response = await axios.put(`${API_URL}/${id}`, patient);
        return response.data;
    } catch (error) {
        console.error("Errore nell'aggiornare il paziente", error);
        throw error;
    }
};

// Funzione per eliminare un paziente
export const deletePatient = async (id) => {
    try {
        await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
        console.error("Errore nell'eliminare il paziente", error);
        throw error;
    }
};
