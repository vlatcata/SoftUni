import { html } from "./../node_modules/lit-html/lit-html.js";

const registerTemplate = (form) => html`
<section id="register">
    <form @submit=${form.submitHandler} id="register-form">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
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

        let repeatPassword = formData.get('repeatPass');
        if (repeatPassword.trim() === '') {
            _form.errorMessages.push('Repeated password is required');
        }

        let username = formData.get('username');
        if (username.trim() === '') {
            _form.errorMessages.push('Username is required');
        }

        let gender = formData.get('gender');
        if (gender.trim() === '') {
            _form.errorMessages.push('Gender is required');
        }
        
        if (_form.errorMessages.length > 0) {
            let templateResult = registerTemplate(_form);
            _notifications.createNotification(_form.errorMessages.join('\n'));
            // alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let user = {
            email,
            password,
            username,
            gender
        }

        await _authService.register(user);
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
    let templateResult = registerTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}