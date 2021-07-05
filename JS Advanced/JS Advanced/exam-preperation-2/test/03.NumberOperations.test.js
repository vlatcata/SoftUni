const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};

const { expect } = require('chai');

describe("Number operations Tests", function() {
    describe("powNumber", function() {
        it("Should return Number * Number", function() {
            expect(numberOperations.powNumber(3)).to.equal(9);
            expect(numberOperations.powNumber('-3')).to.equal(9);
        });
     });

     describe("numberChecker", function() {
        it("Should throw if not a number", function() {
            expect(() => numberOperations.numberChecker('asd')).to.throw('The input is not a number!');
        });

        it("Should throw if not a number 2", function() {
            expect(() => numberOperations.numberChecker(undefined)).to.throw('The input is not a number!');
        });

        it("Should throw if number < 100", function() {
            expect(numberOperations.numberChecker(99)).to.equal('The number is lower than 100!');
        });

        it("Should return number if > 100", function() {
            expect(numberOperations.numberChecker(101)).to.equal('The number is greater or equal to 100!');
        });
     });

     describe("sumArrays", function() {
        it("Should return correct answer 1", function() {
            expect(numberOperations.sumArrays([1, 2, 3], [2, 3 , 4])).to.deep.equal([3, 5, 7]);
        });

        it("Should return correct answer 2", function() {
            expect(numberOperations.sumArrays(['1', '2', '3'], ['2', '3', '4'])).to.deep.equal(['12', '23', '34']);
        });

        it("Should return correct answer 3", function() {
            expect(numberOperations.sumArrays(['1', '2', '4'], ['2', '3'])).to.deep.equal(['12', '23', '4']);
        });

        it("Should return correct answer 4", function() {
            expect(numberOperations.sumArrays([1, 2, 4], [2, 3])).to.deep.equal([3, 5, 4]);
        });

        it("Should return correct answer 5", function() {
            expect(numberOperations.sumArrays([1, 2, 4], [])).to.deep.equal([1, 2, 4]);
        });
     });
});
