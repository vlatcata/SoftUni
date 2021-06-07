function solve() {
   let textAreaElement = document.querySelector('textarea');
   let addProductButtons = document.querySelectorAll('.add-product');
   let checkoutButton = document.querySelector('.checkout');
   let totalMoney = 0;
   let products = [];

   for (const button of addProductButtons) {
      button.addEventListener('click', (e) => {
         let currentProduct = e.currentTarget.parentElement.parentElement;
         let productName = currentProduct.querySelector('.product-title').textContent;
         let productPrice = currentProduct.querySelector('.product-line-price').textContent;

         products.push(productName);
         productPrice = Number(productPrice);
         totalMoney += productPrice;
         console.log(productName);
         console.log(productPrice);
         textAreaElement.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
      });
   }

   checkoutButton.addEventListener('click', (e) => {
      let uniqueProducts = products.reduce((a, x) => {
         if (!a.includes(x)) {
            a.push(x);
         }
         return a;
      }, []);
      for (const button of addProductButtons) {
         button.disabled = true;
      }
      checkoutButton.disabled = true;
      textAreaElement.textContent += `You bought ${uniqueProducts.join(', ')} for ${totalMoney.toFixed(2)}.`;
   }); 
}