function buildCar(obj) {
    const engines = {
        90: {
            power: 90,
            volume: 1800
        },
        120: {
            power: 120,
            volume: 2400
        },
        200: {
            power: 200,
            volume: 3500
        }
    }

    function determineEngine(power) {
        for (const engine in engines) {
            if (power <= engine) {
                return engines[engine];
            }
        }
    }

    function determineWheels(size) {
        let arr = new Array(4);
        if (size % 2 == 0) {
            size--;
        }
        arr.fill(size);
        return arr;
    }

    let myCar = {
        model: obj.model,
        engine: determineEngine(obj.power),
        carriage: {
            type: obj.carriage,
            color: obj.color,
        },
        wheels: determineWheels(obj.wheelsize),
    }

    return myCar;
}

console.log(buildCar({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));