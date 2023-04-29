import typeMappings from '../../Share/typeMappings';


export function getDataFromApi(apiEndpoints, setEntities) {


        const fetchPromises = apiEndpoints.map(endpoint =>  // ������ �������� ������ ���������
            fetch(endpoint)
                .then(res => res.json())
                .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // ��������� type ������� ����������� �������.  �� �������� ��������� �������������� ��� �������
        );

        Promise.all(fetchPromises).
            then(results => {
                const mergetEntities = results.reduce((acc, curr) => acc.concat(curr), []); //������� ��� ������� � �������� ������������� ������ ��� ������ ��������
                setEntities(mergetEntities);
            })
}