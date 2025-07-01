"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ECommerceService = void 0;
class ECommerceService {
    constructor(initialProducts) {
        this.products = [];
        this.cart = [];
        this.products = initialProducts;
    }
    displayInventory() {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }
    addToCart(productId, quantity) {
        const product = this.products.find(p => p.id === productId);
        if (!product)
            return console.log("Product not found.");
        if (product.stock < quantity)
            return console.log("Not enough stock.");
        const cartItem = this.cart.find(ci => ci.product.id === productId);
        if (cartItem) {
            cartItem.quantity += quantity;
        }
        else {
            this.cart.push({ product, quantity });
        }
        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }
    removeFromCart(productId) {
        const index = this.cart.findIndex(ci => ci.product.id === productId);
        if (index === -1)
            return console.log("Item not in cart.");
        const item = this.cart[index];
        item.product.stock += item.quantity;
        this.cart.splice(index, 1);
        console.log(`${item.product.name} removed from cart.`);
    }
    displayCartSummary() {
        console.log("Cart Summary:");
        let total = 0;
        for (const item of this.cart) {
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
            total += item.product.price * item.quantity;
        }
        const discountedTotal = total >= 10000 ? total * 0.85 :
            total >= 5000 ? total * 0.90 : total;
        console.log(`Total: ₹${total}`);
        if (total >= 5000)
            console.log(`Discounted Total: ₹${Math.round(discountedTotal)}`);
    }
}
exports.ECommerceService = ECommerceService;
