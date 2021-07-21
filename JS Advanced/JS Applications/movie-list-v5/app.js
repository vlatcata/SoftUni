import { render, html } from './node_modules/lit-html/lit-html.js';
import movieListTemplate from './src/templates/movieListTemplate.js';
import movieService from './src/services/movieService.js';

let rootElement = document.querySelector('#root');

function onDetailsClickHanlder(e) {
    console.log(e);
} 

async function displayAllMovies(){
    let movies = await movieService.getAll();

    movies[0].onDetailsClick = onDetailsClickHanlder;

    let displayMovies = movieListTemplate(movies);
    render(displayMovies, rootElement);
}

displayAllMovies();