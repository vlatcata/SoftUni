function toggle() {
    const text = document.getElementById('extra');
    const button = document.getElementsByClassName('button')[0];

    text.style.display = text.style.display === 'block' ? 'none' : 'block';
    button.textContent = button.textContent === 'More' ? 'Less' : 'More';
}