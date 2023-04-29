import SectionCard from './SectionCard';
import SpaceCard from './SpaceCard';
import JustCard from './JustCard';
import styles from './CardsField.module.css'



const CardsField = ({ entities }) => {
    const Cards = entities && entities.map((entity) => {

        const actions = {
            Section: SectionCard,
            Space: JustCard,
        };
        if (actions.hasOwnProperty(entity.type)) {
            const CardComponent = actions[entity.type];
            return <CardComponent key={entity.id} entity={entity} />;
        } else {
            return <JustCard key={entity.id} entity={entity} />
        }
    });

    return (
        <div className={styles.cardsField}>
            {Cards} <JustCard key="123" entity='' />
        </div>
    )
}
export default CardsField;