import page from "./node_modules/page/page.mjs"
import homePage from "./pages/homePage.js";
import loginPage from "./pages/loginPage.js";
import navigation from "./pages/navigation.js";
import registerPage from "./pages/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";

let navElement = document.getElementById('navigation');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navigationRenderer = renderer.createRenderHandler(navElement);
let appRenderer = renderer.createRenderHandler(appElement);

navigation.initialize(page, navigationRenderer, authService);
homePage.initialize(page, appRenderer, authService);
loginPage.initialize(page, appRenderer, authService);
registerPage.initialize(page, appRenderer, authService);


page('/index.html', '/home');
page('/', '/home');

page(initializeUser);
page(navigation.getView);


page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);


page.start();

function initializeUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}