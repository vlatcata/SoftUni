function solve(num1, num2, input){
    let result;
    if (input == '+') {
        result = num1 + num2;
    }
    else if (input == '-') {
        result = num1 - num2;
    }
    else if (input == '*') {
        result = num1 * num2;
    }
    else if (input == '/') {
        result = num1 / num2;
    }
    else if (input == '%') {
        result = num1 % num2;
    }
    else if (input == '**') {
        result = num1 ** num2;
    }

    console.log(result);
}

solve(5, 6, '+');