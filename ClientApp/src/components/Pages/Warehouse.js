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
        const typeMappings = { // ������ � �������������� ����� � ����������
            'space/': 'SpaceCard',
            'section/': 'SectionCard',
        };

        const fetchPromises = apiEndpoints.map(endpoint =>  // ������ �������� ������ ���������
            fetch(endpoint)
                .then(res => res.json())
                .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // ��������� type ������� ����������� �������.  �� �������� ��������� �������������� ��� �������
        );

        Promise.all(fetchPromises).
            then(results => {
            const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //������� ��� �������� � �������� ������������� ������ ��� ������ ��������
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
