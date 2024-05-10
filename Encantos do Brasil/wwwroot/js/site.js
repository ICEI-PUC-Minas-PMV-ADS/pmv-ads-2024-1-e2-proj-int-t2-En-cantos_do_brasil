// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    var container = document.querySelector('.container');
    var items = container.querySelectorAll('.item');

    for (var i = 0; i < items.length; i += 4) {
        var group = Array.prototype.slice.call(items, i, i + 4);
        var row = document.createElement('div');
        row.classList.add('row');

        group.forEach(function (item) {
            row.appendChild(item);
        });

        container.appendChild(row);
    }
});
