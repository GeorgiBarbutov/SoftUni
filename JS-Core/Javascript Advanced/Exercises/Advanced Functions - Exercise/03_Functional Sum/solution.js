let a = (function add(){
    let sum = 0;

    function func (number) {
        sum += number;

        return func;
    }

    func.toString = () => {return sum};

    return func;
})();

console.log(a(1)(2))//(1);
a(1);
a(1);


