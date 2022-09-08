import { defineStore } from "pinia";

var cartItemsLocal = localStorage.getItem("CartItems");

export const useCartStore = defineStore("cart", {
  state: () => ({ 
    cartItems: cartItemsLocal? JSON.parse(cartItemsLocal) : [],
    count:cartItemsLocal? JSON.parse(cartItemsLocal).length : 0,
  }),
  getters: {
    getCartItems(){
      return this.cartItems;
    },
    getCartCount(){
      return this.count;
    },
  },
  actions: {
    addCartItem(item){
      if(this.cartItems.some(x=>x.activity_Id == item.activity_Id)){
        return;
      }
      this.cartItems.push(item);
      this.count++;
      localStorage.setItem("CartItems",JSON.stringify(this.cartItems));
    },
    clearCart(){
      this.cartItems = []
      this.count = 0;
      localStorage.setItem("CartItems",JSON.stringify(this.cartItems));
    },
    removeCartItem(item){
      this.cartItems = this.cartItems.filter(!item);
      this.count--;
      localStorage.setItem("CartItems",JSON.stringify(this.cartItems));
    },
    isItemInCart(item){
      return this.cartItems.some(x=>x.activity_Id == item.activity_Id);
    }
  },
});
