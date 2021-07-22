import { render } from "./../node_modules/lit-html/lit-html.js";
import { allTownsTemplate } from './templates/townTemplates.js';

let form = document.getElementById('towns-form');
form.addEventListener('submit', showTowns);

let rootDiv = document.getElementById('root');

function showTowns(e) {
    e.preventDefault();
    console.log('hi');

    let form = e.target;
    let formData = new FormData(form);

    let townsString = formData.get('towns');
    let towns = townsString.split(', ');

    render(allTownsTemplate(towns), rootDiv);
}