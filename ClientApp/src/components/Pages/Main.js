import { useEffect, useState } from 'react';
import { getDataFromApi } from '../Share/Data/Api';
import CardsField from '../UI/CardsField';
import UpperPanel from '../UI/UpperPanel';

const Main = () => {

    //
    const title = 'APP'


    // Get data from api

    const apiEndpoints = ['/api/section/GetAllSections'];
    const [entities, setEntities] = useState([]);

    useEffect(() => { getDataFromApi(apiEndpoints, setEntities) }, []);


    return (
        <div className='main'>
            <UpperPanel title={title} />
            {
                <CardsField entities={entities} />
            }
        </div>
    )
}
export default Main;