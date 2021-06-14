const isSymmetric = require('../isSymetric');
const { assert } = require('chai');

describe('Test isSymetric fucntionality', () => {
    it('Should pass when symetric array is provided', () => {
        let arr = [1, 2, 3, 2, 1];
        let expectedResult = true;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });

    it('Should not pass when array in not provided', () => {
        let arr = 3;
        let expectedResult = false;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });

    it('Should not pass when array in not symetric', () => {
        let arr = [1, 2, 3, 3, 1];
        let expectedResult = false;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });

    it('Should not pass when input not correct type', () => {
        let expectedResult = false;

        assert.equal(isSymmetric(''), expectedResult);
        assert.equal(isSymmetric({}), expectedResult);
        assert.equal(isSymmetric(2), expectedResult);
        assert.equal(isSymmetric(0), expectedResult);
        assert.equal(isSymmetric(true), expectedResult);
        assert.equal(isSymmetric(undefined), expectedResult);
    });

    it('Should pass when string array is provided', () => {
        let arr = ['1', '2', '3', '2', '1'];
        let expectedResult = true;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });

    it('Should not pass when string and num', () => {
        let arr = ['1', 2];
        let expectedResult = false;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });

    it('Should not pass when string', () => {
        let arr = 'Pesho';
        let expectedResult = false;

        let actualResult = isSymmetric(arr);

        assert.equal(actualResult, expectedResult);
    });
});