import React, { useState, useEffect } from 'react';
import styles from './SpacePage.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { useParams } from 'react-router-dom';
import typeMappings from '../Share/typeMappings'


const SpacePages = () => {
    const { spaceName } = useParams();
    const title = spaceName

    const apiEndpoints = ['space/'];
   /* const typeMappings = { // Объект с соответствиями типов и эндпоинтов
        '/api/section/GetAllSections': 'Space',
        '/api/space/GetAllSpaces': 'Section',
        '/api/box/GetAllBoxes': 'Box',
    };*/
   
    return (
        <div className={styles.spacePage}>
            <UpperPanel title={title} />
            {
                <CardsField typeMappings={typeMappings} apiEndpoints={apiEndpoints } />
            }
        </div>
    );
};

export default SpacePages;
