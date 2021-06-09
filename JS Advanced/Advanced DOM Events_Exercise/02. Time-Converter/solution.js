function attachEventsListeners() {
    let daysInputElement = document.getElementById('days');
    let hoursInputElement = document.getElementById('hours');
    let minutesInputElement = document.getElementById('minutes');
    let secondsInputElement = document.getElementById('seconds');

    let daysButton = document.getElementById('daysBtn');
    let hoursButton = document.getElementById('hoursBtn');
    let minutesButton = document.getElementById('minutesBtn');
    let secondsButton = document.getElementById('secondsBtn');


    daysButton.addEventListener('click', daysBtnClick);
    hoursButton.addEventListener('click', hoursBtnClick);
    minutesButton.addEventListener('click', minutesBtnClick);
    secondsButton.addEventListener('click', secondsBtnClick);

    function daysBtnClick() {
        let daysValue = Number(daysInputElement.value);
        let hoursValue = daysValue * 24;
        let minutesValue = daysValue * 24 * 60;
        let secondsValue = daysValue * 24 * 60 * 60;
        hoursInputElement.value = hoursValue;
        minutesInputElement.value = minutesValue;
        secondsInputElement.value = secondsValue;
    }

    function hoursBtnClick() {
        let hoursValue = Number(hoursInputElement.value);
        let daysValue = hoursValue / 24;
        let minutesValue = hoursValue * 60;
        let secondsValue = hoursValue * 60 * 60;
        daysInputElement.value = daysValue;
        minutesInputElement.value = minutesValue;
        secondsInputElement.value = secondsValue;
    }

    function minutesBtnClick() {
        let minutesValue = Number(minutesInputElement.value);
        let hoursValue = minutesValue / 60;
        let daysValue = minutesValue / 60 / 24;
        let secondsValue = minutesValue * 60;
        hoursInputElement.value = hoursValue;
        secondsInputElement.value = secondsValue;
        daysInputElement.value = daysValue;
    }

    function secondsBtnClick() {
        let secondsValue = Number(secondsInputElement.value);
        let hoursValue = secondsValue / 60 / 60;
        let minutesValue = secondsValue / 60;
        let daysValue = secondsValue  / 60 / 60 / 24;
        hoursInputElement.value = hoursValue;
        minutesInputElement.value = minutesValue;
        daysInputElement.value = daysValue;
    }
}