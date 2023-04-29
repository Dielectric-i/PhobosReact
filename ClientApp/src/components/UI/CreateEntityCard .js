import styles from './JustCard.module.css';

const CreateEntityCard = ({ createEntityesForm }) =>
{

    return (
            <div className={styles.card}>
                <div className={styles.cardHeader}>
                    <h2>Create</h2>
                {createEntityesForm}
                </div>
            </div>
    )
}
export default CreateEntityCard;