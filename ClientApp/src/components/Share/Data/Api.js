import typeMappings from '../../Share/typeMappings';

export function getDataFromApi(apiEndpoints, setData) {

    const fetchPromises = apiEndpoints.map(endpoint =>  // ������ �������� ������ ���������
        fetch(endpoint)
            .then(res => res.json())
            .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // ��������� type ������� ����������� �������.  �� �������� ��������� �������������� ��� �������
    );

    Promise.all(fetchPromises).
        then(results => {
            const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //������� ��� ������� � �������� ������������� ������ ��� ������ ��������
            setData(mergetCards);
        })
}