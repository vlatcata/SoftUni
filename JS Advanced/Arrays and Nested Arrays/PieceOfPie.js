function solve(pieArray, flavor1, flavor2) {
    let firstPieIndex = pieArray.indexOf(flavor1);
    let secondPieIndex = pieArray.indexOf(flavor2);

    let modifiedArray = pieArray.slice(firstPieIndex, secondPieIndex + 1);
    return modifiedArray;
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'));