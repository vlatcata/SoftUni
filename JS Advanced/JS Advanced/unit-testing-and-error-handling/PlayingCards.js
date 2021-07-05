function solve(face, suit) {
    const type = {
        faces: ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'],
        suits: { S: '\u2660', H: '\u2665', D: '\u2666', C: '\u2663'},
        toString() {
            return `${face}${type.suits[suit]}`;
        }
    }

    if (!type.faces.includes(face) || !type.suits[suit]) {
        throw new Error();
    } else {
        return type.toString();
    }
}

console.log(solve('A', 'S'));
console.log(solve('10', 'H'));
console.log(solve('1', 'C'));

