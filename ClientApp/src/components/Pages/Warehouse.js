import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { getDataFromApi } from '../Share/Data/Api';

const Warehouse = () => {

    const title = "Warehouse";


    // Get data from api
    const apiEndpoints = ['/api/space/GetAllSpaces'];
    const [entities, setEntities] = useState([]);

    useEffect(() => { getDataFromApi(apiEndpoints, setEntities); }, []);


    return (
        <div className={styles.warehouse}>
            <UpperPanel title={title} />
            {
                <CardsField entities={entities } />
            }
        </div>
    );
};

export default Warehouse;
