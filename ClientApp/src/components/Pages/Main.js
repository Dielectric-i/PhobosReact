import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';
import { useEffect, useState } from 'react';
import typeMappings from '../Share/typeMappings';

const Main = () => {

    //
    const title = 'APP'


    // Get data from api
    useEffect(() => { getDataFromApi() }, []);

    const apiEndpoints = ['/api/section/GetAllSections'];
    const [cards, setCards] = useState([]);


    function getDataFromApi() {

        const fetchPromises = apiEndpoints.map(endpoint =>  // ������ �������� ������ ���������
            fetch(endpoint)
                .then(res => res.json())
                .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // ��������� type ������� ����������� �������.  �� �������� ��������� �������������� ��� �������
        );

        Promise.all(fetchPromises).
            then(results => {
                const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //������� ��� ������� � �������� ������������� ������ ��� ������ ��������
                setCards(mergetCards);
            })
    }



    return (
        <div className='main'>
            <UpperPanel title={title} />
            {
                <CardsField cards={cards} />
            }
        </div>
    )
}
export default Main;