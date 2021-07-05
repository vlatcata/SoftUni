function lockedProfile() {
    let buttons = Array.from(document.querySelectorAll('button'));
    let profiles = document.querySelectorAll('.profile');

    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', () => {
            let radioButtonName = `user${i + 1}Locked`;
            let radioButton = document.querySelector(`input[name="${radioButtonName}"]:checked`);
            if (radioButton.value === 'unlock') {
                let hiddenField = document.getElementById(`user${i + 1}HiddenFields`);
                hiddenField.style.display = hiddenField.style.display === 'block' ? 'none' : 'block';
                buttons[i].textContent = buttons[i].textContent === 'Show more' ? 'Hide it' : 'Show more';
            }
        });
    }
}