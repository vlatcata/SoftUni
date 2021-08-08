import { html } from "./../node_modules/lit-html/lit-html.js";

const navigationTemplate = (nav) => html`
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/home">Dashboard</a>
        ${nav.isLoggedIn ? loggedTemplate(nav) : notLoggedTemplate() }
    </section>
</nav>`;

const notLoggedTemplate = () => html`
<div id="guest">
<a class="button" href="/login">Login</a>
<a class="button" href="/register">Register</a>
</div>`;

const loggedTemplate = (nav) => html`
<div id="user">
    <span>Welcome, ${nav.email}</span>
    <a class="button" href="/my-books">My Books</a>
    <a class="button" href="/create">Add Book</a>
    <a class="button" href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
</div>`;

let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function logoutHandler(e) {
    await _authService.logout();
    _router.redirect('/home');
}

async function getView(context, next) {
    let user = context.user;
    let email = user !== undefined ? user.email : undefined;

    let navModel = {
        isLoggedIn: user !== undefined,
        email,
        logoutHandler
    }
    let templateResult = navigationTemplate(navModel);
    _renderHandler(templateResult);
    next();
}

export default {
    getView,
    initialize
}