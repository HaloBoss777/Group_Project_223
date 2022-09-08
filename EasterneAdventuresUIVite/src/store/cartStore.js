import { defineStore } from "pinia";
export const useCartStore = defineStore("cart", {
  state: () => ({ 
    cartItems: [],
    count:0,
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
    },
    clearCart(){
      this.cartItems = []
      this.count = 0;
    },
    removeCartItem(item){
      this.cartItems = this.cartItems.filter(!item);
      this.count--;
    },
    isItemInCart(item){
      return this.cartItems.some(x=>x.activity_Id == item.activity_Id);
    }
  },
});
