function encodeAndDecodeMessages() {
    let textAreas = document.querySelectorAll('textarea');
    let message = textAreas[0];
    let lastReceivedMessage = textAreas[1];

    let buttons = document.querySelectorAll('button');
    let encodeButton = buttons[0];
    let decodeMessageButton = buttons[1];

    encodeButton.addEventListener('click', encodeMessage);

    function encodeMessage() {
        let text = message.value.split('')
        .map((ch) => ch.charCodeAt())
        .map((ch) => String.fromCharCode(ch + 1))
        .join('');

        message.value = '';

        lastReceivedMessage.value = text;
    };

    decodeMessageButton.addEventListener('click', decodeMessage);

    let decodedMessage;

    function decodeMessage() {
        decodedMessage = lastReceivedMessage.value.split('')
        .map((ch) => ch.charCodeAt())
        .map((ch) => String.fromCharCode(ch - 1))
        .join('');

        lastReceivedMessage.value = '';
        lastReceivedMessage.value = decodedMessage;
    };
}