(function solve() {

    Array.prototype.last = function() {
        return this[this.length - 1];
    }
    
    Array.prototype.skip = function(n) {
        let result = [];
        this.forEach((num, index) => index >= n ? result.push(num) : undefined);
        return result;
    }
    
    Array.prototype.take = function(n) {
        let result = [];
        this.forEach((num, index) => index <= n - 1 ? result.push(num) : undefined);
        return result;
    }
    
    Array.prototype.sum = function() {
        let result = 0;
        this.forEach(e => {
            result += e;
        });
        return result;
    }
    
    Array.prototype.average = function() {
        let sum = this.reduce((a, b) => a + b, 0);
        let average = sum / this.length;
        return average;
    }
}())

console.log(myArr.last());
console.log(myArr.skip(3));
console.log(myArr.take(2));
console.log(myArr.sum());
console.log(myArr.average());