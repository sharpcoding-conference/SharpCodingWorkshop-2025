import axios from 'axios';

const API_URL = 'http://localhost:5001/api/doctors'; // URL del backend

// 🔹 Recupera tutti i dottori
export const getDoctors = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Errore nel recupero dei dottori:', error);
    throw error;
  }
};

// 🔹 Recupera un dottore per ID
export const getDoctorById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Errore nel recupero del dottore con ID ${id}:`, error);
    throw error;
  }
};

// 🔹 Aggiunge un nuovo dottore
export const addDoctor = async (doctor) => {
  try {
    const response = await axios.post(API_URL, doctor);
    return response.data;
  } catch (error) {
    console.error('Errore nell\'aggiunta del dottore:', error);
    throw error;
  }
};

// 🔹 Aggiorna un dottore esistente
export const updateDoctor = async (id, doctor) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, doctor);
    return response.data;
  } catch (error) {
    console.error(`Errore nell'aggiornamento del dottore con ID ${id}:`, error);
    throw error;
  }
};

// 🔹 Cancella un dottore per ID
export const deleteDoctor = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Errore nella cancellazione del dottore con ID ${id}:`, error);
    throw error;
  }
};
