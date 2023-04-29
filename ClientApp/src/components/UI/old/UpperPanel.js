import styles from './UpperPanel.module.css'
import { useNavigate } from 'react-router-dom';

const UpperPanel = ({ title }) => {

    const navigate = useNavigate();

    const handleLogoClick = () => {
        navigate(`/`);
    };

    const handleTitleClick = () => {
        navigate(`/${title }`);
    };
    return (

        <div className={styles.UpperPanel}>
            <div className={styles.logo} onClick={handleLogoClick} >
                <img src='/Images/Phobos_logo.jpg' alt="" />
                <h1>PHOBOS</h1>
            </div>
            <div className={styles.separator}>
                <h2>/</h2>
            </div>
            <div className={styles.title} onClick={handleTitleClick}>
                <h2>{title}</h2>
            </div>
        </div>

    )
}
    export default UpperPanel;