import { html } from "./../node_modules/lit-html/lit-html.js";

const navigationTemplate = (model) => html`
<!-- Navigation -->
<nav>
    <a class="active" href="#">Home</a>
    <a href="/all-listings">All Listings</a>
    <a href="/search">By Year</a>

    ${model.isLoggedIn ? loggedUser(model) : guestUser() }
</nav>`;

let guestUser = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>`;

let loggedUser = (model) => html`
<div id="profile">
    <a>Welcome ${model.username}</a>
    <a href="/my-listings">My Listings</a>
    <a href="/create">Create Listing</a>
    <a href="javascript:void(0)" @click="${model.logoutHandler}">Logout</a>
</div>`;

let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function logoutHandler() {
    await _authService.logout();
    _router.redirect('/home');

}

async function getView(context, next) {
    let user = context.user;
    let username = user !== undefined ? user.username : undefined;

    let model = {
        logoutHandler,
        username,
        isLoggedIn: user !== undefined
    }

    let templateResult = navigationTemplate(model);
    _renderHandler(templateResult);
    next();
}

export default {
    initialize,
    getView
}

