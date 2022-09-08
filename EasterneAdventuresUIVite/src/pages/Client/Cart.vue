<script setup>
  import { useCartStore } from "../../store/cartStore.js";
  const cartStore = useCartStore();
</script>

<template>
  <div ref="CartPage" id="CartPage"> 
    <h1 class="Cover-Text">Checkout</h1>
    <div class="cart-area">
      <div class="activity-area">
        <div class="activity-List-Item" v-for="(activity, index) in cartItemList" :key="index">
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
            </div>
          </div>
        </div>
      </div>
      <aside class="Cost-Section">
        <div class="card">
          Cost
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
    getCartItems(){
      this.cartItemList = this.cartStore.getCartItems;
    }
  },
  mounted() { 
    this.getCartItems();
  },
}
</script>


