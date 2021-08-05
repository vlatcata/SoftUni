import { html } from "./../node_modules/lit-html/lit-html.js";

const loginTemplate = (form) => html`
<!-- Login Page -->
<section id="login">
    <div class="container">
        <form @submit=${form.submitHandler} id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>
            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">
            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
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

        if (_form.errorMessages.length > 0) {
            let templateResult = loginTemplate(_form);
            alert(_form.errorMessages);
            return _renderHandler(templateResult);
        }

        let user = {
            username,
            password
        }

        await _authService.login(user);
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
    let templateResult = loginTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}
