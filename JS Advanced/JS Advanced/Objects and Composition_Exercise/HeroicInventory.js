function solve(arr) {
    let heroArray = [];
    for (let i = 0; i < arr.length; i++) {
        let  [name, level, items] = arr[i].split(' / ');
        level = Number(level);
        items = items !== undefined ? items.split(', ') : [];

        heroArray.push({name: name, level: level, items: items});
    }

    return JSON.stringify(heroArray);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']));