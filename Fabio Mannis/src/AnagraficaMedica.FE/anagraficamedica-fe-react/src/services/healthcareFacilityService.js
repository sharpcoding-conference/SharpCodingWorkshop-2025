import axios from 'axios';

const API_URL = 'http://localhost:5001/api/HealthcareFacility'; // Modifica l'URL se necessario

// Funzione per ottenere tutte le strutture sanitarie
export const getHealthcareFacilities = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        console.error("Errore nel recupero delle strutture sanitarie", error);
        throw error;
    }
};

// Funzione per ottenere una struttura sanitaria per ID
export const getHealthcareFacilityById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    } catch (error) {
        console.error("Errore nel recupero della struttura sanitaria", error);
        throw error;
    }
};

// Funzione per aggiungere una nuova struttura sanitaria
export const createHealthcareFacility = async (facility) => {
    try {
        const response = await axios.post(API_URL, facility);
        return response.data;
    } catch (error) {
        console.error("Errore nell'aggiungere la struttura sanitaria", error);
        throw error;
    }
};

// Funzione per aggiornare una struttura sanitaria
export const updateHealthcareFacility = async (id, facility) => {
    try {
        const response = await axios.put(`${API_URL}/${id}`, facility);
        return response.data;
    } catch (error) {
        console.error("Errore nell'aggiornare la struttura sanitaria", error);
        throw error;
    }
};

// Funzione per eliminare una struttura sanitaria
export const deleteHealthcareFacility = async (id) => {
    try {
        await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
        console.error("Errore nell'eliminare la struttura sanitaria", error);
        throw error;
    }
};
