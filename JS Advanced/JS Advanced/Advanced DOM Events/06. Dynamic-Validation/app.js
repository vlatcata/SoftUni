function validate() {
    let inputEmail = document.getElementById('email');
    
    inputEmail.addEventListener('change', (e) => {
        let email = e.target.value;
        if (/^[a-z]+@[a-z]+\.[a-z]+$/.test(email)) {
            e.currentTarget.className = ' ';
        } else {
            e.currentTarget.className = 'error';
        }
    })
}