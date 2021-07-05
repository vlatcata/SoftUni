const sum = require('../sumofNumbers');
const { assert } = require('chai');

describe('SumofNumbers tests', () => {
    it('Should take an array of numbers argument', () => {
        let arr = [1, 2, 3];
        let expectedResult = 6;

        let actualResult = sum(arr);
        assert.equal(expectedResult, actualResult);
    });

    it('Should take an array of strings argument', () => {
        let arr = ['1', '2', '3'];
        let expectedResult = 6;

        let actualResult = sum(arr);
        assert.equal(expectedResult, actualResult);
    });

    it('Should take a single number', () => {
        let arr = [1];
        let expectedResult = 1;

        let actualResult = sum(arr);
        assert.equal(expectedResult, actualResult);
    });
});