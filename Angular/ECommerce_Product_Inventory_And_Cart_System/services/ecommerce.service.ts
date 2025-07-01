import { Product } from "../models/product.model";
import { CartItem } from "../models/cart_item.model";

export class ECommerceService {
  private products: Product[] = [];
  private cart: CartItem[] = [];

  constructor(initialProducts: Product[]) {
    this.products = initialProducts;
  }

  displayInventory(): void {
    console.log("Available Products:");
    for (const p of this.products) {
      console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
    }
  }

  addToCart(productId: number, quantity: number): void {
    const product = this.products.find(p => p.id === productId);
    if (!product) return console.log("Product not found.");
    if (product.stock < quantity) return console.log("Not enough stock.");

    const cartItem = this.cart.find(ci => ci.product.id === productId);
    if (cartItem) {
      cartItem.quantity += quantity;
    } else {
      this.cart.push({ product, quantity });
    }

    product.stock -= quantity;
    console.log(`${quantity} x ${product.name} added to cart.`);
  }

  removeFromCart(productId: number): void {
    const index = this.cart.findIndex(ci => ci.product.id === productId);
    if (index === -1) return console.log("Item not in cart.");

    const item = this.cart[index];
    item.product.stock += item.quantity;
    this.cart.splice(index, 1);

    console.log(`${item.product.name} removed from cart.`);
  }

  displayCartSummary(): void {
    console.log("Cart Summary:");
    let total = 0;
    for (const item of this.cart) {
      console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
      total += item.product.price * item.quantity;
    }

    const discountedTotal =
      total >= 10000 ? total * 0.85 :
      total >= 5000 ? total * 0.90 : total;

    console.log(`Total: ₹${total}`);
    if (total >= 5000) console.log(`Discounted Total: ₹${Math.round(discountedTotal)}`);
  }
}