function createSortedList() {
    return {
        size: 0,
        list: [],
        add(num) {
            this.list.push(num);
            this.size++;
            this.list.sort((a, b) => a - b);
        },
        remove(index) {
            if (index >= 0 && index < this.list.length) {
                this.list.splice(index, 1);
            this.size--;
            }
        },
        get(index) {
            if (index >= 0 && index < this.list.length) {
            return this.list[index];
            }
        },
    };
}


let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
