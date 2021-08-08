import { html } from "./../node_modules/lit-html/lit-html.js";

const editListingTemplate = (form) => html`
<!-- Edit Listing Page -->
<section id="edit-listing">
    <div class="container">

        <form @submit=${(e) => form.submitHandler(form.car._id, e)} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value="${form.car.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value="${form.car.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value="${form.car.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value="${form.car.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${form.car.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value="${form.car.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _carService = undefined;
let _form = undefined;

function initialize(router, renderHandler, carService) {
    _router = router;
    _renderHandler = renderHandler;
    _carService = carService;
}

async function submitHandler(id, e) {
    try {
        e.preventDefault();
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let brand = formData.get('brand');
        if (brand.trim() === '') {
            _form.errorMessages.push('You must enter a brand');
        }

        let model = formData.get('model');
        if (model.trim() === '') {
            _form.errorMessages.push('You must enter a model');
        }

        let description = formData.get('description');
        if (description.trim() === '') {
            _form.errorMessages.push('You must enter the description');
        }

        let year = formData.get('year');
        if (year.trim() === '') {
            _form.errorMessages.push('You must enter the year');
        }

        let imageUrl = formData.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMessages.push('You must enter the imageUrl');
        }

        let price = formData.get('price');
        if (price.trim() === '') {
            _form.errorMessages.push('You must enter the price');
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = editListingTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let car = {
            brand,
            model,
            description,
            year: Number(year),
            imageUrl,
            price: Number(price)
        }

        await _carService.update(car, id);
        _router.redirect(`/details/${id}`);

    } catch (error) {
        alert(error);
    }
}

async function getView(context) {
    let id = context.params.id;
    let car = await _carService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        car
    }
    let templateResult = editListingTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}