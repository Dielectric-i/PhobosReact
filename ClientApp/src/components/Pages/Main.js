import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';

const Main = () => {

    const title = 'APP'
    const apiEndpoints = ['/api/section/GetAllSections'];

    return (
        <div className='main'>
            <UpperPanel title={title} />
            {
                <CardsField apiEndpoints={apiEndpoints} />
            }
        </div>
    )
}
export default Main;