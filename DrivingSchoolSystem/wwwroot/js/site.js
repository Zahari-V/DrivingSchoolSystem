// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const navLinks = Array.from(document.querySelectorAll(".nav-menu-container > li > a"));

if (!sessionStorage.getItem('clickedNavId')) {
    navLinks[0].classList.add('clicked-link');
}

for (var i = 0; i < navLinks.length; i++) {
    navLinks[i].addEventListener('click', clickedNavLink)
}

const loginBtn = document.getElementById('login');
const registerBtn = document.getElementById('register');
const logoutBtn = document.getElementById('logout');
const userBtns = [loginBtn, registerBtn, logoutBtn];

for (var btn of userBtns) {
    if (btn) {
        btn.addEventListener('click', clickedNavLink);
    }
}

let clickedNavId = sessionStorage.getItem('clickedNavId');

if (clickedNavId) {
    if (clickedNavId === 'logout') {
        clickedNavId = 'nav1';
    }

    if (document.cookie.includes("IsAuthenticated")) {
        clickedNavId = 'nav1';
        document.cookie += '; Max-Age=0';
    }

    if (!(clickedNavId === 'login' || clickedNavId === 'register')) {
        const clickedNav = document.getElementById(clickedNavId);
        clickedNav.classList.add('clicked-link');
    }
}

function clickedNavLink(e) {
    sessionStorage.removeItem('clickedNavId');
    sessionStorage.setItem('clickedNavId', e.currentTarget.id);
}