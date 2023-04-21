import SectionCard from './SectionCard';
import SpaceCard from './SpaceCard';
import styles from './CardsField.module.css'

const CardsField = ({ cards }) => {

    //Устанавливаем нужный тип карточки для элементов

    const Cards = cards && cards.map((card) => {        //Cards - все карточки в компонентах React

        const actions = {
            Section: SectionCard,
            Space:  SpaceCard,
        };

        const type = card.type;

        if (actions.hasOwnProperty(type)) {
            const CardComponent = actions[type]; // Присваиваем действие 
            return <CardComponent key={card.id} title={card.name} type={card.type} children={""} />;
        } else {
            console.log('Действие по умолчанию');
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