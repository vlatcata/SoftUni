function solve(inputArr) {
    let obj = {};
    inputArr.forEach((el, i) => {
        if (i % 2 == 0) {
            obj[el] = Number(inputArr[i + 1]);
        }
    });
    return obj;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));