import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemplate = (model) => html`
<section id="meme-details">
    <h1>Meme Title: ${model.meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${model.meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${model.meme.description}
            </p>
            ${model.isOwner
                ? html`
                <a class="button warning" href="/edit/${model.meme._id}">Edit</a>
                <button class="button danger" @click=${(e) => model.deleteHandler(model.meme._id, e)}>Delete</button>`
                : ''}
        </div>
    </div>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _memesService = undefined;

function initialize(router, renderHandler, memesService) {
    _router = router;
    _renderHandler = renderHandler;
    _memesService = memesService;
}

async function deleteHandler(id, e) {
    try {
        await _memesService.deleteItem(id);
        _router.redirect('/all-memes')
    } catch (err) {
        alert(err)
    }
}

async function getView(context) {
    let meme = await _memesService.get(context.params.id);
    let user = context.user;
    let isOwner = false;
    if (user !== undefined && user._id === meme._ownerId) {
        isOwner = true;
    }
    let model = {
        isOwner,
        meme,
        deleteHandler,
    }
    let templateResult = detailsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}