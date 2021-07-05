function focused() {
    let sectionElements = Array.from(document.querySelectorAll('input'));

    for (let el of sectionElements) {
        el.addEventListener('focus', onFocus);
        el.addEventListener('blur', onBlur);        
    }

    function onFocus(event){
        event.target.parentNode.className = 'focused';

    }

    function onBlur(event){
        event.target.parentNode.className = ' ';
        
    }
}