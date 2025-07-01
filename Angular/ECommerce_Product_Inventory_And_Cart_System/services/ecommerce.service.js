"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ECommerceService = void 0;
var ECommerceService = /** @class */ (function () {
    function ECommerceService(initialProducts) {
        this.products = [];
        this.cart = [];
        this.products = initialProducts;
    }
    ECommerceService.prototype.displayInventory = function () {
        console.log("Available Products:");
        for (var _i = 0, _a = this.products; _i < _a.length; _i++) {
            var p = _a[_i];
            console.log("".concat(p.name, " | \u20B9").concat(p.price, " | In Stock: ").concat(p.stock, " | Category: ").concat(p.category));
        }
    };
    ECommerceService.prototype.addToCart = function (productId, quantity) {
        var product = this.products.find(function (p) { return p.id === productId; });
        if (!product)
            return console.log("Product not found.");
        if (product.stock < quantity)
            return console.log("Not enough stock.");
        var cartItem = this.cart.find(function (ci) { return ci.product.id === productId; });
        if (cartItem) {
            cartItem.quantity += quantity;
        }
        else {
            this.cart.push({ product: product, quantity: quantity });
        }
        product.stock -= quantity;
        console.log("".concat(quantity, " x ").concat(product.name, " added to cart."));
    };
    ECommerceService.prototype.removeFromCart = function (productId) {
        var index = this.cart.findIndex(function (ci) { return ci.product.id === productId; });
        if (index === -1)
            return console.log("Item not in cart.");
        var item = this.cart[index];
        item.product.stock += item.quantity;
        this.cart.splice(index, 1);
        console.log("".concat(item.product.name, " removed from cart."));
    };
    ECommerceService.prototype.displayCartSummary = function () {
        console.log("Cart Summary:");
        var total = 0;
        for (var _i = 0, _a = this.cart; _i < _a.length; _i++) {
            var item = _a[_i];
            console.log("".concat(item.product.name, " - \u20B9").concat(item.product.price, " x ").concat(item.quantity));
            total += item.product.price * item.quantity;
        }
        var discountedTotal = total >= 10000 ? total * 0.85 :
            total >= 5000 ? total * 0.90 : total;
        console.log("Total: \u20B9".concat(total));
        if (total >= 5000)
            console.log("Discounted Total: \u20B9".concat(Math.round(discountedTotal)));
    };
    return ECommerceService;
}());
exports.ECommerceService = ECommerceService;
