import page from "./node_modules/page/page.mjs"
import allMemesPage from "./pages/allMemesPage.js";
import homePage from "./pages/homePage.js";
import loginPage from "./pages/loginPage.js";
import navigation from "./pages/navigation.js";
import registerPage from "./pages/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import memesService from "./services/memesService.js";

let navElement = document.getElementById('nav');
let appElement = document.getElementById('app');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);

navigation.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, authService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
allMemesPage.initialize(page, appRenderHandler, memesService);

page('index.htlm', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(navigation.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/all-memes', allMemesPage.getView);

page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}