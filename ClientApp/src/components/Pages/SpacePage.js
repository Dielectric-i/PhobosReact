import React, { useEffect } from 'react';
import styles from './SpacePage.module.css';
import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { useLocation } from 'react-router-dom';



const SpacePage = () => {

    const location = useLocation();
    const spaceData = location.state?.spaceData;

    useEffect(() => { }, []);

    return (
        <div className={styles.spacePage}>
            <UpperPanel title={spaceData.name} />
            {
                <CardsField entities={spaceData.boxes} />
            }
        </div>
    );
};

export default SpacePage;
