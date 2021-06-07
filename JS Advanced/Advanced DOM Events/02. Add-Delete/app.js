function addItem() {
    let listItems = document.getElementById('items');
    let element = document.getElementById('newItemText');

    let elementToAdd = document.createElement('li');
    elementToAdd.textContent = element.value;

    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    deleteButton.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    });

    elementToAdd.appendChild(deleteButton);
    listItems.appendChild(elementToAdd);

    element.value = '';
}

