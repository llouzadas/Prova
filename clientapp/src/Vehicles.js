// Vehicles.js
import React, { useEffect, useState } from 'react';

function Vehicles() {
  const [vehicles, setVehicles] = useState([]);

  useEffect(() => {
    fetch('https://my-app.free.beeceptor.com/vehicles')
      .then(response => response.json())
      .then(data => setVehicles(data))
      .catch(error => console.error('Erro ao buscar dados dos Vehicles:', error));
  }, []);

  return (
    <div>
      <h1>Vehicles</h1>
      {vehicles.length > 0 ? (
        vehicles.map((vehicle, index) => (
          <div key={index}>
            <h2>{vehicle.name}</h2>
            <p>{vehicle.description}</p>
          </div>
        ))
      ) : (
        <p>Carregando...</p>
      )}
    </div>
  );
}

export default Vehicles;