<template>
  <div>
    <div class="app-content-header">
      <h1 class="app-content-headerText">Activity</h1>
      <button
        v-if="!addActivivityOpen"
        @click="addNewActivity"
        class="app-content-headerButton"
      >
        Add Activity
      </button>
    </div>
    <div v-if="!addActivivityOpen" class="app-content-actions">
      <input
        @input="filterValue = $event.target.value"
        class="search-bar"
        placeholder="Search..."
        type="text"
      />
      <span style="margin-left: 10px">Items Per Page: </span>
      <div class="counter counter-icons">
        <button :disabled="maxItems == 1" @click="maxItems--">
          <vue-feather
            style="margin-right: 2px"
            type="minus"
            size="16"
          ></vue-feather>
        </button>
        <output>{{ maxItems }}</output>
        <button @click="maxItems++">
          <vue-feather
            style="margin-right: 2px"
            type="plus"
            size="16"
          ></vue-feather>
        </button>
      </div>
      <div v-if="windowWidth > 1024"  class="app-content-actions-wrapper">
        <button
          @click="setList"
          class="action-button list"
          :class="listViewActive &&  windowWidth > 1024 ? 'active' : ''"
          title="List View"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
            class="feather feather-list"
          >
            <line x1="8" y1="6" x2="21" y2="6" />
            <line x1="8" y1="12" x2="21" y2="12" />
            <line x1="8" y1="18" x2="21" y2="18" />
            <line x1="3" y1="6" x2="3.01" y2="6" />
            <line x1="3" y1="12" x2="3.01" y2="12" />
            <line x1="3" y1="18" x2="3.01" y2="18" />
          </svg>
        </button>
        <button
          @click="setGrid"
          class="action-button grid"
          :class="!listViewActive &&  windowWidth > 1024 ? 'active' : ''"
          title="Grid View"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
            class="feather feather-grid"
          >
            <rect x="3" y="3" width="7" height="7" />
            <rect x="14" y="3" width="7" height="7" />
            <rect x="14" y="14" width="7" height="7" />
            <rect x="3" y="14" width="7" height="7" />
          </svg>
        </button>
      </div>
    </div>
    <div
      v-if="!addActivivityOpen"
      class="products-area-wrapper"
      :class="listViewActive &&  windowWidth > 1024 ? 'tableView' : 'gridView'"
    >
      <div class="products-header">
        <div class="product-cell image">
          Name
          <button class="sort-button">
            <vue-feather
              class="small-Icon"
              type="arrow-up"
              size="36px"
            ></vue-feather>
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
          Attending
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image"></div>
      </div>
      <div
        class="products-row ItemBelow"
        v-for="(activity, index) in pageAbleActivityList"
        :key="index"
        @click.prevent="activitySelected(activity)"
      >
        <div class="product-cell category">
          <span>{{ activity.name }}</span>
        </div>
        <div class="product-cell category">
          <span>{{ activity.description }}</span>
        </div>
        <div class="product-cell category">
          <span>R{{ activity.price_PP }}</span>
        </div>
        <div class="product-cell category">
          <span v-if="activity.attending">{{ activity.attending }}</span>
          <span v-else>0</span>
        </div>
        <div class="product-cell">
          <button
            class="sort-button ItemAbove"
            @click.prevent="confirmDelete(activity.activity_Id, activity.name)"
          >
            <vue-feather type="trash-2" size="24"></vue-feather>
          </button>
        </div>
      </div>
      <div class="pageSection">
        <vue-feather
          @click="goToFirstPage"
          :class="pageNumber != 1 ? '' : 'Disabled'"
          type="skip-back"
          size="16"
        ></vue-feather>
        <vue-feather
          @click="prevPage"
          :class="pageNumber != 1 ? '' : 'Disabled'"
          type="arrow-left"
          size="16"
        ></vue-feather>
        <h5>{{ pageNumber }} / {{ maxPages }}</h5>
        <vue-feather
          @click="nextPage"
          :class="pageNumber != maxPages ? '' : 'Disabled'"
          type="arrow-right"
          size="16"
        ></vue-feather>
        <vue-feather
          @click="goToLastPage"
          :class="pageNumber != maxPages ? '' : 'Disabled'"
          type="skip-forward"
          size="16"
        ></vue-feather>
      </div>
    </div>
    <div v-if="addActivivityOpen">
      <div class="Input-Section">
        <label for="name" class="inp">
          <input
            v-model="formData.name"
            @input="formData.name = $event.target.value"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Name</span>
          <span class="focus-bg"></span>
        </label>
        <label for="description" class="inp">
          <textarea
            cols="20"
            v-model="formData.description"
            @input="formData.description = $event.target.value"
            type="text"
            id="description"
            placeholder="&nbsp;"
          ></textarea>
          <span class="label">Description</span>
          <span class="focus-bg"></span>
        </label>
        <label for="price" class="inp">
          <input
            v-model="formData.price_PP"
            @input="formData.price_PP = $event.target.value"
            type="text"
            id="price"
            placeholder="&nbsp;"
          />
          <span class="label">Price PP</span>
          <span class="focus-bg"></span>
        </label>
      </div>
      <div class="dropdown">
        <div id="myDropdown" class="dropdown-content">
          <input
            @input="filerEquipment = $event.target.value"
            @focusin="focuedOnDropDown = true"
            @focusout="setDropDownClosed"
            class="inputActiveHere"
            type="text"
            placeholder="Add Equipment.."
            id="myInput"
          />
          <div
            v-for="(equipment, index) in filteredEquipmentList.filter(
              (x) => !x.activity_Id
            )"
            :key="index"
          >
            <a
              @click="addEquipment(equipment.equipment_Id)"
              :class="focuedOnDropDown ? 'show' : ''"
              
              >{{ equipment.name }}</a
            >
          </div>
        </div>
      </div>
      <h2 style="margin-top: 20px; color: white">
        Equipment Allocated to {{ this.formData.name }}
      </h2>
      <div
        class="products-area-wrapper"
        style="height: fit-content; margin-bottom: 20px"
        :class="listViewActive &&  windowWidth > 1024 ? 'tableView' : 'gridView'"
      >
        <div class="products-header">
          <div class="product-cell image">
            Name
            <button class="sort-button">
              <vue-feather
                class="small-Icon"
                type="arrow-up"
                size="36px"
              ></vue-feather>
            </button>
          </div>
          <div class="product-cell image">
            Broken
            <button class="sort-button">
              <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
            </button>
          </div>
          <div class="product-cell image"></div>
        </div>
        <div
          class="products-row ItemBelow"
          v-for="(equipment, index) in equipmentList.filter(
            (x) => x.activity_Id
          )"
          :key="index"
        >
          <div class="product-cell category">
            <span>{{ equipment.name }}</span>
          </div>
          <div class="product-cell category">
            <span>{{ equipment.broken }}</span>
          </div>
          <div class="product-cell">
            <button
              class="sort-button ItemAbove"
              @click.prevent="
                confirmDeleteEquipment(equipment.equipment_Id, equipment.name)
              "
            >
              <vue-feather type="trash-2" size="24"></vue-feather>
            </button>
          </div>
        </div>
      </div>
      <div class="right-side">
        <button class="app-content-cancelButton mr-2" @click="cancelAdd">
          Cancel
        </button>
        <button
          v-if="!editActivivityOpen"
          class="app-content-headerButton"
          @click="addNewItem"
        >
          Add
        </button>
        <button
          v-if="editActivivityOpen"
          class="app-content-headerButton"
          @click="updateActivity"
        >
          Update
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      listViewActive: true,
      activityList: [],
      filteredActivityList: [],
      pageAbleActivityList: [],
      addActivivityOpen: false,
      editActivivityOpen: false,
      deletedActivity: false,
      formData: {
        activity_Id: 0,
        name: null,
        description: null,
        price_PP: null,
      },
      filterValue: "",
      equipmentList: [],
      filteredEquipmentList: [],
      focuedOnDropDown: false,
      filerEquipment: null,
      windowWidth:window.innerWidth,
      maxItems: 10,
      pageNumber: 1,
      maxPages: 10,
    };
  },
  components: {},
  watch: {
    filterValue: function UpdateFilter(value) {
      this.filteredActivityList = this.activityList.filter((x) => {
        var stringValue = x.price_PP.toString();
        return (
          x.name.toLowerCase().includes(value.toLowerCase()) ||
          x.description.toLowerCase().includes(value.toLowerCase()) ||
          stringValue.includes(value)
        );
      });
      this.pageNumber = 1;
      this.pageAbleActivityList = this.filteredActivityList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
      this.maxPages = Math.ceil(this.filteredActivityList.length / this.maxItems);
    },
    filerEquipment: function UpdateFilerEquipment(value) {
      this.filteredEquipmentList = this.equipmentList.filter((x) => {
        return x.name.includes(value);
      });
    },
    maxItems: function UpdatePaging(value) {
      value = parseInt(value);
      if (value < 1) {
        value = 1;
      }
      this.pageAbleActivityList = this.filteredActivityList.slice(
        (this.pageNumber - 1) * value,
        this.pageNumber * value
      );
      this.maxPages = Math.ceil(this.filteredActivityList.length / value);
      this.pageNumber = 1;
    },
  },
  computed: {},
  methods: {
    nextPage() {
      if (this.pageNumber != this.maxPages) {
        this.pageNumber++;
        this.setPage();
      }
    },
    prevPage() {
      if (this.pageNumber != 1) {
        this.pageNumber--;
        this.setPage();
      }
    },
    goToFirstPage() {
      this.pageNumber = 1;
      this.setPage();
    },
    goToLastPage() {
      this.pageNumber = this.maxPages;
      this.setPage();
    },
    setPage(){
      this.pageAbleActivityList = this.filteredActivityList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
    },
    setDropDownClosed() {
      setTimeout(() => {
        this.focuedOnDropDown = false;
      }, 200);
    },
    filterFunction() {
      this.filteredEquipmentList;
    },
    changeViews() {
      this.listViewActive = !this.listViewActive;
    },
    setList() {
      this.listViewActive = true;
    },
    setGrid() {
      this.listViewActive = false;
    },
    getActivityList() {
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
        self.filteredActivityList = self.activityList;
        self.maxPages = Math.ceil(self.filteredActivityList.length / self.maxItems)
        self.setPage();
      };
      this.$AjaxGet(`Admin/ListActivities`, onSuccess);
    },
    addNewActivity() {
      this.addActivivityOpen = true;
    },
    cancelAdd() {
      this.addActivivityOpen = false;
      this.editActivivityOpen = false;
    },
    addNewItem() {
      var self = this;
      var dataToSend = {
        activity_Id: this.formData.activity_Id,
        name: this.formData.name,
        description: this.formData.description,
        price_PP: parseFloat(this.formData.price_PP),
      };

      var onSuccess = (response) => {
        if (response) {
          self.getActivityList();
          self.cancelAdd();
        }
      };
      this.$AjaxPost(`Admin/AddActivity`, dataToSend, onSuccess);
    },
    activitySelected(dataChosen) {
      if (this.deletedActivity) {
        return;
      }
      this.getEquipmentList(dataChosen.activity_Id);
      (this.formData.activity_Id = dataChosen.activity_Id),
        (this.formData.name = dataChosen.name),
        (this.formData.description = dataChosen.description),
        (this.formData.price_PP = dataChosen.price_PP);
      this.addActivivityOpen = true;
      this.editActivivityOpen = true;
    },
    updateActivity() {
      var self = this;
      var dataToSend = {
        activity_Id: this.formData.activity_Id,
        name: this.formData.name,
        description: this.formData.description,
        price_PP: parseFloat(this.formData.price_PP),
      };

      var onSuccess = (response) => {
        if (response) {
          self.getActivityList();
          self.cancelAdd();
        }
      };
      this.$AjaxPost(`Admin/UpdateActivity`, dataToSend, onSuccess);
    },
    confirmDelete(activity_Id, name) {
      this.deletedActivity = true;
      this.$swal
        .fire({
          title: `Are you sure you want to Delete ${name} ?`,
          showDenyButton: true,
          showCancelButton: false,
          confirmButtonText: `Don't Delete`,
          denyButtonText: `Delete`,
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.$swal.fire(`${name} was not deleted`, "", "info");
          } else if (result.isDenied) {
            this.$swal.fire(`Deleted ${name}`, "", "success");
            this.deleteActivity(activity_Id);
          }
        });
    },
    deleteActivity(activity_Id) {
      var onSuccess = (response) => {
        this.getActivityList();
        this.deletedActivity = false;
      };
      this.$AjaxGet(
        `Admin/DeleteActivity?activity_Id=${activity_Id}`,
        onSuccess
      );
    },
    getEquipmentList(activity_Id) {
      var self = this;
      var onSuccess = (response) => {
        self.equipmentList = response;
        self.filteredEquipmentList = self.equipmentList;
      };
      this.$AjaxGet(
        `Admin/ListActivityEquipment?activity_Id=${activity_Id}`,
        onSuccess
      );
    },
    addEquipment(equipment_Id) {
      var index = this.equipmentList.findIndex(
        (x) => x.equipment_Id == equipment_Id
      );
      this.equipmentList[index].activity_Id = this.formData.activity_Id;
      this.filteredEquipmentList = this.equipmentList;

      var equipmentToAdd={
        equipment_Id:equipment_Id,
        activity_Id:this.formData.activity_Id
      }

      var onSuccess = response =>{

      }

      this.$AjaxPost(`Admin/AddActivityEquipment`,equipmentToAdd,onSuccess);
    },
    confirmDeleteEquipment(equipment_Id, name) {
      this.deletedActivity = true;
      this.$swal
        .fire({
          title: `Are you sure you want to Delete ${name} ?`,
          showDenyButton: true,
          showCancelButton: false,
          confirmButtonText: `Don't Delete`,
          denyButtonText: `Delete`,
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.$swal.fire(`${name} was not deleted`, "", "info");
          } else if (result.isDenied) {
            this.$swal.fire(`Deleted ${name}`, "", "success");
            this.removeEquipment(equipment_Id);
          }
        });
    },
    removeEquipment(equipment_Id) {
      var index = this.equipmentList.findIndex(
        (x) => x.equipment_Id == equipment_Id
      );
      this.equipmentList[index].activity_Id = null;
      this.filteredEquipmentList = this.equipmentList;

      var equipmentToAdd={
        equipment_Id:equipment_Id,
        activity_Id:this.formData.activity_Id
      }

      var onSuccess = response =>{

      }

      this.$AjaxPost(`Admin/DeleteActivityEquipment`,equipmentToAdd,onSuccess);
    },
    resizeHandler(){
      this.windowWidth = window.innerWidth;
    }
  },
  mounted() {
    this.getActivityList();
  },
  created() {
    window.addEventListener("resize", this.resizeHandler);
  },
};
</script>

<style lang="scss"></style>
