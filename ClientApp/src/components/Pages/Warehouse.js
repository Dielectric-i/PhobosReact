import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';

const Warehouse = () => {

    const title = "Warehouse";
    const apiEndpoints = ['space/'];
    const typeMappings = { // ������ � �������������� ����� � ����������
        'space/': 'Space',
        'section/': 'Section',
        'box/': 'Box',
    };
   
    return (
        <div className={styles.warehouse}>
            <UpperPanel title={title} />
            {
                <CardsField typeMappings={typeMappings} apiEndpoints={apiEndpoints } />
            }
        </div>
    );
};

export default Warehouse;
