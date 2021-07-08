function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/messenger';
    let sendButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');
    let authorName = document.querySelector("input[name='author']");
    let message = document.querySelector("input[name='content']");
    let textArea = document.getElementById('messages');

    sendButton.addEventListener('click', (e) => {
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                author: authorName.value,
                content: message.value
            })
        })
        
        authorName.value = '';
        message.value = '';
    });

    refreshButton.addEventListener('click', (e) => {
        fetch(url)
        .then(info => info.json())
        .then(messages => {
            textArea.value = Object.values(messages).map((e) => `${e.author}: ${e.content}`).join('\n');
            console.log(messages);
            console.log(Object.values(messages));
        })
        .catch(err => {
            console.log(err);
        })
    })
}

attachEvents();