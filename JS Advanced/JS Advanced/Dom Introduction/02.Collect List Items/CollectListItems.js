function extractText() {
    let elements = document.getElementsByTagName('li');
    let content = [...elements];
    let resultText = document.getElementById('result');
    for (const item of content) {
        resultText.value += item.textContent + '\n';
    }
 }