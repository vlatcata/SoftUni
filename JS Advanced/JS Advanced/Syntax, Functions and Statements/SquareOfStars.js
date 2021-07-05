function solve(input){
    let result = "";
    if (input == null) {
        for (let i = 0; i < 5; i ++){
            for (let j = 0; j < 5; j ++){
                result += "*"
            }
            result += "\n"
        }
    }

    for (let i = 0; i < input; i ++){
        for (let j = 0; j < input; j ++){
            result += "*" + " ";
        }
        result += "\n";
    }

    console.log(result);
}

solve(5);