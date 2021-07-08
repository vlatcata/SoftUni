function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadNumbers);
    document.getElementById('btnCreate').addEventListener('click', createElement);
}

attachEvents();

async function loadNumbers(){
    let ul = document.getElementById('phonebook');
    let data = await fetch('http://localhost:3030/jsonstore/phonebook');
    let result = await data.json();

    ul.textContent = '';
    console.log(ul.textContent);

    Object.values(result).map(createContact).forEach((c) => ul.appendChild(c));

    console.log(Object.values(result));
}

async function createElement(){
    let person = document.getElementById('person').value;
    let phone = document.getElementById('phone').value;

    let result = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            person: person,
            phone: phone
        })
    });

    loadNumbers();

    person.value = '';
    phone.value = '';
}

function createContact({person, phone, id}){
    let li = document.createElement('li');
    li.setAttribute('id', id);
    li.textContent = `${person}: ${phone}`;

    let deleteButton = document.createElement('button');
    deleteButton.textContent = "Delete";
    deleteButton.addEventListener('click', deletePost)
    li.appendChild(deleteButton);

    return li;
}

async function deletePost(e){
    let elToDelete = e.target.parentNode.id;
    let url = `http://localhost:3030/jsonstore/phonebook/${elToDelete}`;

    let result = await fetch(url, {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
        }
    })

    e.target.parentNode.remove();
}