function solve(number){
    let numString = String(number);
    let isSame = true;
    let sum = numString.length > 0 ? Number(numString[0]) : 0;
    for (let i = 0; i < numString.length - 1; i++) {
        const nextElement = Number(numString[i + 1]);
        const element = Number(numString[i]);
        if (element !== nextElement) {
            isSame = false;
        }
        sum += nextElement;
    }
    console.log(isSame);
    console.log(sum);
}

solve(2222222);
solve(1234);