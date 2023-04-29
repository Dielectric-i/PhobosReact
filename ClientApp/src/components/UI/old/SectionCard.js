import { useNavigate } from 'react-router-dom';
import styles from './SectionCard.module.css';

const SectionCard = ({ card}) =>
{
    const navigate = useNavigate();

    const handleCardClick = () => {
        navigate(`/${card.name}`);
    };

    const handleButtonClick = (event) => {
        event.stopPropagation();
        console.log('Button clicked');
    }

    return (
        <div className={styles.card} onClick={handleCardClick}>
            <div className={styles.cardHeader}>
                <h2>{card.name}</h2>
            </div>
            <div className={styles.cardContent}>
                <p>SectionCard </p>
                <button onClick={handleButtonClick}>button</button>
            </div>
            <img className={styles.cardImage} src={`/Images/${card.name}.png`} alt="" />

        </div>
    )
}
export default SectionCard;