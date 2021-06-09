function attachEventsListeners() {
    let button = document.getElementById('convert');

    button.addEventListener('click', (e) => {
        let fromUnit = document.getElementById('inputUnits').value;
        let toUnit = document.getElementById('outputUnits').value;
    
        let input = Number(document.getElementById('inputDistance').value);
        let output = document.getElementById('outputDistance');
        
        let unitToM = 0;
        let result = 0;

        if (fromUnit === 'km') {
            unitToM = input * 1000;
        } else if(fromUnit === 'm') {
            unitToM = fromUnit;
        } else if (fromUnit === 'cm') {
            unitToM = fromUnit * 0.01;
        } else if (fromUnit === 'mm') {
            unitToM = fromUnit * 0.001;
        } else if (fromUnit === 'mi') {
            unitToM = fromUnit * 1609.34;
        } else if (unitToM === 'yrd') {
            unitToM = fromUnit * 0.9144;
        } else if (fromUnit === 'ft') {
            unitToM = fromUnit * 0.3048;
        } else if (fromUnit === 'in') {
            unitToM = fromUnit * 0.0254;
        }


        if (toUnit === 'km') {
            result = unitToM / 1000;
        } else if (toUnit === 'm') {
            result = unitToM;
        } else if (toUnit === 'cm') {
            result = unitToM / 0.01;
        } else if (toUnit === 'mm') {
            result = unitToM / 0.001;
        } else if (toUnit === 'mi') {
            result = unitToM / 1609.341;
        } else if (toUnit === 'yrd') {
            result = unitToM / 0.9144;
        } else if (toUnit === 'ft') {
            result = unitToM / 0.3048;
        } else if (toUnit === 'in') {
            result = unitToM / 0.0254;
        }

        output.value = result;
    });
}