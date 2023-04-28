import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import typeMappings from '../Share/typeMappings';

const Warehouse = () => {

    const title = "Warehouse";


    // Get data from api
    useEffect(() => { getDataFromApi(); }, []);

    const apiEndpoints = ['/api/space/GetAllSpaces'];
    const [cards, setCards] = useState([]);
    const [selectedSpace, setSelectedSpace] = useState(null);

    function getDataFromApi() {

        const fetchPromises = apiEndpoints.map(endpoint =>  // Массив промисов вызова эндпойнта
            fetch(endpoint)
                .then(res => res.json())
                .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // Добавляем type каждому полученному объекту.  По названию эндпойнта идентифицируем тип объекта
        );

        Promise.all(fetchPromises).
            then(results => {
                const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //Сшиваем все объекты и получаем подготовленый массив для вывода карточек
                setCards(mergetCards);
            })
    }

    return (
        <div className={styles.warehouse}>
            <UpperPanel title={title} />
            {
                <CardsField cards={cards } />
            }
        </div>
    );
};

export default Warehouse;
