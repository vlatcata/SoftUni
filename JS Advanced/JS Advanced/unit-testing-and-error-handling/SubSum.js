function subSum(input, startIndex, endIndex) {
    if (!Array.isArray(input)) {
        return NaN;
    }
    if (startIndex < 0) {
        startIndex = 0;
    }
    if (endIndex < 0 || endIndex > input.length - 1) {
        endIndex = input.length - 1;
    }
    return input.slice(startIndex, endIndex + 1).reduce((a, x) => a += x, 0);
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));