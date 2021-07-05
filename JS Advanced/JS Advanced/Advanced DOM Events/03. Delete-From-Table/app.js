function deleteByEmail() {
    let inputEmail = document.querySelector('input[name="email"]').value;
    let listEmails = [...document.querySelectorAll('tbody tr')];
    let resultElement = document.getElementById('result');
    
    listEmails.forEach((row) => {
        if (row.children[1].textContent === inputEmail) {
            row.parentNode.removeChild(row);
            resultElement.textContent = 'Deleted.';
        } else {
            resultElement.textContent = 'Not found.';
        }
    });
}