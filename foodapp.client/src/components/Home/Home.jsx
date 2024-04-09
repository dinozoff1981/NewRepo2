import  { useState, useEffect } from 'react';
import axios from 'axios';

function Home() {
    const [drinks, setDrinks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const fetchDrinks = async () => {
        try {
            setLoading(true);
            const response = await axios.post('https://localhost:7195/OpenAi/Drinks');
            setDrinks(response.data);
            setLoading(false);
        } catch (error) {
            console.error('Error fetching foods:', error);
            setError('An error occurred while fetching foods.');
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
            <h1>Drinks</h1>
            <p>Sweden</p>
            {error && <p>{error}</p>}
            {loading ? (
                <p>Loading...</p>
            ) : (
                <div>
                    {drinks.map((drink, index) => (
                        <p key={index}>{drink}</p>
                    ))}
                    <button onClick={handleRefresh}>Refresh</button>
                </div>
            )}
        </div>
    );
}

export default Home;
