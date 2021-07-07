function getInfo() {
    let stopIdInput = document.getElementById('stopId');
    let stopId = stopIdInput.value;

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
    .then(info => info.json())
    .then(stopInfo => {
        let stopName = document.getElementById('stopName');
        stopName.textContent = stopInfo.name;
        let busses = document.getElementById('buses');

        Array.from(busses.querySelectorAll('li')).forEach(li => li.remove());
        
        Object.keys(stopInfo.buses).forEach(key => {
            let busInfo = document.createElement('li');
            busInfo.textContent = `Bus ${key} arrives in ${stopInfo.buses[key]}`;
            busses.appendChild(busInfo);
        })
    })
    .catch(err => {
        let stopName = document.getElementById('stopName');
        stopName.textContent = 'Error';
        let busses = document.getElementById('buses');
        Array.from(busses.querySelectorAll('li')).forEach(li => li.remove());
    })
}