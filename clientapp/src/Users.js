// Users.js
import React, { useEffect, useState } from 'react';

function Users() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('https://my-app.free.beeceptor.com/users')
      .then(response => response.json())
      .then(data => setUsers(data))
      .catch(error => console.error('Erro ao buscar dados dos Users:', error));
  }, []);

  return (
    <div>
      <h1>Users</h1>
      {users.length > 0 ? (
        users.map((user, index) => (
          <div key={index}>
            <h2>{user.name}</h2>
            <p>{user.email}</p>
          </div>
        ))
      ) : (
        <p>Carregando...</p>
      )}
    </div>
  );
}

export default Users;