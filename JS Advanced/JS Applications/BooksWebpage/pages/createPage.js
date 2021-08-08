import { html } from "./../node_modules/lit-html/lit-html.js";

const createBookTemplate = (form) => html`
<section id="create-page" class="create">
<form @submit=${form.submitHandler} id="create-form" action="" method="">
    <fieldset>
        <legend>Add new Book</legend>
        <p class="field">
            <label for="title">Title</label>
            <span class="input">
                <input type="text" name="title" id="title" placeholder="Title">
            </span>
        </p>
        <p class="field">
            <label for="description">Description</label>
            <span class="input">
                <textarea name="description" id="description" placeholder="Description"></textarea>
            </span>
        </p>
        <p class="field">
            <label for="image">Image</label>
            <span class="input">
                <input type="text" name="imageUrl" id="image" placeholder="Image">
            </span>
        </p>
        <p class="field">
            <label for="type">Type</label>
            <span class="input">
                <select id="type" name="type">
                    <option value="Fiction">Fiction</option>
                    <option value="Romance">Romance</option>
                    <option value="Mistery">Mistery</option>
                    <option value="Classic">Clasic</option>
                    <option value="Other">Other</option>
                </select>
            </span>
        </p>
        <input class="button submit" type="submit" value="Add Book">
    </fieldset>
</form>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;
let _form = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function submitHandler(e) {
    try {
        e.preventDefault();
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let title = formData.get('title');
        if (title.trim() === '') {
            _form.errorMessages.push('Title is required');
        }

        let description = formData.get('description');
        if (description.trim() === '') {
            _form.errorMessages.push('Description is required');
        }

        let imageUrl = formData.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMessages.push('ImageUrl is required');
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = createBookTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let type = formData.get('type');

        let book = {
            title,
            description,
            imageUrl,
            type
        }

        await _booksService.create(book);
        _router.redirect('/home');
    } catch (err) {
        alert(err);
    }
}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = createBookTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}