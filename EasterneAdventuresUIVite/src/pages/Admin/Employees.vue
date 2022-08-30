<template>
  <div>
    <div class="app-content-header">
      <h1 class="app-content-headerText">Employees</h1>
      <button v-if="!addActivivityOpen" @click="addNewActivity" class="app-content-headerButton">Add Employees</button>
    </div>
    <div v-if="!addActivivityOpen" class="app-content-actions">
      <input @input="filterValue = $event.target.value" class="search-bar" placeholder="Search..." type="text">
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
            <vue-feather class="small-Icon" type="arrow-up" size="36px"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Description
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Price
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
        </div>
      </div>
      <div class="products-row ItemBelow" v-for="(activity, index) in filteredActivityList" :key="index" @click.prevent="activitySelected(activity)">
        <div class="product-cell category">
          <span>{{activity.name}}</span>
        </div>
        <div class="product-cell category">
          <span>{{activity.description}}</span>
        </div>
        <div class="product-cell category">
          <span>R{{activity.price_PP}}</span>
        </div>
        <div class="product-cell">
          <button class="sort-button ItemAbove" @click.prevent="deleteActivity(activity.activity_Id)">
            <vue-feather type="trash-2" size="24"></vue-feather>
          </button>
        </div>
      </div>
      
    </div>
    <div v-if="addActivivityOpen">
      <div class="Input-Section">
        <label for="name" class="inp">
          <input v-model="formData.full_Name" @input="formData.full_Name = $event.target.value" type="text" id="name" placeholder="&nbsp;">
          <span class="label">Full Name</span>
          <span class="focus-bg"></span>
        </label>
        <label for="rsa" class="inp">
          <textarea cols="20"  v-model="formData.rSA_Id" @input="formData.rSA_Id = $event.target.value" type="text" id="rsa" placeholder="&nbsp;"></textarea>
          <span class="label">RSA ID</span>
          <span class="focus-bg"></span>
        </label>
        <label for="cell" class="inp">
          <textarea cols="20"  v-model="formData.cellNum" @input="formData.cellNum = $event.target.value" type="text" id="cell" placeholder="&nbsp;"></textarea>
          <span class="label">Cell Number</span>
          <span class="focus-bg"></span>
        </label>
        <label for="PO" class="inp">
          <textarea cols="20"  v-model="formData.pO_BOX" @input="formData.pO_BOX = $event.target.value" type="text" id="PO" placeholder="&nbsp;"></textarea>
          <span class="label">PO BOX</span>
          <span class="focus-bg"></span>
        </label>
        <label for="price" class="inp">
          <input v-model="formData.street" @input="formData.street = $event.target.value" type="text" id="price" placeholder="&nbsp;">
          <span class="label">Street</span>
          <span class="focus-bg"></span>
        </label>
        <label for="area" class="inp">
          <input v-model="formData.area_Num" @input="formData.area_Num = $event.target.value" type="text" id="area" placeholder="&nbsp;">
          <span class="label">Area Number</span>
          <span class="focus-bg"></span>
        </label>
      </div>
      <div class="right-side">
        <button class="app-content-cancelButton mr-2" @click="cancelAdd">Cancel</button>
        <button v-if="!editActivivityOpen" class="app-content-headerButton" @click="addNewItem">Add</button>
        <button v-if="editActivivityOpen" class="app-content-headerButton" @click="updateActivity">Update</button>
      </div>
    </div>
  </div>
</template> 


<script>
export default {
  data() {
    return { 
      listViewActive:true,
      activityList:[],
      filteredActivityList:[],
      addActivivityOpen:false,
      editActivivityOpen:false,
      deletedActivity:false,
      formData:{
        emp_Id:0,
        full_Name : "",
        pO_BOX: null,
        street:"",
        str_Num:0,
        area_Num:"",
        cellNum:"",
        rSA_Id:"",
        instructor:false,
        admin:false,
      },
      filterValue:""
    }
  },
  components:{ 

  },
  watch:{ 
    filterValue:function UpdateFilter(value) {
      this.filteredActivityList = this.activityList.filter(x=> {
        var stringValue = x.price_PP.toString();
        return (x.name.includes(value) || x.description.includes(value) || stringValue.includes(value))
      })
    }
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
        self.filteredActivityList = self.activityList;
      }
      this.$AjaxGet(`Admin/ListEmployee`,onSuccess);
    },
    addNewActivity(){
      this.addActivivityOpen = true;
    },
    cancelAdd(){
      this.addActivivityOpen = false;
      this.editActivivityOpen = false;
    },
    addNewItem(){
      var self = this;
      var dataToSend = {
        activity_Id:this.formData.activity_Id,
        name : this.formData.name,
        description: this.formData.description,
        price_PP:parseFloat(this.formData.price_PP)
      };

      var onSuccess = response =>{
        if(response){
          self.getActivityList();
          self.cancelAdd();
        }
      }
      this.$AjaxPostAnon(`Admin/AddActivity`,dataToSend,onSuccess);
    },
    activitySelected(dataChosen){
      if(this.deletedActivity){
        return
      }
      this.formData.activity_Id =dataChosen.activity_Id,
      this.formData.name = dataChosen.name,
      this.formData.description= dataChosen.description,
      this.formData.price_PP= dataChosen.price_PP
      this.addActivivityOpen = true;
      this.editActivivityOpen = true;
    },
    updateActivity(){
      var self = this;
      var dataToSend = {
        activity_Id:this.formData.activity_Id,
        name : this.formData.name,
        description: this.formData.description,
        price_PP:parseFloat(this.formData.price_PP)
      };

      var onSuccess = response =>{
        if(response){
          self.getActivityList();
          self.cancelAdd();
        }
      }
      this.$AjaxPostAnon(`Admin/UpdateActivity`,dataToSend,onSuccess);
    },
    deleteActivity(activity_Id){
      this.deletedActivity = true;
      // var onSuccess=response=>{
      //   this.getActivityList()
      //   this.deletedActivity = false;
      // }
      // this.$AjaxGetAnon(`Admin/DeleteActivity?activity_Id=${activity_Id}`,onSuccess)
      
    }
  },
  mounted() { 
    this.getActivityList();
  },
}
</script>


<style lang="scss"> 

</style>