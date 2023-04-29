import styles from './JustCard.module.css';

const JustCard = ({ card }) =>
{

    return (
        <div className={styles.card}>
            <div className={styles.cardHeader}>
                <h2>{card.name}</h2>
            </div>
        </div>
    )
}
export default JustCard;