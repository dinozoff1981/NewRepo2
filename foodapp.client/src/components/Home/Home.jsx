import React, { useState, useEffect } from 'react';
import axios from 'axios';

function Home() {
    const [drinks, setDrinks] = useState('');
    const [loading, setLoading] = useState(true);

    const fetchDrinks = async () => {
        try {
            setLoading(true); 
            const response = await axios.post('https://localhost:7195/OpenAi/Drinks');
            setDrinks(response.data);
            setLoading(false);
        } catch (error) {
            console.error('Error fetching Cities:', error);
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchDrinks(); 
    }, []);

    const handleRefresh = () => {
        fetchDrinks(); 
    };

    return (
        <div>
            <h1>TRAVEL INFO</h1>
            <p>History</p>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <div>
                    <p>{drinks}</p>
                    <button onClick={handleRefresh}>Refresh</button> 
                </div>
            )}
        </div>
    );
}

export default Home;
