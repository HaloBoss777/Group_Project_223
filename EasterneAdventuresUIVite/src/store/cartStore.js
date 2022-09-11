import { defineStore, acceptHMRUpdate  } from "pinia";

var cartItemsLocal = localStorage.getItem("CartItems");

export const useCartStore = defineStore({
  id:"cart",
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
      this.cartItems = this.cartItems.filter(x=>x.activity_Id != item.activity_Id);
      this.count--;
      localStorage.setItem("CartItems",JSON.stringify(this.cartItems));
    },
    updateCartItem(item){
      var index = this.cartItems.findIndex(x=>x.activity_Id == item.activity_Id);
      this.cartItems[index].attending = item.attending;
      localStorage.setItem("CartItems",JSON.stringify(this.cartItems));
    },
    isItemInCart(item){
      return this.cartItems.some(x=>x.activity_Id == item.activity_Id);
    }
  },
});

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useCartStore, import.meta.hot))
}
