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

    const { expect, assert } = require('chai');

    describe("numberOperations", function() {
        describe("powNumber", function() {
            it("Expect to return number * number", function() {
                expect(numberOperations.powNumber(2)).to.equal(4);
                expect(numberOperations.powNumber(-3)).to.equal(9);
                expect(numberOperations.powNumber('2')).to.equal(4);
                expect(numberOperations.powNumber('-3')).to.equal(9);
            });

            it("Expect to return number * number", function() {
                assert.isNaN(numberOperations.powNumber(NaN));
            });
         });

         describe("numberChecker", function() {
            it("Throw if input is NaN", function() {
                expect(() => numberOperations.numberChecker('abs')).to.throw('The input is not a number!');
            });

            it("Throw if input is lower than 100", function() {
                expect(numberOperations.numberChecker('90')).to.equal('The number is lower than 100!');
            });

            it("Throw if input is lower than 100", function() {
                expect(numberOperations.numberChecker('')).to.equal('The number is lower than 100!');
            });

            it("Throw if input bigger than 100", function() {
                expect(numberOperations.numberChecker(101)).to.equal('The number is greater or equal to 100!');
            });

            it("Throw if input is NaN", function() {
                expect(() => numberOperations.numberChecker(undefined)).to.throw('The input is not a number!');
            });
         });

         describe("sumArrays", function() {
            it("Return correct output with valid input", function() {
                expect(numberOperations.sumArrays([1, 2, 3], [2, 3, 4])).to.deep.equal([3, 5, 7]);
            });

            it("Return correct output with valid string input", function() {
                expect(numberOperations.sumArrays(['1', '2', '3'], ['2', '3', '4'])).to.deep.equal(['12', '23', '34']);
                expect(numberOperations.sumArrays(['a', 'b', 'c'], ['d', 'e', 'f'])).to.deep.equal(['ad', 'be', 'cf']);
            });

            it("Return correct output with valid inputs and a longer array", function() {
                expect(numberOperations.sumArrays([1, 2, 10], [2, 3])).to.deep.equal([3, 5, 10]);
                expect(numberOperations.sumArrays(['a', 'b', 'c'], ['d', 'e'])).to.deep.equal(['ad', 'be', 'c']);
            });

            it("Return empty array when empty arrays are given", function() {
                expect(numberOperations.sumArrays([], [])).to.deep.equal([]);
            });

            it("Return correct answer when only one array is given", function() {
                expect(numberOperations.sumArrays([], [1, 2, 3])).to.deep.equal([1, 2, 3]);
            });
         });
    });
    
    
    