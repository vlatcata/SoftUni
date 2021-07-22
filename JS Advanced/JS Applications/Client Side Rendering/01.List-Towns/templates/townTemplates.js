import { html } from '../../node_modules/lit-html/lit-html.js';

export let townTemplate = (town) => html`<li>${town}</li>`;

export let allTownsTemplate = (towns) => html`
    <ul>
        ${towns.map(x => townTemplate(x))}
    </ul>
`;