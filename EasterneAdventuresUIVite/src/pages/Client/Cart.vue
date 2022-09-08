<script setup>
  import { useCartStore } from "../../store/cartStore.js";
  import { useAuthStore } from "../../store/authStore.js";
  const cartStore = useCartStore();
  const authStore = useAuthStore();
</script>

<template>
  <div ref="CartPage" id="CartPage"> 
    <h1 class="Cover-Text">Checkout</h1>
    <div class="Process-Section">
      <div @click="goToBooking" class="sections" >
        <vue-feather style="margin-right: 5px;" type="book-open" size="16"></vue-feather>
        <h3 :class="cartListActive ? 'active' :''">Booking</h3>
      </div>
      <h3 class="arrows">></h3>
      <div @click="goToRegiseter" class="sections" v-if="!authStore.fullName">
        <vue-feather style="margin-right: 5px;" type="edit-2" size="16"></vue-feather>
        <h3 :class="registerPage ? 'active' :''">Register</h3>
      </div>
      <h3 v-if="!authStore.fullName" class="arrows">></h3>
      <div @click="goToPayment" class="sections">
        <vue-feather style="margin-right: 5px;" type="dollar-sign" size="16"></vue-feather>
        <h3 :class="paymentPage ? 'active' :''">Checkout</h3>
      </div>
    </div>
    <div v-if="cartListActive" class="cart-area">
      <div class="activity-area">
        <div class="activity-List-Item" v-for="(activity, index) in cartItemList" :key="index">
          <div class="content-divider">
            <div class="column activity-card">
              <h2 class="row" style="color: white;">{{activity.name}}</h2>
              <p class="row" style="color: white;">{{activity.description}}</p>
              <div class="row">
                <span>Attending: </span>
                <div class="counter">
                  <button :disabled="activity.attending == 1" @click="decreaseAttending(activity)"><vue-feather style="margin-right: 2px;" type="minus" size="16"></vue-feather></button>
                  <output>{{activity.attending}}</output>
                  <button  @click="increaseAttending(activity)"><vue-feather style="margin-right: 2px;" type="plus" size="16"></vue-feather></button>
                </div>
              </div>
            </div>
            <div class="price-area">
              <div class="price">
                <h3 style="color: white;">R{{activity.price_PP.toFixed(2)}}</h3>
                <p style="color: white;">pp</p>
              </div>
              <button class="remove-Btn"  @click="removeCartItem(activity)"><vue-feather style="margin-right: 2px;" type="trash-2" size="16"></vue-feather>Remove</button>
            </div>
          </div>
        </div>
      </div>
      <aside class="Cost-Section">
        <div class="card">
          <h2 style="color: white; margin: unset;">Cost</h2>
          <div class="row">
            <h3 class="column">Activities</h3>
            <h3 class="column">Attending</h3>
            <h3 class="column">Price</h3>
          </div>
          <div class="row" v-for="(activity, index) in cartItemList" :key="index">
            <p class="column">{{activity.name}}</p>
            <p class="column">{{activity.attending}}</p>
            <p class="column">R{{(activity.price_PP * activity.attending).toFixed(2)}}</p>
          </div>
          <div>
            <p style="color: white;">Total</p>
            <p style="color: white;">R {{calculatePrice}}</p>
          </div>
          <div>
            <button @click="proseedToPayment" class="checkout-Btn">Proceed to Payment</button>
          </div>
        </div>
      </aside>
    </div>
  </div>
</template> 


<script>
export default {
  data() {
    return { 
      cartItemList:[],
      cartListActive:true,
      registerPage:false,
      paymentPage:false,
    } 
  },
  components:{ 
  },
  watch:{ 

  },
  computed: { 
    calculatePrice(){
      var price = 0.00;
      this.cartItemList.forEach(element => {
        price += element.price_PP  * element.attending
      });
      return price.toFixed(2);
    }
  },
  methods: { 
    decreaseAttending(activity){
      if(activity.attending == 1){
        return
      }
      activity.attending--;
      this.cartStore.updateCartItem(activity);
    },
    increaseAttending(activity){
      activity.attending++;
      this.cartStore.updateCartItem(activity);
    },
    goToOtherPage(){
      this.$router.push("/Login");
    },
    getActivities(){
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
      };
      this.$AjaxGetAnon(`Client/ListActivities`, onSuccess);
    },
    addItemToCart(activity){
      this.cartStore.addCartItem(activity);
      this.$toast.success(`Added ${activity.name} to Cart.`);
    },
    getCartItems(){
      this.cartItemList = this.cartStore.getCartItems;
    },
    removeCartItem(activity){
      this.cartStore.removeCartItem(activity);
      this.getCartItems();
    },
    proseedToPayment(){
      this.cartListActive = false;
      if(!this.authStore.fullName){
        this.registerPage = true;
      }
      else{
        this.paymentPage = true;
      }
    },
    goToPayment(){
      this.paymentPage = true;
      this.cartListActive = false;
      this.registerPage = false;
    },
    goToRegiseter(){
      this.paymentPage = false;
      this.cartListActive = false;
      this.registerPage = true;
    },
    goToBooking(){
      this.paymentPage = false;
      this.cartListActive = true;
      this.registerPage = false;
    }
  },
  mounted() { 
    this.getCartItems();
  },
}
</script>


