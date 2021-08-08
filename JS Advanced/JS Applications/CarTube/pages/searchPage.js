import { html } from "./../node_modules/lit-html/lit-html.js";

const searchPageTemplate = (form) => html`
<!-- Search Page -->
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${form.submitHandler}>Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${form.cars
        ? form.cars.map(carTemplate)
        : html`<p class="no-cars"> No results.</p>`}
    </div>
</section>`;

let carTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src="${car.imageUrl}">
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

let _router = undefined;
let _renderHandler = undefined;
let _carService = undefined;
let _form = undefined;
let _cars = undefined;

function initialize(router, renderHandler, carService) {
    _router = router;
    _renderHandler = renderHandler;
    _carService = carService;
}

async function submitHandler(e) {
    let year = Number(document.getElementById('search-input'));
    _cars = await _carService.getByYear(year);
}

async function getView(context) {
    _form = {
        submitHandler,
        cars: _cars
    }
    let templateResult = searchPageTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}





// export const renderSearch = (ctx) => {
//     let currntSearch = '';

//     const onSearchChange = (e) => {
//         currntSearch = e.target.value;
//     }

//     const onSearchClick = (e) => {
//         let year = Number(currntSearch);

//         _carService.getByYear(year)
//             .then(cars => {
//                 _renderHandler(onSearchChange, onSearchClick, cars);
//             })
//     }

//     _renderHandler(onSearchChange, onSearchClick);
// }
