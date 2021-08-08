import { html } from "./../node_modules/lit-html/lit-html.js";

const editTemplate = (form) => html`
<section id="edit-page" class="edit">
<form @submit=${(e) => form.submitHandler(form.book._id, e)} id="edit-form" action="#" method="">
    <fieldset>
        <legend>Edit my Book</legend>
        <p class="field">
            <label for="title">Title</label>
            <span class="input">
                <input type="text" name="title" id="title" value="${form.book.title}">
            </span>
        </p>
        <p class="field">
            <label for="description">Description</label>
            <span class="input">
                <textarea name="description"
                    id="description">${form.book.description}</textarea>
            </span>
        </p>
        <p class="field">
            <label for="image">Image</label>
            <span class="input">
                <input type="text" name="imageUrl" id="image" value="${form.book.imageUrl}">
            </span>
        </p>
        <p class="field">
            <label for="type">Type</label>
            <span class="input">
                <select id="type" name="type" value="${form.book.type}">
                    <option value="Fiction" selected>Fiction</option>
                    <option value="Romance">Romance</option>
                    <option value="Mistery">Mistery</option>
                    <option value="Classic">Clasic</option>
                    <option value="Other">Other</option>
                </select>
            </span>
        </p>
        <input class="button submit" type="submit" value="Save">
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

async function submitHandler(id, e) {
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
            let templateResult = editTemplate(_form);
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

        await _booksService.update(book, id);
        _router.redirect(`/details/${id}`);
    } catch (err) {
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let book = await _booksService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        book
    }
    let templateResult = editTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}