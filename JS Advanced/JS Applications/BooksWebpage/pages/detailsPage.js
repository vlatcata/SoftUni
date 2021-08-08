import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemplate = (model) => html`
<section id="details-page" class="details">
<div class="book-information">
    <h3>${model.book.title}</h3>
    <p class="type">Type: ${model.book.type}</p>
    <p class="img"><img src="${model.book.imageUrl}"></p>
    <div class="actions">
        <!-- Edit/Delete buttons ( Only for creator of this book )  -->
        ${model.isOwner
            ? html`<a class="button" href="/edit/${model.book._id}">Edit</a>
            <a class="button" @click=${(e) => model.deleteHandler(model.book._id, e)} href="#">Delete</a>`
            : ''}
        <!-- Bonus -->
        <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
        ${model.isLoggedIn && !model.isOwner
        ? html`<a class="button" href="#">Like</a>`
        : ''}


        <!-- ( for Guests and Users )  -->
        <div class="likes">
            <img class="hearts" src="/images/heart.png">
            <span id="total-likes">Likes: 0</span>
        </div>
        <!-- Bonus -->
    </div>
</div>
<div class="book-description">
    <h3>Description:</h3>
    <p>${model.book.description}</p>
</div>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function deleteHandler(id, e) {
    try {
        await _booksService.deleteItem(id);
        _router.redirect('/home')
    } catch (err) {
        alert(err)
    }
}

async function getView(context) {
    let book = await _booksService.get(context.params.id);
    let user = context.user;
    let isOwner = false;
    let isLoggedIn = user !== undefined;
    if (user !== undefined && user._id === book._ownerId) {
        isOwner = true;
    }
    let model = {
        isOwner,
        book,
        deleteHandler,
        isLoggedIn
    }
    let templateResult = detailsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}