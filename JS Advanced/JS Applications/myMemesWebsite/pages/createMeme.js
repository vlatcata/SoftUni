import { html } from "./../node_modules/lit-html/lit-html.js";

const createMemeTemplate = (form) => html`
<section id="create-meme">
    <form @submit=${form.submitHandler} id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
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
            let templateResult = createMemeTemplate(_form);
            _notifications.createNotification(_form.errorMessages.join('\n'));
            // alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let meme = {
            title,
            description,
            imageUrl
        }

        await _memesService.create(meme);
        _router.redirect('/all-memes');
    } catch (err) {
        _notifications.createNotification(`Error: ${err.message}`);
        // alert(err);
    }
}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = createMemeTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}