"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var category_enum_1 = require("./models/category.enum");
var ecommerce_service_1 = require("./services/ecommerce.service");
// Product catalog
var products = [
    { id: 1, name: "Laptop", price: 45000, stock: 3, category: category_enum_1.Category.Electronics },
    { id: 2, name: "Jeans", price: 1500, stock: 10, category: category_enum_1.Category.Clothing },
    { id: 3, name: "Rice Bag", price: 700, stock: 5, category: category_enum_1.Category.Grocery }
];
// Initialize service
var store = new ecommerce_service_1.ECommerceService(products);
// Simulate operations
store.displayInventory();
store.addToCart(1, 1); // Laptop
store.addToCart(2, 2); // Jeans
store.addToCart(3, 1); // Rice Bag
store.removeFromCart(2); // Remove Jeans
store.displayCartSummary();
store.displayInventory();
