import SectionCard from './SectionCard';
import SpaceCard from './SpaceCard';
import styles from './CardsField.module.css'
import { useEffect, useState } from 'react'
import typeMappings from '../Share/typeMappings'

const CardsField = ({ apiEndpoints }) => {

    useEffect(() => { getDataFromApi(); }, []);

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

    const Cards = cards && cards.map((card) => {

        const actions = {
            Section: SectionCard,
            Space:  SpaceCard,
        };
        if (actions.hasOwnProperty(card.type)) {
            const CardComponent = actions[card.type];
            return <CardComponent key={card.id} title={card.name} type={card.type} children={""} />;
        } else {
            console.log('�������� �� ���������');
            return <div>Default action</div>
        }

    });


    return (
        <div className={styles.cardsField}>
            {Cards}
        </div>
    )
}
export default CardsField;