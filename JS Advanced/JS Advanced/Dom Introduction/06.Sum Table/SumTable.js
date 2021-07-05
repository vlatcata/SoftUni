function sumTable() {
    let elements = document.querySelectorAll('table tr');
    let total = 0;
    for (let i = 1; i < elements.length; i++) {
        let cols = elements[i].children;
        let cost = cols[1].textContent;
        total += Number(cost);
    }
    document.getElementById('sum').textContent = total;
}