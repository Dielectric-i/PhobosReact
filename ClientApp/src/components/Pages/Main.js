import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { useState, useEffect } from 'react';

const Main = () => {
    const [cards, setCards] = useState(null);

    useEffect(() => {
        getDataFromApi()
    }, [])

    function getDataFromApi() {
    fetch(`section/`)
        .then((results) => {
            return results.json();
        })
        .then((data) => {
            setCards(data); // сохраняем данные в состоянии компонента
        })
        .catch((error) => {
            console.error('Ошибка при получении данных:', error);
        });
    }
    return (
        <div className="main">
            <UpperPanel title={ "APP"} />
            {
                cards && <CardsField cards={cards} />
            }
        </div>
    )
}
export default Main;