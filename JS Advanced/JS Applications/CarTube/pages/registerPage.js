import { html } from "./../node_modules/lit-html/lit-html.js";

const registerTemplate = (form) => html`
<!-- Register Page -->
<section id="register">
    <div class="container">
        <form @submit=${form.submitHandler} id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>
            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>
            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>
            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>
            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
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

        let username = formData.get('username');
        if (username.trim() === '') {
            _form.errorMessages.push('You must enter a username');
        }

        let password = formData.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('You must enter a password');
        }

        let repeatPass = formData.get('repeatPass');
        if (repeatPass.trim() === '') {
            _form.errorMessages.push('You must enter the password again');
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = registerTemplate(_form);
            alert(_form.errorMessages);
            return _renderHandler(templateResult);
        }

        let user = {
            username,
            password,
            repeatPass
        }

        await _authService.register(user);
        _router.redirect('/home');

    } catch (error) {
        alert(error);
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