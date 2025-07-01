import { Category } from "./models/category.enum";
import { Product } from "./models/product.model";
import { ECommerceService } from "./services/ecommerce.service";

// Product catalog
const products: Product[] = [
  { id: 1, name: "Laptop", price: 45000, stock: 3, category: Category.Electronics },
  { id: 2, name: "Jeans", price: 1500, stock: 10, category: Category.Clothing },
  { id: 3, name: "Rice Bag", price: 700, stock: 5, category: Category.Grocery }
];

// Initialize service
const store = new ECommerceService(products);

// Simulate operations
store.displayInventory();
store.addToCart(1, 1); // Laptop
store.addToCart(2, 2); // Jeans
store.addToCart(3, 1); // Rice Bag
store.removeFromCart(2); // Remove Jeans
store.displayCartSummary();
store.displayInventory();