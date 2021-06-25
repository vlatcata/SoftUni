function solve(){
   let createButton = document.querySelector('.site-content aside button.btn.create');
   createButton.addEventListener('click', createPost);

   function createPost(e){
      e.preventDefault();

      let authorInput = document.querySelector('#creator');
      let titleInput = document.querySelector('#title');
      let categoryInput = document.querySelector('#category');
      let contentInput = document.querySelector('#content');

      let articleElement = document.createElement('article');

      let titleHead = document.createElement('h1');
      titleHead.textContent = titleInput.value;

      let categoryParagraph = document.createElement('p');
      categoryParagraph.textContent = 'Category: '
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInput.value;
      categoryParagraph.appendChild(categoryStrong);

      let creatorParagraph = document.createElement('p');
      creatorParagraph.textContent = 'Creator: ';
      let creatorName = document.createElement('strong');
      creatorName.textContent = authorInput.value;
      creatorParagraph.appendChild(creatorName);

      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = contentInput.value;

      let buttonsDiv = document.createElement('div');
      buttonsDiv.classList.add('buttons');

      let deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.classList.add('btn', 'delete');
      deleteButton.addEventListener('click', deleteArticle)

      let archiveButton = document.createElement('button');
      archiveButton.textContent = 'Archive';
      archiveButton.classList.add('btn', 'archive');
      archiveButton.addEventListener('click', archiveArticle);

      buttonsDiv.appendChild(deleteButton);
      buttonsDiv.appendChild(archiveButton);

      articleElement.appendChild(titleHead);
      articleElement.appendChild(categoryParagraph);
      articleElement.appendChild(creatorParagraph);
      articleElement.appendChild(contentParagraph);
      articleElement.appendChild(buttonsDiv);
      
      let postsSection = document.querySelector('.site-content main section');
      postsSection.appendChild(articleElement);
   }

   function archiveArticle(e) {
      let articleToArchive = e.target.parentElement.parentElement;
      let olSection = document.querySelector('.archive-section ol');

      let archiveLis = Array.from(olSection.querySelectorAll('li'));
      let titleHeading = articleToArchive.querySelector('h1');
      let articleTitle = titleHeading.textContent;

      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitle;

      articleToArchive.remove();

      archiveLis.push(newTitleLi);
      archiveLis.sort((a, b) => a.textContent.localeCompare(b.textContent)).forEach(li => {
         olSection.appendChild(li);
      });;
   }

   function deleteArticle(e) {
      let deleteButton = e.target;
      let articleToDelete = deleteButton.parentElement.parentElement;
      articleToDelete.remove();
   }
  }
