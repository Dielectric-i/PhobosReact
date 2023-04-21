import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';

const Warehouse = () => {

    const title = "Warehouse";

    const [cards, setCards] = useState([]);

    useEffect(() => {
        getDataFromApi();
    }, []);

    function getDataFromApi() {
        const apiEndpoints = ['space/', 'section/'];
        const typeMappings = { // Объект с соответствиями типов и эндпоинтов
            'space/': 'SpaceCard',
            'section/': 'SectionCard',
        };

        const fetchPromises = apiEndpoints.map(endpoint =>  // Массив промисов вызова эндпойнта
            fetch(endpoint)
                .then(res => res.json())
                .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // Добавляем type каждому полученному объекту.  По названию эндпойнта идентифицируем тип объекта
        );

        Promise.all(fetchPromises).
            then(results => {
            const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //Сшиваем все оббъекты и получаем подготовленый массив для вывода карточек
            setCards(mergetCards);
        })
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
