import SectionCard from './SectionCard';
import JustCard from './JustCard';
import styles from './CardsField.module.css'
import CreateEntityCard from './CreateEntityCard ';



const CardsField = ({ entities, createEntityesForm }) => {
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
            {Cards}
            {createEntityesForm && <CreateEntityCard createEntityesForm={createEntityesForm} />}
        </div>
    )
}
export default CardsField;