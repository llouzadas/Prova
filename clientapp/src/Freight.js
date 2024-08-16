// Freight.js
import React, { useEffect, useState } from 'react';

function Freight() {
  const [freights, setFreights] = useState([]);

  useEffect(() => {
    fetch('https://my-app.free.beeceptor.com/freight')
      .then(response => response.json())
      .then(data => setFreights(data))
      .catch(error => console.error('Erro ao buscar dados dos Freights:', error));
  }, []);

  return (
    <div>
      <h1>Freight</h1>
      {freights.length > 0 ? (
        freights.map((freight, index) => (
          <div key={index}>
            <h2>{freight.name}</h2>
            <p>{freight.description}</p>
          </div>
        ))
      ) : (
        <p>Carregando...</p>
      )}
    </div>
  );
}

export default Freight;