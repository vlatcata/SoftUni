function loadCommits() {
    let username = document.getElementById('username');
    let repository = document.getElementById(`repo`);
    let ulCommits = document.getElementById('commits');

    let url = `https://api.github.com/repos/${username}/${repository}/commits`;

    ulCommits.textContent = '';

    fetch(url)
    .then((data) => data.json())
    .then(commits => {
        commits.forEach(e => {
            let liElement = document.createElement('li');
            liElement.textContent = `${e.commit.author.name}: ${e.commit.message}`;
            ulCommits.appendChild(liElement);
        });
    })
    .catch(error => {
        let liItem = document.createElement('li');
        liItem.textContent = `Error: ${error.status} (Not Found)`;
        ulCommits.appendChild(liItem);
    })
}