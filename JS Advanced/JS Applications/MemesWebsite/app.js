import page from "./node_modules/page/page.mjs"
import allMemesPage from "./pages/allMemesPage.js";
import createMeme from "./pages/createMeme.js";
import detailsPage from "./pages/detailsPage.js";
import editMeme from "./pages/editMeme.js";
import homePage from "./pages/homePage.js";
import loginPage from "./pages/loginPage.js";
import navigation from "./pages/navigation.js";
import notifications from "./pages/notifications.js";
import profile from "./pages/profile.js";
import registerPage from "./pages/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import memesService from "./services/memesService.js";

let navElement = document.getElementById('nav');
let appElement = document.getElementById('app');
let notificationsElement = document.getElementById('notifications');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);
let notificationsRenderHandler = renderer.createRenderHandler(notificationsElement);

notifications.initialize(page, notificationsRenderHandler);

navigation.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, authService);
loginPage.initialize(page, appRenderHandler, authService, notifications);
registerPage.initialize(page, appRenderHandler, authService, notifications);
allMemesPage.initialize(page, appRenderHandler, memesService);
createMeme.initialize(page, appRenderHandler, memesService, notifications);
detailsPage.initialize(page,appRenderHandler, memesService);
editMeme.initialize(page, appRenderHandler, memesService, notifications);
profile.initialize(page, appRenderHandler, memesService);


page('index.htlm', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(navigation.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/all-memes', allMemesPage.getView);
page('/create', createMeme.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editMeme.getView);
page('/profile', profile.getView);

page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}