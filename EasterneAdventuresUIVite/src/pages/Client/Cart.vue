<script setup>
  import { useCartStore } from "../../store/cartStore.js";
  const cartStore = useCartStore();
</script>

<template>
  <div ref="Cart" id="Cart"> 
    <h1 class="Cover-Text">Cart Section</h1>
    <h1 class="Cover-Text">Adventure starts here 🚀</h1>
    <input type="text" placeholder="search for Activity">
    <div class="activity-area">
      <div class="activity-List-Item" v-for="(activity, index) in activityList" :key="index">
        <div class="content-divider">
          <div class="column">
            <h2 style="color: white;">{{activity.name}}</h2>
            <p style="color: white;">{{activity.description}}</p>
          </div>
          <div class="price-area">
            <div class="price">
              <h3 style="color: white;">R{{activity.price_PP}}</h3>
              <p style="color: white;">pp</p>
            </div>
            <h2 style="color: white;">{{activity.name}}</h2>
            <button class="cart-button" v-if="isItemInStore(activity.activity_Id)" >Add to cart</button>
            <button class="cart-button" v-else :disabled="true" @click="addItemToCart(activity)" >In Cart</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template> 


<script>
export default {
  data() {
    return { 
      activityList:[],
    } 
  },
  components:{ 
  },
  watch:{ 

  },
  computed: { 
    
  },
  methods: { 
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
  },
  mounted() { 
  },
}
</script>


