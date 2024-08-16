import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './FreightList.css';  // Importando o CSS

const FreightList = () => {
    const [freights, setFreights] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5000/api/freights')
            .then(response => {
                setFreights(response.data);
            })
            .catch(error => {
                console.error("There was an error fetching the freights!", error);
            });
    }, []);

    return (
        <div className="freight-list">
            {freights.map(freight => (
                <div key={freight.id} className="freight-item">
                    <h3>{freight.name}</h3>
                    <p>Distance: {freight.distance} km</p>
                    <p>Price: ${freight.finalPrice}</p>
                </div>
            ))}
        </div>
    );
};

export default FreightList;