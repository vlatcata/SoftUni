function extensibleObject() {
    let proto = {};
    let extObj = Object.create(proto);
    extObj.extend = function(obj) {
        for (const key in obj) {
            if (typeof obj[key] === 'function') {
                let proto = Object.create(this);
                proto[key] = obj[key];
            } else {
                this[key] = obj[key];
            }
        }
    }
}