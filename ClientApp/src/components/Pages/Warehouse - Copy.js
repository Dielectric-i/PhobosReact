import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../../UI/UpperPanel'
import CardsField from '../../UI/CardsField';

const Warehouse = () => {

    const title = "Warehouse";

    const [spaces, setSpaces] = useState(null);
    const [sections, setSections] = useState(null);
    const [cards, setCards] = useState([]);

    useEffect(() => {
        getDataFromApi();
    }, []);

    function getDataFromApi() {
        Promise.all([
            fetch(`space/`).then(res => res.json()),
            fetch(`section/`).then(res => res.json())
        ])
            .then(([spacesData, sectionsData]) => {
                setSpaces(spacesData);
                setSections(sectionsData);
                // Объединяем данные в cards
                let updatedCards = [
                    ...spacesData.map(space => ({ ...space, type: 'Space' })),
                    ...sectionsData.map(section => ({ ...section, type: 'Section' }))
                ];
                setCards(updatedCards);
            })
            .catch((error) => {
                console.error('Ошибка при получении данных:', error);
            });
    }

    return (
        <div className={styles.warehouse}>
            <UpperPanel title={title} />
            {
                cards && <CardsField cards={cards} />
            }
        </div>
    );
};

export default Warehouse;
