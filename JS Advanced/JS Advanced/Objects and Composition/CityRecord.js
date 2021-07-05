function createCity(name, population, treasury) {
    const city = {
        name: name,
        population: population,
        treasury: treasury
    }

    return city;
}

let cityy = createCity('Tortuga', 7000, 15000);

console.log(cityy);