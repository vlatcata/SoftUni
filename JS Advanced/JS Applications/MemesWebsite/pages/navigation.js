import { html} from "./../../node_modules/lit-html/lit-html.js";

const navTemplate = (nav) => html `
<a href="/all-memes">All Memes</a>
${nav.isLoggedIn 
    ? loggedControls(nav)
    : guestControls() }
`;

let loggedControls = (nav) => html`
<div class="user">
    <a href="/create">Create Meme</a>
    <div class="profile">
        <span>Welcome, ${nav.email}</span>
        <a href="/profile">My Profile</a>
        <a href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
    </div>
</div>`;

let guestControls = () => html`
<div class="guest">
    <div class="profile">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
    <a class="active" href="/home">Home Page</a>
</div>`;

let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function logoutHandler(e){
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
    let templateResult = navTemplate(navModel);
    _renderHandler(templateResult);
    next();
}

export default {
    getView,
    initialize
}