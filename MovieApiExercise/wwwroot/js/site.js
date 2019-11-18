// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = 'http://simonsmoviebooking.azurewebsites.net/api/movie';
var movies = [];


function getMovies() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get movies', error));
}


function _displayItems(data) {
    const mContainer = document.getElementById('MovieContainer');
    mContainer.innerHTML = '';


    data.forEach(item => {
        //New Row
        document.createElement("tr");

        document.createElement("th");
        document.createElement("p").innerHTML(item.id);
        //ID
        //Title
        //Genre
        //Description
        //Number of Seats
    });

    movies = data;
}