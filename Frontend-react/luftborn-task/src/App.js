import "./App.css";
import { useState, useEffect } from "react";
import {
  addProduct,
  deleteProduct,
  editProduct,
  getProducts,
} from "./services/productService";

function App() {
  const [products, setProducts] = useState([]);
  const [editedProduct, setEditedProduct] = useState({
    id: 0,
    name: "",
    price: "",
    description: "",
  });

  const handleSubmit = async () => {
    const product = {
      ...editedProduct,
    };

    let isValid = false;

    if (editedProduct.id) {
      if (await editProduct(editedProduct.id, product)) {
        setProducts(
          products.map((p) =>
            p.id === editedProduct.id ? { ...p, ...product } : p
          )
        );
        isValid = true;
      }
    } else {
      const id = await addProduct(product);
      if (id) {
        setProducts([...products, { ...product, id }]);
        isValid = true;
      }
    }

    if (isValid)
      setEditedProduct({
        id: 0,
        name: "",
        price: "",
        description: "",
      });
  };

  const handleDelete = async (id) => {
    if (await deleteProduct(id))
      setProducts(products.filter((product) => product.id !== id));
  };

  const handleEdit = (product) => {
    setEditedProduct(product);
  };

  useEffect(() => {
    (async () => {
      setProducts((await getProducts()) ?? []);
    })();
  }, []);

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Product Management</h1>
      <form className="mb-4">
        <div className="mb-2">
          <label className="block text-gray-700">Product Name</label>
          <input
            type="text"
            value={editedProduct.name}
            onChange={(e) =>
              setEditedProduct({ ...editedProduct, name: e.target.value })
            }
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <div className="mb-2">
          <label className="block text-gray-700">Price</label>
          <input
            type="number"
            value={editedProduct.price}
            onChange={(e) =>
              setEditedProduct({
                ...editedProduct,
                price: e.target.value,
              })
            }
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <div className="mb-2">
          <label className="block text-gray-700">Description</label>
          <input
            type="text"
            value={editedProduct.description}
            onChange={(e) =>
              setEditedProduct({
                ...editedProduct,
                description: e.target.value,
              })
            }
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <button
          type="button"
          className="bg-blue-500 text-white p-2 rounded"
          onClick={handleSubmit}
        >
          Save
        </button>
      </form>
      <table className="min-w-full bg-white">
        <thead>
          <tr>
            <th className="py-2 px-4 border-b">Product Name</th>
            <th className="py-2 px-4 border-b">Price</th>
            <th className="py-2 px-4 border-b">Description</th>
            <th className="py-2 px-4 border-b">Actions</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product) => (
            <tr key={product.id}>
              <td className="py-2 px-4 border-b">{product.name}</td>
              <td className="py-2 px-4 border-b">{product.price}</td>
              <td className="py-2 px-4 border-b">{product.description}</td>
              <td className="py-2 px-4 border-b">
                <button
                  className="bg-yellow-500 text-white p-1 rounded mr-2"
                  onClick={() => handleEdit(product)}
                >
                  Edit
                </button>
                <button
                  className="bg-red-500 text-white p-1 rounded"
                  onClick={() => handleDelete(product.id)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
