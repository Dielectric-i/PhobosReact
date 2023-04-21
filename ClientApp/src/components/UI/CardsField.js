import SectionCard from './SectionCard';
import SpaceCard from './SpaceCard';
import styles from './CardsField.module.css'

const CardsField = ({ cards }) => {

    //������������� ������ ��� �������� ��� ���������

    const Cards = cards && cards.map((card) => {        //Cards - ��� �������� � ����������� React

        const actions = {
            Section: SectionCard,
            Space:  SpaceCard,
        };

        const type = card.type;

        if (actions.hasOwnProperty(type)) {
            const CardComponent = actions[type]; // ����������� �������� 
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