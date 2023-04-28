import SectionCard from './SectionCard';
import SpaceCard from './SpaceCard';
import JustCard from './JustCard';
import styles from './CardsField.module.css'



const CardsField = ({ cards }) => {

    // �������� �������� � ����������� �� ���� �������
    const Cards = cards && cards.map((card) => {

        const actions = {
            Section: SectionCard,
            Space:  SpaceCard,
        };
        if (actions.hasOwnProperty(card.type)) {
            const CardComponent = actions[card.type];
            return <CardComponent key={card.id} card={card} />;
        } else {
            return <JustCard card={card} />
        }
    });


    return (
        <div className={styles.cardsField}>
            {Cards}
        </div>
    )
}
export default CardsField;