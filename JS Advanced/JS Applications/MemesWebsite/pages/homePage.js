import { html } from "./../node_modules/lit-html/lit-html.js";

const homeTemplate = () => html`
<section id="welcome">
    <div id="welcome-container">
        <h1>Welcome To Meme Lounge</h1>
        <img src="/images/welcome-meme.jpg" alt="meme">
        <h2>Login to see our memes right away!</h2>
        <div id="button-div">
            <a href="/login" class="button">Login</a>
            <a href="/register" class="button">Register</a>
        </div>
    </div>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function getView(context) {
    let templateResult = homeTemplate();
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}