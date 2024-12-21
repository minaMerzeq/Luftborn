import axios from "axios";

const api = "http://localhost:7008/api/Products";

export const getProducts = async () => {
  try {
    return (await axios.get(api)).data;
  } catch (error) {
    console.log(error);
  }
};

export const getProduct = async (id) => {
  try {
    return (await axios.get(`${api}/${id}`)).data;
  } catch (error) {
    console.log(error);
  }
};

export const addProduct = async (product) => {
  try {
    return (await axios.post(api, product)).data;
  } catch (error) {
    console.log(error);
  }
};

export const editProduct = async (id, product) => {
  try {
    return (await axios.put(`${api}/${id}`, product)).data;
  } catch (error) {
    console.log(error);
  }
};

export const deleteProduct = async (id) => {
  try {
    return (await axios.delete(`${api}/${id}`)).data;
  } catch (error) {
    console.log(error);
  }
};
