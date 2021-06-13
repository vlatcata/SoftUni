function getFibonator() {
    let prev = 0;
    let curr = 1;
    let counter = 1;

    function inner() {
        if (counter == 1) {
            counter++;
            return 1;
        }
        let next = prev + curr;
        prev = curr;
        curr = next;
        return curr;
    }

    return inner;
}

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
