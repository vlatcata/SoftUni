import { html } from "./../node_modules/lit-html/lit-html.js";

const editMemeTemplate = (form) => html`
<section id="edit-meme">
    <form @submit=${(e) => form.submitHandler(form.meme._id, e)} id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${form.meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value=${form.meme.description}></textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${form.meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _memesService = undefined;
let _form = undefined;
let _notifications = undefined;

function initialize(router, renderHandler, memesService, notifications) {
    _router = router;
    _renderHandler = renderHandler;
    _memesService = memesService;
    _notifications = notifications;
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
            let templateResult = editMemeTemplate(_form);
            _notifications.createNotification(_form.errorMessages.join('\n'));
            // alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let meme = {
            title,
            description,
            imageUrl
        }

        await _memesService.update(meme, id);
        _router.redirect(`/details/${id}`);
    } catch (err) {
        _notifications.createNotification(`Error: ${err.message}`);
        // alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let meme = await _memesService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        meme
    }
    let templateResult = editMemeTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}