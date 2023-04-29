import styles from './JustCard.module.css';
import { Link } from 'react-router-dom';

const JustCard = ({ entity }) =>
{

    return (
        <Link to={`${entity.type}/${entity.name}`} state={{ spaceData: entity }}>
            <div className={styles.card}>
                <div className={styles.cardHeader}>
                    <h2>{entity.name}</h2>
                </div>
            </div>
        </Link>
    )
}
export default JustCard;