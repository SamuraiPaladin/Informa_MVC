//document.getElementById("cadastro").addEventListener('click', function () {
//    $('.collapsible-body').show();
//});

// PARALLAX
$(document).ready(function () {
    $('.parallax').parallax();
});

//MODAL
$(document).ready(function () {
    // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
    $('.modal').modal();
});

$(document).ready(function () {
    $('.datepicker').datepicker();
});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.modal');
    var instances = M.Modal.init(elems, {});
});

$(document).ready(function () {
    $('.sidenav').sidenav();
});

$(document).ready(function () {
    $('.collapsible').collapsible();
});

$(document).ready(function () {
    $('select').formSelect();
    $('.dropdown-trigger').dropdown();
});


$(document).ready(function () {
    $('select').formSelect();
    $('.dropdown-trigger2').dropdown();
});


$(document).ready(function () {
});

$(document).ready(function () {
    $('.collapsible').collapsible();
});
