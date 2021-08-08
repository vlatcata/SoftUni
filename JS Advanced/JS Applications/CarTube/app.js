import page from "./node_modules/page/page.mjs"
import allListingsPage from "./pages/allListingsPage.js";
import createListingPage from "./pages/createListingPage.js";
import editListingPage from "./pages/editListingPage.js";
import homePage from "./pages/homePage.js";
import listingDetailsPage from "./pages/listingDetailsPage.js";
import loginPage from "./pages/loginPage.js";
import myListingsPage from "./pages/myListingsPage.js";
import navigation from "./pages/navigation.js";
import registerPage from "./pages/registerPage.js";
import searchPage from "./pages/searchPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import carService from "./services/carService.js";

let navElement = document.getElementById('navigation');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navigationRenderer = renderer.createRenderHandler(navElement);
let appRenderer = renderer.createRenderHandler(appElement);

navigation.initialize(page, navigationRenderer, authService);
homePage.initialize(page, appRenderer, authService);
loginPage.initialize(page, appRenderer, authService);
registerPage.initialize(page, appRenderer, authService);
allListingsPage.initialize(page, appRenderer, carService);
createListingPage.initialize(page, appRenderer, carService);
listingDetailsPage.initialize(page, appRenderer, carService);
editListingPage.initialize(page, appRenderer, carService);
myListingsPage.initialize(page, appRenderer, carService);
searchPage.initialize(page, appRenderer, carService);


page('/index.html', '/home');
page('/', '/home');

page(initializeUser);
page(navigation.getView);


page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/all-listings', allListingsPage.getView);
page('/create', createListingPage.getView);
page('/details/:id', listingDetailsPage.getView);
page('/edit/:id', editListingPage.getView);
page('/my-listings', myListingsPage.getView);
page('/search', searchPage.getView);


page.start();

function initializeUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}