import page from "./node_modules/page/page.mjs";
import createPage from "./pages/createPage.js";
import detailsPage from "./pages/detailsPage.js";
import editPage from "./pages/editPage.js";
import homePage from "./pages/homePage.js";
import loginPage from "./pages/loginPage.js";
import myBooksPage from "./pages/myBooksPage.js";
import navigation from "./pages/navigation.js";
import registerPage from "./pages/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import booksService from "./services/booksService.js";


let navElement = document.getElementById('site-header');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);


navigation.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, booksService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
createPage.initialize(page, appRenderHandler, booksService);
detailsPage.initialize(page, appRenderHandler, booksService);
editPage.initialize(page, appRenderHandler, booksService);
myBooksPage.initialize(page, appRenderHandler, booksService);


page('index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(navigation.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-books', myBooksPage.getView);


page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}