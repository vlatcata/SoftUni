import { html } from "./../node_modules/lit-html/lit-html.js";

const loginTemplate = (form) => html`
<section id="login-page" class="login">
<form id="login-form" @submit=${form.submitHandler} action="" method="">
    <fieldset>
        <legend>Login Form</legend>
        <p class="field">
            <label for="email">Email</label>
            <span class="input">
                <input type="text" name="email" id="email" placeholder="Email">
            </span>
        </p>
        <p class="field">
            <label for="password">Password</label>
            <span class="input">
                <input type="password" name="password" id="password" placeholder="Password">
            </span>
        </p>
        <input class="button submit" type="submit" value="Login">
    </fieldset>
</form>
</section>`;

let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;
let _form = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function submitHandler(e) {
    try {
        e.preventDefault();
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let email = formData.get('email');
        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }
        
        let password = formData.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }
        
        if (_form.errorMessages.length > 0) {
            let templateResult = loginTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let user = {
            email,
            password
        }

        await _authService.login(user);
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
    let templateResult = loginTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}