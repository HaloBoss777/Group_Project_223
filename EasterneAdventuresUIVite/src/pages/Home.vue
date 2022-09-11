<script setup>
  import { useCartStore } from "../store/cartStore.js";
  const cartStore = useCartStore();
</script>

<template>
  <div ref="HomePage" id="HomePage"> 
    <div class="background-section">
      <img src="../assets/Background_Images1.png" alt=""> 
    </div>
  
<div class="home-content">
      <h1 class="Cover-Text">WELCOME TO ESTERNE ADVENTURES</h1>
    <h1 class="Cover-Text">Adventure starts here 🚀</h1>
    <div style="display: flex; justify-content: center;">
      <label v-if="!haveAnAccount" for="password" class="inp">
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
      <div class="activity-List-Item" v-for="(activity, index) in filteredActivityList" :key="index">
        <div class="content-divider">
          <div class="column">
            <h2 style="color: white;">{{activity.name}}</h2>
            <p style="color: white;">{{activity.description}}</p>
          </div>
          <div class="price-area">
            <div class="price">
              <h3 style="color: white;">R{{activity.price_PP.toFixed(2)}}</h3>
              <p style="color: white;">pp</p>
            </div>
            <button class="cart-button add-Btn" v-if="!isItemInStore(activity.activity_Id)" @click="addItemToCart(activity)" >Add to cart</button>
            <button class="cart-button" v-else :disabled="true" @click="addItemToCart(activity)">In Cart</button>
          </div>
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
      filteredActivityList:[],
      activitySearch:""
    } 
  },
  components:{ 
  },
  watch:{ 
    activitySearch:function(val){
      if(val){
        this.filteredActivityList = this.activityList.filter(x=>{
          var lowerCase = x.name.toLowerCase();
          return lowerCase.includes(val.toLowerCase())
        });
      }
      else{
        this.filteredActivityList = this.activityList
      }
    }
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
        this.filteredActivityList = this.activityList
      };
      this.$AjaxGetAnon(`Client/ListActivities`, onSuccess);
    },
    addItemToCart(activity){
      this.cartStore.addCartItem(activity);
      this.$toast.success(`Added ${activity.name} to Cart.`);
    },
    isItemInStore(activity_Id){
      return this.cartStore.cartItems.some(x=>x.activity_Id== activity_Id);
    },
  },
  mounted() { 
    this.getActivities();
  },
}
</script>


