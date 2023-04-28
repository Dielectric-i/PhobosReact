import typeMappings from '../../Share/typeMappings';

export function getDataFromApi(apiEndpoints, setData) {

    const fetchPromises = apiEndpoints.map(endpoint =>  // Массив промисов вызова эндпойнта
        fetch(endpoint)
            .then(res => res.json())
            .then(data => data.map(card => ({ ...card, type: typeMappings[endpoint] }))) // Добавляем type каждому полученному объекту.  По названию эндпойнта идентифицируем тип объекта
    );

    Promise.all(fetchPromises).
        then(results => {
            const mergetCards = results.reduce((acc, curr) => acc.concat(curr), []); //Сшиваем все объекты и получаем подготовленый массив для вывода карточек
            setData(mergetCards);
        })
}