// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
   

});

function OpenSignUp() {
    $('#SignUp-form').removeClass('hidden').addClass('visible');
    $('#Login-form').removeClass('visible').addClass('hidden');
    sessionStorage.setItem("CurrentPage", "SignUp");
}

function OpenLogIn() {
    $('#Login-form').removeClass('hidden').addClass('visible');
    $('#SignUp-form').removeClass('visible').addClass('hidden');
    sessionStorage.setItem("CurrentPage", "LogIn");
}

function Sidebartoggle() {
    var checkStatus = $('#Sidebar').clas
}