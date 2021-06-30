const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};


const { expect } = require('chai');

describe("testNumbers", function() {
    describe("sumNumbers", function() {
        it("Test sum numbers 1", function() {
            expect(testNumbers.sumNumbers(1.10, 2)).to.equal('3.10');
        });

        it("Test sum numbers 2", function() {
            expect(testNumbers.sumNumbers('asd', 2)).to.equal(undefined);
        });

        it("Test sum numbers 3", function() {
            expect(testNumbers.sumNumbers(1, 'ss')).to.equal(undefined);
        });

        it("Test sum numbers 4", function() {
            expect(testNumbers.sumNumbers(-1, -2)).to.equal('-3.00');
        });
     });

     describe("numberChecker", function() {
        it("Test numberChecker 1", function() {
            expect(() => testNumbers.numberChecker('asd')).to.throw('The input is not a number!');
        });

        it("Test numberChecker 2", function() {
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
        });

        it("Test numberChecker 3", function() {
            expect(testNumbers.numberChecker(3)).to.equal('The number is odd!');
        });
     });

     describe("averageSumArray", function() {
        it("Test averageSumArray 1", function() {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.equal(2);
        });

        it("Test averageSumArray 2", function() {
            expect(testNumbers.averageSumArray([1])).to.equal(1);
        });

        it("Test averageSumArray 3", function() {
            expect(testNumbers.averageSumArray([0])).to.equal(0);
        });
     })
});
    
