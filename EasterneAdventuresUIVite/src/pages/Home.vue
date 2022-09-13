<template>
  <div ref="HomePage" id="HomePage">
    <div class="home-content">
      <h1 class="Cover-Text">WELCOME TO ESTERNE ADVENTURES</h1>
      <h1 class="Cover-Text">Your Adventure starts here 🚀</h1>
      <div @click="goToCart" v-if="cartStore.count" class="cartIconMobile">
        <h4 >Go To Cart</h4>
        <vue-feather type="shopping-cart" size="20"></vue-feather>
        <p>{{cartStore.count}}</p>
      </div>
      <div style="display: flex; justify-content: center">
        <label  for="password" class="inp">
          <input
            v-model="activitySearch"
            @input="activitySearch = $event.target.value"
            type="text"
            id="password"
            placeholder="&nbsp;"
          />
          <span class="label">Search For An Activity</span>
          <span class="focus-bg"></span>
        </label>
      </div>
      <div class="activity-area">
        <div
          class="activity-List-Item"
          :class="index == filteredActivityList.length -1 ? 'last-item' : ''"
          v-for="(activity, index) in filteredActivityList"
          :key="index"
        >
          <div class="content-divider">
            <div class="column">
              <h2 style="color: white">{{ activity.name }}</h2>
              <p style="color: white">{{ activity.description }}</p>
            </div>
            <div class="price-area">
              <div class="price">
                <h3 style="color: white">
                  R{{ activity.price_PP.toFixed(2) }}
                </h3>
                <p style="color: white">pp</p>
              </div>
              <button
                class="cart-button add-Btn"
                v-if="!isItemInStore(activity.activity_Id)"
                @click="addItemToCart(activity)"
              >
                Add to cart
              </button>
              <button
                class="cart-button"
                v-else
                :disabled="true"
                @click="addItemToCart(activity)"
              >
                In Cart
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useCartStore } from "../store/cartStore.js";
export default {
  data() {
    return {
      cartStore:useCartStore(),
      activityList: [],
      filteredActivityList: [],
      activitySearch: "",
    };
  },
  components: {},
  watch: {
    activitySearch: function (val) {
      if (val) {
        this.filteredActivityList = this.activityList.filter((x) => {
          var lowerCase = x.name.toLowerCase();
          return lowerCase.includes(val.toLowerCase());
        });
      } else {
        this.filteredActivityList = this.activityList;
      }
    },
  },
  computed: {},
  methods: {
    goToCart(){
      this.$router.push("/Cart");
    },
    goToOtherPage() {
      this.$router.push("/Login");
    },
    getActivities() {
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
        this.filteredActivityList = this.activityList;
      };
      this.$AjaxGetAnon(`Client/ListActivities`, onSuccess);
    },
    addItemToCart(activity) {
      this.cartStore.addCartItem(activity);
      this.$toast.success(`Added ${activity.name} to Cart.`);
    },
    isItemInStore(activity_Id) {
      return this.cartStore.cartItems.some((x) => x.activity_Id == activity_Id);
    },
  },
  mounted() {
    this.getActivities();
  },
};
</script>
