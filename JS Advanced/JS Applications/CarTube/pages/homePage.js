import { html } from "./../node_modules/lit-html/lit-html.js";

const homePageTemplate = () => html`
<!-- Home Page -->
<section id="main">
    <div id="welcome-container">
        <h1>Welcome To Car Tube</h1>
        <img class="hero" src="/images/car-png.webp" alt="carIntro">
        <h2>To see all the listings click the link below:</h2>
        <div>
            <a href="#" class="button">Listings</a>
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
    let templateResult = homePageTemplate();
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}