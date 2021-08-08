import { html } from "./../node_modules/lit-html/lit-html.js";

const homePageTemplate = (books) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="other-books-list">
        ${books.length > 0
            ? books.map(b => bookTemplate(b))
            : html`<p class="no-books">No books in database!</p>`}
    </ul>
</section>`;

const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>`;

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function getView(context) {
    let allBooks = await _booksService.getAllBooks();
    let templateResult = homePageTemplate(allBooks);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}