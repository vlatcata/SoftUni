import { html } from "./../node_modules/lit-html/lit-html.js";

const createListingTemplate = (form) => html`
<!-- Create Listing Page -->
<section id="create-listing">
    <div class="container">
        <form @submit=${form.submitHandler} id="create-form">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>`;


let _router = undefined;
let _renderHandler = undefined;
let _carService = undefined;
let _form = undefined

function initialize(router, renderHandler, carService) {
    _router = router;
    _renderHandler = renderHandler;
    _carService = carService;
}

// brand: "Audi"
// description: "Lorem ipsum dolor sit, amet consectetur adipisicing elit."
// imageUrl: "/images/audia3.jpg"
// model: "A3"
// price: 25000
// year: 2018
// _createdOn: 1616162253496
// _id: "3987279d-0ad4-4afb-8ca9-5b256ae3b298"
// _ownerId: "35c62d76-8152-4626-8712-eeb96381bea8"

async function submitHandler(e) {
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
            let templateResult = createListingTemplate(_form);
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

        await _carService.create(car);
        _router.redirect('/all-listings');

    } catch (error) {
        alert(error);
    }
}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = createListingTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}