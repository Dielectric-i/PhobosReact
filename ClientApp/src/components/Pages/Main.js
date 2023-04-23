import UpperPanel from '../UI/UpperPanel'
import CardsField from '../UI/CardsField';

const Main = () => {

    const title = 'APP'
    const apiEndpoints = ['section/'];
    const typeMappings = { // ������ � �������������� ����� � ����������
        'space/': 'Space',
        'section/': 'Section',
    };

    return (
        <div className='main'>
            <UpperPanel title={title} />
            {
                <CardsField typeMappings={typeMappings} apiEndpoints={apiEndpoints} />
            }
        </div>
    )
}
export default Main;