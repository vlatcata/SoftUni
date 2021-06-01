function solve(arr) {
    let products = {};
    for (let i = 0; i < arr.length; i++) {
        let [productName, productPrice] = arr[i].split(' : ');
        productPrice = Number(productPrice);
        let initial = productName[0].toUpperCase();

        if (products[initial] === undefined) {
            products[initial] = {};
        }
        products[initial][productName] = productPrice;
    }

    let result = [];
    let initialsSorted = Object.keys(products).sort((a, b) => a.localeCompare(b));
    for (const key of initialsSorted) {
        let productss = Object.entries(products[key]).sort((a, b) => a[0].localeCompare(b[0]));
        result.push(key);
        let productsAsStrings = productss.map(x => `  ${x[0]}: ${x[1]}`).join('\n');
        result.push(productsAsStrings);
    }

    return result;
}

console.log(solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
));