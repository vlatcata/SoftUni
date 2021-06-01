function solve(arr) {
    let operands = [];
    for (let i = 0; i < arr.length; i++) {
        if (typeof arr[i] === 'number') {
            operands.push(arr[i])
        } else {
            let operator = arr[i];
            if (operands.length < 2) {
                console.log(('Error: not enough operands!'));
                break;
            }
            let operand2 = operands.pop();
            let operand1 = operands.pop();
            let result = applyOperations(operand1, operand2, operator);
            operands.push(result);
        }
    }

    if (operands.length > 1) {
        console.log('Error: too many operands!');
    } else {
        console.log(operands[0]);
    }

    function applyOperations(operand1, operand2, operator) {
        const aritpeticOperatior = {
            '+': () => operand1 + operand2,
            '-': () => operand1 - operand2,
            '/': () => operand1 / operand2,
            '*': () => operand1 * operand2,
        }

        return aritpeticOperatior[operator]();
    }
}

console.log(solve([3,
    4,
    '+']));
