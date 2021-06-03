function colorize() {
    let elements = document.querySelectorAll('table tr');
    elements = [...elements];
    let index = 0;
    for (const item of elements) {
        index++;
        if (index % 2 == 0) {
            item.style.background = 'teal';
        }
    }
}