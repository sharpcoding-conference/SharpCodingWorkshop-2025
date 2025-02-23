import axios from 'axios';

const API_URL = 'http://localhost:5001/api/patients';

export const getPatients = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Errore nel recupero dei pazienti:', error);
    throw error;
  }
};

export const addPatient = async (patient) => {
  try {
    const response = await axios.post(API_URL, patient);
    return response.data;
  } catch (error) {
    console.error('Errore nell\'aggiunta del paziente:', error);
    throw error;
  }
};
