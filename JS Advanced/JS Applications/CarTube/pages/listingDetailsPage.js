import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemplate = (model) => html`
<!-- Listing Details Page -->
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${model.car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${model.car.brand}</li>
            <li><span>Model:</span>${model.car.model}</li>
            <li><span>Year:</span>${model.car.year}</li>
            <li><span>Price:</span>${model.car.price}$</li>
        </ul>

        <p class="description-para">${model.car.description}</p>

        <div class="listings-buttons">
            ${model.isOwner
            ? html`
            <a href="/edit/${model.car._id}" class="button-list">Edit</a>
            <a href="#" class="button-list" @click=${(e) => model.deleteHandler(model.car._id, e)}>Delete</a>`
            : ''}
        </div>
    </div>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _carService = undefined;

function initialize(router, renderHandler, carService) {
    _router = router;
    _renderHandler = renderHandler;
    _carService = carService;
}

async function deleteHandler(id, e){
    try {
        await _carService.deleteItem(id)
        _router.redirect('/all-listings');
    } catch (error) {
        alert(error)
    }
}

async function getView(context) {
    let car = await _carService.get(context.params.id);
    let user = context.user;
    let isOwner = false;
    if (user !== undefined && user._id === car._ownerId) {
        isOwner = true;
    }
    let model = {
        deleteHandler,
        car,
        isOwner
    }
    let templateResult = detailsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}