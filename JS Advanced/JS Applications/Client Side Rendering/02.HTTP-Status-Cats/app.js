import { catsTemplate } from "./templates/catsTemplates.js";
import { render } from "./../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";


function toggleStatusCodeButton(e){
    let button = e.target;
    button.textContent = button.textContent === 'Show status code' ? 'Hide status code' : 'Show status code';

    let info = button.closest('.info');
    let status = info.querySelector('.status');
    if (status.classList.contains('hidden')) {
        status.classList.remove('hidden');
    } else {
        status.classList.add('hidden');
    }
}

let allCats = document.getElementById('allCats');
render(catsTemplate(cats, toggleStatusCodeButton), allCats)