"use strict";
class SingleNode {
    constructor(data, next) {
        this.data = data;
        this.next = next;
    }
}
const node = new SingleNode(10);
console.log(node);
function merge(a, b) {
    return Object.assign(a, b);
}
const result = merge({ name: 'Mina' }, { age: 23 });
console.log(result);
const countAndDescribe = (a) => {
    return `${a} has ${a.length} elements`;
};
console.log(countAndDescribe('a'));
console.log(countAndDescribe([1, 2, 3]));
const extractAndConvert = (obj, key) => {
    return obj[key];
};
console.log(extractAndConvert({ a: 'J' }, 'a'));
