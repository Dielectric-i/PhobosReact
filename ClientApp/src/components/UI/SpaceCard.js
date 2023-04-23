import { useNavigate } from 'react-router-dom';
import styles from './SpaceCard.module.css';
import CardsField from './CardsField';

const SpaceCard = ({ title, type, children }) =>
{
    const navigate = useNavigate();

    const handleCardClick = () => {
        navigate(`/Warehouse/Space/${title}`);
    };

    const handleButtonClick = (event) => {
        event.stopPropagation();
        console.log('Button clicked');
    }

    return (
        <div className={styles.card} onClick={handleCardClick}>
            <div className={styles.cardHeader}>
                    <h2>{title}</h2>
            </div>
            <div className={styles.cardContent}>
                {children && <CardsField cards={children} />}
                <button onClick={handleButtonClick}>SpaceCard</button>
            </div>
            <img className={styles.cardImage} src={`/Images/${type}/${title}.png`} alt="" />
        </div>
    )
}
export default SpaceCard;