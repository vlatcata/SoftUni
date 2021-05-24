function solve(number, op1, op2, op3, op4, op5) {

    number = applyOperation(number, op1);
    console.log(number);
    number = applyOperation(number, op2);
    console.log(number);
    number = applyOperation(number, op3);
    console.log(number);
    number = applyOperation(number, op4);
    console.log(number);
    number = applyOperation(number, op5);
    console.log(number);

    function applyOperation(number, op) {
        if (op == 'chop') {
            number /= 2;
        }
        else if (op == 'dice') {
            number = Math.sqrt(number);
        }
        else if (op == 'spice') {
            number += 1;
        }
        else if (op == 'bake') {
            number *= 3;
        }
        else if (op == 'fillet') {
            number *= 0.8;
        }

        return number;
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');