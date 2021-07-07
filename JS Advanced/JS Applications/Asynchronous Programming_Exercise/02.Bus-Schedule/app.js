function solve() {

    function depart() {
        let departButton = document.getElementById('depart');
        let arriveButton = document.getElementById('arrive');
        let stopInfoSpan = document.querySelector('#info .info');
        let nextStop = 'depot';

        if (stopInfoSpan.getAttribute('data-next-stop') !== null) {
            nextStop = stopInfoSpan.getAttribute('data-next-stop');
        }

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStop}`)
        .then(info => info.json())
        .then(stopInfo => {
            stopInfoSpan.setAttribute('data-stop-name', stopInfo.name);
            stopInfoSpan.setAttribute('data-next-stop', stopInfo.next);
            stopInfoSpan.textContent = `Next stop ${stopInfo.name}`;
            departButton.disabled = true;
            arriveButton.disabled = false;
        })
        .catch(err => {
            stopInfoSpan.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        })
    }

    function arrive() {
        let departButton = document.getElementById('depart');
        let arriveButton = document.getElementById('arrive');
        let stopInfoSpan = document.querySelector('#info .info');

        let stopName = stopInfoSpan.getAttribute('data-stop-name');
        stopInfoSpan.textContent = `Arriving at ${stopName}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();