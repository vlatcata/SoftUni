import { html } from "./../node_modules/lit-html/lit-html.js";

export let allMemesTemplate = (memes) => html `
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${memes.length > 0
            ? memes.map(m => memeTemplate(m))
            : html`<p class="no-memes">No memes in database.</p>`}
    </div>
</section>`;

let memeTemplate = (meme) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${meme.title}</p>
            <img class="meme-image" alt="meme-img" src="${meme.imageUrl}">
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${meme._id}">Details</a>
        </div>
    </div>
</div>`;



let _router = undefined;
let _renderHandler = undefined;
let _memesService = undefined;

function initialize(router, renderHandler, memesService) {
    _router = router;
    _renderHandler = renderHandler;
    _memesService = memesService;
}

async function getView(context) {
    let allMemes = await _memesService.getAllMemes();
    let templateResult = allMemesTemplate(allMemes);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}