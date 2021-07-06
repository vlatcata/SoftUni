function loadRepos() {
	let button = document.querySelector("body button");
	let url = "https://api.github.com/users/k1r1L/repos";
	let ulElement = document.getElementById("repos");
	ulElement.firstChild.remove()
	button.addEventListener("click", () => {
	  fetch(url)
		.then((response) => response.json())
		.then((data) =>
		  data.forEach((obj) => {
			let liElement = document.createElement("li");
			let anchorElement = document.createElement("A");
			anchorElement.setAttribute("href", obj.html_url);
			anchorElement.textContent = obj.full_name
			liElement.appendChild(anchorElement);
			ulElement.appendChild(liElement);
		  })
		);
	});
  }