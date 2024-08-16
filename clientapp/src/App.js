import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './Home';
import Vehicles from './Vehicles';
import FreightList from './components/FreightList';  // Ajustado para o caminho correto
import Users from './Users';
import './App.css';  // Certifique-se de que o arquivo App.css existe na pasta src

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/vehicles" element={<Vehicles />} />
        <Route path="/freights" element={<FreightList />} />  {/* Usando FreightList */}
        <Route path="/users" element={<Users />} />
      </Routes>
    </Router>
  );
}

export default App;