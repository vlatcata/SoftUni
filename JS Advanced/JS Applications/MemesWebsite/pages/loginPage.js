import { html } from "./../node_modules/lit-html/lit-html.js";

const loginTemplate = (form) => html`
<section id="login">
    <form @submit=${form.submitHandler} id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;


let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;
let _form = undefined;
let _notifications = undefined;

function initialize(router, renderHandler, authService, notifications) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
    _notifications = notifications;
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
            _notifications.createNotification(_form.errorMessages.join('\n'));
            // alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let user = {
            email,
            password
        }

        let loginResult = await _authService.login(user);
        _router.redirect('/home');
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
    let templateResult = loginTemplate(_form);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}