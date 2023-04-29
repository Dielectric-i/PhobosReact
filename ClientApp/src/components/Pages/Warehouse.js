import React, { useState, useEffect } from 'react';
import styles from './Warehouse.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { getDataFromApi } from '../Share/Data/Api';
import CreateSpaceForm from '../UI/Forms/CreateSpaceForm';

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
                <CardsField entities={entities} createEntityesForm={<CreateSpaceForm />} />
            }
        </div>
    );
};

export default Warehouse;
