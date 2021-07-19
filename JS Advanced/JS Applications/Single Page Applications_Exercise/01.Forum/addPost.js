let topicTitle = document.getElementById('topicName');
let username = document.getElementById('username');
let content = document.getElementById('postText');

let cancelButton = document.querySelector('button .cancel');
let postButton = document.querySelector('button .public');

postButton.addEventListener('click', makePost);

async function makePost(e){
    e.preventDefault();

    console.log('hi');
}

cancelButton.addEventListener('click', (e) => {
    console.log('asd');
})
