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
              <div style="margin-top: 20px" class="row date-selector-are">
                <vue-feather
                  class="dateSelect"
                  type="calendar"
                  size="16"
                ></vue-feather>
                <p style="margin: 0; color: white; margin-right: 10px">
                  Pick Date
                </p>
                <datepicker v-model="activity.date" />
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
      <aside class="Cost-Section last-item">
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
    <aside class="last-item" v-if="registerPage">
      <div ref="LoginPage" class="CartLoginPage" id="LoginPage">
        <div class="login-Page">
          <h2 class="Title">{{ haveAnAccount ? "Login" : "Register" }}</h2>
          <h3 style="color: red" v-if="errorMessage">{{ errorMessage }}</h3>
          <label for="email" class="inp">
            <input
              v-model="formData.email"
              @input="formData.email = $event.target.value"
              type="email"
              id="email"
              placeholder="&nbsp;"
            />
            <span class="label">Email</span>
            <span class="focus-bg"></span>
          </label>
          <label v-if="!haveAnAccount" for="password" class="inp">
            <input
              v-model="formData.full_name"
              @input="formData.full_name = $event.target.value"
              type="text"
              id="password"
              placeholder="&nbsp;"
            />
            <span class="label">Full Name</span>
            <span class="focus-bg"></span>
          </label>
          <label v-if="!haveAnAccount" for="password" class="inp">
            <input
              v-model="formData.cellNum"
              @input="formData.cellNum = $event.target.value"
              type="number"
              id="password"
              placeholder="&nbsp;"
            />
            <span class="label">Cell Number</span>
            <span class="focus-bg"></span>
          </label>
          <label v-if="!haveAnAccount" for="password" class="inp">
            <input
              v-model="formData.rSA_ID"
              @input="formData.rSA_ID = $event.target.value"
              type="text"
              id="password"
              placeholder="&nbsp;"
            />
            <span class="label">RSA ID</span>
            <span class="focus-bg"></span>
          </label>
          <label for="password" class="inp">
            <input
              v-model="password"
              @input="password = $event.target.value"
              type="password"
              id="password"
              placeholder="&nbsp;"
            />
            <span class="label">Password</span>
            <span class="focus-bg"></span>
          </label>
          <a class="mt-1" href="#" @click="goToLogin">{{!haveAnAccount ? 'I have an account' : 'I need an account'}}</a>
          <button
            class="action-button Login-Btn"
            @click="handleSignInOrRegister"
          >
            {{ !haveAnAccount ? "Register" : "Login" }}
          </button>
        </div>
      </div>
    </aside>
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
        <input
          type="hidden"
          name="merchant_id"
          :value="payfastData.merchantId"
        />
        <input
          type="hidden"
          name="merchant_key"
          :value="payfastData.merchantKey"
        />
        <input type="hidden" name="return_url" :value="payfastData.returnUrl" />
        <input type="hidden" name="cancel_url" :value="payfastData.cancelUrl" />
        <input type="hidden" name="notify_url" :value="payfastData.notifyUrl" />
        <input type="hidden" name="name_first" :value="payfastData.name" />
        <input type="hidden" name="name_last" :value="payfastData.surname" />
        <input type="hidden" name="email_address" :value="payfastData.email" />
        <input
          type="hidden"
          name="m_payment_id"
          :value="payfastData.transactionId"
        />
        <input type="hidden" name="item_name" value="Test Product" />
        <input type="hidden" name="amount" :value="payfastData.amount" />
        <input type="hidden" name="signature" :value="payfastData.hash" />
      </form>
    </div>
  </div>
</template>

<script>
import Datepicker from "vue3-datepicker";
import md5 from "md5"
export default {
  data() {
    return {
      formData: {
        email: "",
        passwordHash: "",
        full_name: "",
        cellNum: "",
        rSA_ID: "",
      },
      haveAnAccount: false,
      password: "",
      errorMessage: "",
      cartItemList: [],
      cartListActive: true,
      registerPage: false,
      paymentPage: false,
      payfastData: {
        serveURL: "",
        merchantId: 0,
        merchantKey: 0,
        amount: 0.0,
        returnUrl: "",
        notifyUrl: "",
        cancelUrl: "",
        email: "",
        name: "",
        surname: "",
        hash: "",
        transactionId: 0,
      },
    };
  },
  components: {
    Datepicker,
  },
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
    validate(){
      var emailValid = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(this.formData.email);
      if(!this.formData.email || !emailValid){
        this.$toast.error(`Email is invalid`);
        return ;
      }
      if(!this.formData.full_name || this.formData.full_name.length < 2){
        this.$toast.error(`Full Name is invalid`);
        return ;
      }
      if(!this.formData.cellNum || this.formData.cellNum.length != 10){
        this.$toast.error(`Cell Number is invalid`);
        return ;
      }
      if(!this.formData.rSA_ID || this.formData.rSA_ID.length != 13){
        this.$toast.error(`RSA ID is invalid`);
        return ;
      }
      if(!this.password || this.password.length < 8){
        this.$toast.error(`Password is invalid`);
        return ;
      }
      this.register();
    },
    goToLogin() {
      this.haveAnAccount = !this.haveAnAccount;
    },
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
      this.cartItemList.forEach((element) => {
        element.date = new Date();
      });
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
          document.getElementById("payfastForm").submit();
        }, 100);
      };

      var dataList = this.cartItemList.map((x) => {
        return {
          activity_Id: x.activity_Id,
          attending: x.attending,
          date: x.date,
        };
      });
      this.$AjaxPost(`Client/PayForCart`, dataList, onSuccess);
    },
    checkForPayment() {
      if (!this.$route.query) {
        return;
      }
      switch (this.$route.query.status) {
        case "Canceled":
          this.canclePopup();
          break;
        case "Success":
          this.successPOPUP();
          break;
        default:
          break;
      }
    },
    successPOPUP() {
      this.cartStore.clearCart();
      this.$swal.fire({
        title: `Your Transaction was Successfull`,
        showCancelButton: false,
        confirmButtonText: `Thank you`,
      }).then((result) =>{
        this.$router.push("/Home");
        this.$router.push("/Home");
      });
    },
    canclePopup() {
      this.$swal.fire({
        title: `Your Transaction was canceled`,
        showCancelButton: false,
        confirmButtonText: `Ok`,
      }).then((result) =>{
        this.$router.push("/Home");
        this.$router.push("/Home");
      });;
    },
    login(){
      var self = this;
      var passwordHash = md5(this.password);
      var dataToSend = {
        passwordHash: passwordHash,
        userName: this.formData.email
      }
      var onSuccess = response =>{
        self.handleSigninUser(response);
      }

      var onFail = response =>{
        self.errorMessage = "Details are Incorrect";
        setTimeout(() => {
          self.errorMessage = "";
        }, 5000);
      }
      this.$AjaxPostLogin(`Authentication/SignIn`,dataToSend,onSuccess,onFail);
    },
    register(){
      var self = this;
      var onSuccess = response =>{
        self.handleSigninUser(response);
      }

      var onError = response =>{
        if(response.response.data.includes("User exists")){
          this.$toast.error(`User exists`);
          this.errorMessage = "User Exists"
        }
        else{
          this.$toast.error(`Error`);
          this.errorMessage = "Error"
        }
        setTimeout(() => {
          self.errorMessage = ""
        }, 5000);
      }
      var dataToSend = {
        email:self.formData.email,
        passwordHash:md5(self.password),
        full_name:self.formData.full_name,
        cellNum:self.formData.cellNum,
        rSA_ID:self.formData.rSA_ID
      }
      self.$AjaxPostLogin("Client/Register" , dataToSend , onSuccess, onError);
    },
    handleSigninUser(data){
      if(data.isClient){
        this.authStore.setClient_Id(data.id);
      }
      else{
        this.authStore.setEmp_Id(data.id);
        this.authStore.setIsEmployee(true);
      }
      this.authStore.setIsAdmin(data.isAdmin);
      this.authStore.setIsInstructor(data.isInstructor);
      this.authStore.setJwtToken(data.apiToken);
      this.authStore.setName(data.fullName);

      localStorage.setItem("userData",JSON.stringify(data));
      this.proseedToPayment();
    },
    handleSignInOrRegister(){
      if(this.haveAnAccount){
        this.login();
      }
      else{
        this.validate();
      }
    }
  },
  mounted() {
    this.checkForPayment();
    this.getCartItems();
  },
};
</script>
