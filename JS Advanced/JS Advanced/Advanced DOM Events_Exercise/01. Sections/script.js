function create(words) {
   let contentElement = document.getElementById('content');

   words.forEach(section => {
      let div = document.createElement('div');
      let p = document.createElement('p');

      p.textContent = section;
      p.style.display = 'none';
      div.appendChild(p);
      contentElement.appendChild(div);
      div.addEventListener('click', (e) => {
         e.target.children[0].style.display = 'block';
      })
   });
}