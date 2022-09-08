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
      <div @click="goToBooking" class="sections">
        <vue-feather
          style="margin-right: 5px"
          type="book-open"
          size="16"
        ></vue-feather>
        <h3 :class="cartListActive ? 'active' : ''">Booking</h3>
      </div>
      <h3 class="arrows">></h3>
      <div @click="goToRegiseter" class="sections" v-if="!authStore.fullName">
        <vue-feather
          style="margin-right: 5px"
          type="edit-2"
          size="16"
        ></vue-feather>
        <h3 :class="registerPage ? 'active' : ''">Register</h3>
      </div>
      <h3 v-if="!authStore.fullName" class="arrows">></h3>
      <div @click="proseedToPayment" class="sections">
        <vue-feather
          style="margin-right: 5px"
          type="dollar-sign"
          size="16"
        ></vue-feather>
        <h3 :class="paymentPage ? 'active' : ''">Checkout</h3>
      </div>
    </div>
    <div v-if="cartListActive" class="cart-area">
      <div class="activity-area">
        <div
          class="activity-List-Item"
          v-for="(activity, index) in cartItemList"
          :key="index"
        >
          <div class="content-divider">
            <div class="column activity-card">
              <h2 class="row" style="color: white">{{ activity.name }}</h2>
              <p class="row" style="color: white">{{ activity.description }}</p>
              <div class="row">
                <span>Attending: </span>
                <div class="counter">
                  <button
                    :disabled="activity.attending == 1"
                    @click="decreaseAttending(activity)"
                  >
                    <vue-feather
                      style="margin-right: 2px"
                      type="minus"
                      size="16"
                    ></vue-feather>
                  </button>
                  <output>{{ activity.attending }}</output>
                  <button @click="increaseAttending(activity)">
                    <vue-feather
                      style="margin-right: 2px"
                      type="plus"
                      size="16"
                    ></vue-feather>
                  </button>
                </div>
              </div>
            </div>
            <div class="price-area">
              <div class="price">
                <h3 style="color: white">
                  R{{ activity.price_PP.toFixed(2) }}
                </h3>
                <p style="color: white">pp</p>
              </div>
              <button class="remove-Btn" @click="removeCartItem(activity)">
                <vue-feather
                  style="margin-right: 2px"
                  type="trash-2"
                  size="16"
                ></vue-feather
                >Remove
              </button>
            </div>
          </div>
        </div>
      </div>
      <aside class="Cost-Section">
        <div class="card">
          <h2 style="color: white; margin: unset">Cost</h2>
          <div class="row">
            <h3 class="column">Activities</h3>
            <h3 class="column">Attending</h3>
            <h3 class="column">Price</h3>
          </div>
          <div
            class="row"
            v-for="(activity, index) in cartItemList"
            :key="index"
          >
            <p class="column">{{ activity.name }}</p>
            <p class="column">{{ activity.attending }}</p>
            <p class="column">
              R{{ (activity.price_PP * activity.attending).toFixed(2) }}
            </p>
          </div>
          <div>
            <p style="color: white">Total</p>
            <p style="color: white">R {{ calculatePrice }}</p>
          </div>
          <div>
            <button @click="proseedToPayment" class="checkout-Btn">
              Proceed to Payment
            </button>
          </div>
        </div>
      </aside>
    </div>
    <aside v-if="paymentPage" class="Cost-Section Payment-Area-Final">
      <div class="card">
        <h2 style="color: white; margin: unset">Cost</h2>
        <div class="row">
          <h3 class="column">Activities</h3>
          <h3 class="column">Attending</h3>
          <h3 class="column">Price</h3>
        </div>
        <div class="row" v-for="(activity, index) in cartItemList" :key="index">
          <p class="column">{{ activity.name }}</p>
          <p class="column">{{ activity.attending }}</p>
          <p class="column">
            R{{ (activity.price_PP * activity.attending).toFixed(2) }}
          </p>
        </div>
        <div>
          <p style="color: white">Total</p>
          <p style="color: white">R {{ calculatePrice }}</p>
        </div>
        <div>
          <button @click="PayWithPayFast" class="checkout-Btn">
            Pay With Payfast
          </button>
        </div>
      </div>
    </aside>
    <div>
      <form id="payfastForm" :action="payfastData.serveURL" method="post">
        <input type="hidden" name="merchant_id" :value="payfastData.merchantId">
        <input type="hidden" name="merchant_key" :value="payfastData.merchantKey">
        <input type="hidden" name="return_url" :value="payfastData.returnUrl">
        <input type="hidden" name="cancel_url" :value="payfastData.cancelUrl">
        <input type="hidden" name="notify_url" :value="payfastData.notifyUrl">
        <input type="hidden" name="name_first" :value="payfastData.name">
        <input type="hidden" name="name_last" :value="payfastData.surname">
        <input type="hidden" name="email_address" :value="payfastData.email">
        <input type="hidden" name="m_payment_id" :value="payfastData.transactionId">
        <input type="hidden" name="item_name" value="Test Product">
        <input type="hidden" name="amount" :value="payfastData.amount">
        <input type="hidden" name="signature" :value="payfastData.hash">
        <input type="submit">
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      cartItemList: [],
      cartListActive: true,
      registerPage: false,
      paymentPage: false,
      payfastData:{
        serveURL:"",
        merchantId:0,
        merchantKey:0,
        amount:0.00,
        returnUrl:"",
        notifyUrl:"",
        cancelUrl:"",
        email:"",
        name : "",
        surname : "",
        hash: "",
        transactionId:0
      }
    };
  },
  components: {},
  watch: {},
  computed: {
    calculatePrice() {
      var price = 0.0;
      this.cartItemList.forEach((element) => {
        price += element.price_PP * element.attending;
      });
      return price.toFixed(2);
    },
  },
  methods: {
    decreaseAttending(activity) {
      if (activity.attending == 1) {
        return;
      }
      activity.attending--;
      this.cartStore.updateCartItem(activity);
    },
    increaseAttending(activity) {
      activity.attending++;
      this.cartStore.updateCartItem(activity);
    },
    goToOtherPage() {
      this.$router.push("/Login");
    },
    getActivities() {
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
      };
      this.$AjaxGetAnon(`Client/ListActivities`, onSuccess);
    },
    addItemToCart(activity) {
      this.cartStore.addCartItem(activity);
      this.$toast.success(`Added ${activity.name} to Cart.`);
    },
    getCartItems() {
      this.cartItemList = this.cartStore.getCartItems;
    },
    removeCartItem(activity) {
      this.cartStore.removeCartItem(activity);
      this.getCartItems();
    },
    proseedToPayment() {
      this.cartListActive = false;
      if (!this.authStore.fullName) {
        this.registerPage = true;
        this.paymentPage = false;
      } else {
        this.paymentPage = true;
        this.registerPage = false;
      }
    },
    goToRegiseter() {
      this.paymentPage = false;
      this.cartListActive = false;
      this.registerPage = true;
    },
    goToBooking() {
      this.paymentPage = false;
      this.cartListActive = true;
      this.registerPage = false;
    },
    PayWithPayFast() {
      var self = this;
      var onSuccess = (response) => {
        self.payfastData = response;
        setTimeout(() => {
          debugger
          document.getElementById('payfastForm').submit();
        }, 100);
      };

      var dataList = this.cartItemList.map((x) => {
        return {
          activity_Id: x.activity_Id,
          attending: x.attending,
          date: null,
        };
      });
      this.$AjaxPost(`Client/PayForCart`, dataList, onSuccess);
    },
  },
  mounted() {
    this.getCartItems();
  },
};
</script>
