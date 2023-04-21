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
            setCards(data); // ��������� ������ � ��������� ����������
        })
        .catch((error) => {
            console.error('������ ��� ��������� ������:', error);
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