function listProcessor(input) {
    let result = [];
    for (const string of input) {
       const [command, message] = string.split(' ');

       if (command === 'add') {
           add(message);
       } else if (command === 'remove') {
           remove(message);
       } else if (command == 'print') {
            print(message)
       }
    } 

    function add(text) {
        result.push(text);
    }
    
    function remove(text) {
        result = result.filter(x => x != text);
    }
    
    function print() {
        console.log(result.join(','));
    }
}



console.log(listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']));















