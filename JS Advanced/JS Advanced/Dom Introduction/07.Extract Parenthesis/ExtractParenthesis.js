function extract(content) {
    let text = document.getElementById(content).textContent;
    let regex = /\((.+?)\)/gm;
    let match = regex.exec(text);

    let result = '';

    while (match != null) {
        result += match + '; ';
        match = regex.exec(text);
    }

    return result;
}

let text = extract("content");
console.log(text);