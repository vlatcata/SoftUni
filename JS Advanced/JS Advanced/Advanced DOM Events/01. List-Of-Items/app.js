function addItem() {
    let listItems = document.getElementById('items');
    let element = document.getElementById('newItemText');

    let elementToAdd = document.createElement('li');
    elementToAdd.textContent = element.value;
    listItems.appendChild(elementToAdd);
}