<template>
  <div class="app-content-header">
      <h1 class="app-content-headerText">Products</h1>
      <button v-if="!addActivivityOpen" @click="addNewProduct" class="app-content-headerButton">Add Product</button>
    </div>
    <div v-if="!addActivivityOpen" class="app-content-actions">
      <input class="search-bar" placeholder="Search..." type="text">
      <div class="app-content-actions-wrapper">
        <button @click="setList" class="action-button list" :class="listViewActive ? 'active' : ''" title="List View">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-list"><line x1="8" y1="6" x2="21" y2="6"/><line x1="8" y1="12" x2="21" y2="12"/><line x1="8" y1="18" x2="21" y2="18"/><line x1="3" y1="6" x2="3.01" y2="6"/><line x1="3" y1="12" x2="3.01" y2="12"/><line x1="3" y1="18" x2="3.01" y2="18"/></svg>
        </button>
        <button @click="setGrid" class="action-button grid" :class="!listViewActive ? 'active' : ''" title="Grid View">
          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-grid"><rect x="3" y="3" width="7" height="7"/><rect x="14" y="3" width="7" height="7"/><rect x="14" y="14" width="7" height="7"/><rect x="3" y="14" width="7" height="7"/></svg>
        </button>
      </div>
    </div>
    <div v-if="!addActivivityOpen"  class="products-area-wrapper" :class="listViewActive ? 'tableView' : 'gridView'">
      <div class="products-header">
        <div class="product-cell image">
          Name
          <button class="sort-button">
            <vue-feather type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Description
          <button class="sort-button">
            <vue-feather type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Price
          <button class="sort-button">
            <vue-feather type="arrow-up"></vue-feather>
          </button>
        </div>
      </div>
      <div class="products-row" v-for="(activity, index) in activityList" :key="index">
        <div class="product-cell category">
          <span>{{activity.name}}</span>
        </div>
        <div class="product-cell category">
          <span>{{activity.description}}</span>
        </div>
        <div class="product-cell category">
          <span>R{{activity.price_PP}}</span>
        </div>
      </div>
      

    </div>
    <div v-if="addActivivityOpen">
      <div>
        <label for="ActivityName">Name</label>
        <input @input.lazy="formData.name = $event.target.value"  id="ActivityName" type="text" placeholder="Name">
        <input @input.lazy="formData.description = $event.target.value"  type="text" placeholder="Description">
        <input @input.lazy="formData.price_PP = $event.target.value"  type="text" placeholder="Price_PP">
      </div>
      <div>
        <button class="app-content-cancelButton" @click="cancelAdd">Cancel</button>
        <button class="app-content-headerButton" @click="addNewItem">Add</button>
      </div>
    </div>
</template> 


<script>
export default {
  data() {
    return { 
      listViewActive:true,
      activityList:[],
      addActivivityOpen:false,
      formData:{
        activity_Id:0,
        name : null,
        description: null,
        price_PP:null
      }
    }
  },
  components:{ 

  },
  watch:{ 

  },
  computed: { 

  },
  methods: { 
    changeViews(){
      this.listViewActive = !this.listViewActive;
    },
    setList(){
      this.listViewActive = true
    },
    setGrid(){
      this.listViewActive = false
    },
    getActivityList(){
      var self = this;
      var onSuccess = response =>{
        self.activityList = response;
      }
      this.$AjaxGet(`Admin/ListActivities`,onSuccess);
    },
    addNewProduct(){
      this.addActivivityOpen = true;
    },
    cancelAdd(){
      this.addActivivityOpen = false;
    },
    addNewItem(){
      debugger
      var self = this;
      var dataToSend = {
        activity_Id:this.formData.activity_Id,
        name : this.formData.name,
        description: this.formData.description,
        price_PP:parseFloat(this.formData.price_PP)
      };

      var onSuccess = response =>{
        debugger
        if(response){
          self.cancelAdd();
        }
      }
      this.$AjaxPostAnon(`Admin/AddActivity`,dataToSend,onSuccess);
    }
  },
  mounted() { 
    this.getActivityList();
  },
}
</script>


<style lang="scss"> 

</style>