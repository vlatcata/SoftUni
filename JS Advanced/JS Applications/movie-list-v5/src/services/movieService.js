let baseUrl = 'http://localhost:3030';

async function getAll() {
    let movies = await fetch(`${baseUrl}/data/movies`)
    
    return movies.json();
}

export default {
    getAll,
}