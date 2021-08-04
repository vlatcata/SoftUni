import { html } from "./../node_modules/lit-html/lit-html.js";

const profileTemplate = (model) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src=${model.user.gender === 'male' 
            ? '/images/male.png'
            : '/images/female.png'}>
        <div class="user-content">
            <p>Username: ${model.user.username}</p>
            <p>Email: ${model.user.email}</p>
            <p>My memes count: ${model.memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        ${model.memes.length > 0
        ? model.memes.map(m => memeTemplate(m))
        : html`<p class="no-memes">No memes in database.</p>`}
    </div>
</section>`;

let memeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
    <a class="button" href="/details/${meme._id}">Details</a>
</div>`;


let _router = undefined;
let _renderHandler = undefined;
let _memesService = undefined;

function initialize(router, renderHandler, memesService) {
    _router = router;
    _renderHandler = renderHandler;
    _memesService = memesService;
}

async function getView(context) {
    let user = context.user;
    let userMemes = [];
    if(user !== undefined){
        userMemes = await _memesService.getMyMemes(user._id);
    }

    let model = {
        memes: userMemes,
        user
    }
    
    let templateResult = profileTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}