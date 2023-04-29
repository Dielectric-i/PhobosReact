import { useNavigate } from 'react-router-dom';
import styles from './SectionCard.module.css';

const SectionCard = ({ entity}) =>
{
    const navigate = useNavigate();

    const handleCardClick = () => {
        navigate(`/${entity.name}`);
    };

    const handleButtonClick = (event) => {
        event.stopPropagation();
        console.log('Button clicked');
    }

    return (
        <div className={styles.card} onClick={handleCardClick}>
            <div className={styles.cardHeader}>
                <h2>{entity.name}</h2>
            </div>
            <div className={styles.cardContent}>
                <p>SectionCard </p>
                <button onClick={handleButtonClick}>button</button>
            </div>
            <img className={styles.cardImage} src={`/Images/${entity.name}.png`} alt="" />

        </div>
    )
}
export default SectionCard;