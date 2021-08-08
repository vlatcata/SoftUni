import { html } from "./../node_modules/lit-html/lit-html.js";

const myBooksTemplate = (books) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    ${books.length > 0
        ? html`<ul>${books.map(b => bookTemplate(b))}</ul>`
        : html`<p class="no-books">No books in database!</p>`}
</section>`;

const bookTemplate = (book) => html`
<ul class="my-books-list">
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
</ul>`;

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function getView(context) {
    let user = context.user;
    let userId = user._id;
    let myBooks = await _booksService.getMyBooks(userId);
    let templateResult = myBooksTemplate(myBooks);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}