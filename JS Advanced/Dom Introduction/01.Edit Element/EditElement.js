function editElement(reference, match, replacer) {
    let element = reference.textContent;
    let matcher = new RegExp(match, 'g');
    let edited = element.replace(matcher, replacer);
    reference.textContent = edited;
}