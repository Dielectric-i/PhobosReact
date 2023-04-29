import { useNavigate } from 'react-router-dom';
import styles from './SpaceCard.module.css';
import CardsField from './CardsField';
import { Link } from 'react-router-dom';

const SpaceCard = ({ card }) =>
{

    const handleButtonClick = (event) => {
        event.stopPropagation();
        console.log('Button clicked');
    }


    return (
        <Link to={`/Warehouse/Space/${card.name}`} state={{ spaceData: card }}>
            <div className={styles.card}>
                <div className={styles.cardHeader}>
                    <h2>{card.name}</h2>
                </div>
                <div className={styles.cardContent}>
                    {card.Boxes && <CardsField cards={card.Boxes} />}
                    <button onClick={handleButtonClick}>SpaceCard</button>
                </div>
                <img className={styles.cardImage} src={`/Images/Space/Other/Warehouse.png`} alt="" />
            </div>
        </Link>
    )
}
export default SpaceCard;