const pizzUni = require('./03.PizzaPlace');
const { expect } = require('chai');

describe('Pizza place tests', () => {
    describe('Make an order tests', () => {
        it('If only pizza is ordered, return the pizza', () => {
            let order = {
                orderedPizza: 'Margaritta'
            }

            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza}`);
        })
        it('If only drink is ordered, return the pizza', () => {
            let order = {
                orderedDrink: 'coke'
            }

            expect(() => pizzUni.makeAnOrder(order)).to.throw();
        })

        it('If both drink and pizza are ordered, return the the order', () => {
            let order = {
                orderedPizza: 'Margaritta',
                orderedDrink: 'coke'
            }

            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza} and ${order.orderedDrink}.`);
        })

        it('Throw if order is empty', () => {
            let order = {

            }

            expect(() => pizzUni.makeAnOrder(order)).to.throw();
        })

        it('Throw is there is no order', () => {

            expect(() => pizzUni.makeAnOrder()).to.throw();
        })


    })

    describe('Get remaining work tests', () => {
        it('Return orders complete message when pizza is ready', () => {
            let statusArr = [{
                pizzaName: 'Margaritta',
                status: 'ready'
            }];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
        })

        it('Return orders complete message when pizzas are ready', () => {
            let statusArr = [ 
                {pizzaName: 'Margaritta', status: 'ready'} ,
                {pizzaName: 'Vegetarian', status: 'ready'}
                ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
        })

        it('Return preparing message when pizza is ready', () => {
            let statusArr = [ 
                {pizzaName: 'Margaritta', status: 'ready'} ,
                {pizzaName: 'Vegetarian', status: 'preparing'}
                ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Vegetarian.`);
        })

        it('Return preparing message when pizzas are ready', () => {
            let statusArr = [ 
                {pizzaName: 'Margaritta', status: 'preparing'} ,
                {pizzaName: 'Vegetarian', status: 'preparing'}
                ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta, Vegetarian.`);
        })
    })

    describe('Order type tests', () => {
        it('If order type is carry out return price with discount', () => {
            let orderType = 'Carry Out';
            let totalSum = 10;

            expect(pizzUni.orderType(totalSum, orderType)).to.equal(9);
        })

        it('If order type is delivery return the full price', () => {
            let orderType = 'Delivery';
            let totalSum = 10;

            expect(pizzUni.orderType(totalSum, orderType)).to.equal(10);
        })
    })
})