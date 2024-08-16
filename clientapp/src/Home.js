// Home.js
import React, { useEffect, useState } from 'react';

function Home() {
  const [data, setData] = useState(null);

  useEffect(() => {
    fetch('https://my-app.free.beeceptor.com/home')
      .then(response => response.json())
      .then(data => setData(data))
      .catch(error => console.error('Erro ao buscar dados da Home:', error));
  }, []);

  return (
    <div>
      <h1>Home</h1>
      {data ? (
        <pre>{JSON.stringify(data, null, 2)}</pre>
      ) : (
        <p>Carregando...</p>
      )}
    </div>
  );
}

export default Home;