<template>
  <div>
    <div class="app-content-header">
      <h1 class="app-content-headerText">Equipment</h1>
      <button
        v-if="!addActivivityOpen"
        @click="addNewEquipment"
        class="app-content-headerButton"
      >
        Add Equipment
      </button>
    </div>
    <div v-if="!addActivivityOpen" class="app-content-actions">
      <input
        @input="filterValue = $event.target.value"
        class="search-bar"
        placeholder="Search..."
        type="text"
      />
      <div class="app-content-actions-wrapper">
        <button
          @click="setList"
          class="action-button list"
          :class="listViewActive ? 'active' : ''"
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
          :class="!listViewActive ? 'active' : ''"
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
      :class="listViewActive ? 'tableView' : 'gridView'"
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
        v-for="(equipment, index) in filteredEquipmentList"
        :key="index"
        @click.prevent="equipmentSelected(equipment)"
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
            @click.prevent="confirmDelete(equipment.equipment_Id, equipment.name)"
          >
            <vue-feather type="trash-2" size="24"></vue-feather>
          </button>
        </div>
      </div>
    </div>
    <div v-if="addActivivityOpen">
      <div class="Input-Section column">
        <div class="row">
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
        </div>
        <div style="display: flex;margin-top: 10px;">
          <label class="checkbox path">
            <input type="checkbox" v-model="formData.broken" />
            <svg viewBox="0 0 21 21">
              <path
                d="M5,10.75 L8.5,14.25 L19.4,2.3 C18.8333333,1.43333333 18.0333333,1 17,1 L4,1 C2.35,1 1,2.35 1,4 L1,17 C1,18.65 2.35,20 4,20 L17,20 C18.65,20 20,18.65 20,17 L20,7.99769186"
              ></path>
            </svg>
          </label>
          <span class="checkbox-label">Broken</span>
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
          @click="updateEquipment"
        >
          Update
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import md5 from "md5";
export default {
  data() {
    return {
      listViewActive: true,
      equipmentList: [],
      filteredEquipmentList: [],
      addActivivityOpen: false,
      editActivivityOpen: false,
      deletedEquipment: false,
      formData: {
        equipment_Id: 0,
        name:"",
        broken:false,
      },
      filterValue: "",
    };
  },
  components: {},
  watch: {
    filterValue: function UpdateFilter(value) {
      this.filteredEquipmentList = this.equipmentList.filter((x) => {
        var stringValue = x.price_PP.toString();
        return (
          x.name.includes(value) ||
          x.description.includes(value) ||
          stringValue.includes(value)
        );
      });
    },
  },
  computed: {},
  methods: {
    initFormData() {
      this.formData.equipment_Id = 0;
      this.formData.name = "";
      this.formData.broken = false;
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
    getEquipmentList() {
      var self = this;
      var onSuccess = (response) => {
        self.equipmentList = response;
        self.filteredEquipmentList = self.equipmentList;
      };
      this.$AjaxGet(`Admin/ListEquipment`, onSuccess);
    },
    addNewEquipment() {
      this.initFormData();
      this.addActivivityOpen = true;
    },
    cancelAdd() {
      this.addActivivityOpen = false;
      this.editActivivityOpen = false;
    },
    addNewItem() {
      var self = this;
      var dataToSend = {
        equipment_Id: this.formData.equipment_Id,
        name: this.formData.name,
        broken: this.formData.broken,
      };

      var onSuccess = (response) => {
        if (response) {
          self.getEquipmentList();
          self.cancelAdd();
        }
      };
      this.$AjaxPost(`Admin/AddEquipmnet`, dataToSend, onSuccess);
    },
    equipmentSelected(dataChosen) {
      this.initFormData();
      if (this.deletedEquipment) {
        return;
      }
      this.formData.equipment_Id = dataChosen.equipment_Id;
      this.formData.name = dataChosen.name;
      this.formData.broken = dataChosen.broken;
      this.addActivivityOpen = true;
      this.editActivivityOpen = true;
    },
    updateEquipment() {
      var self = this;
      var dataToSend = {
        equipment_Id: this.formData.equipment_Id,
        name: this.formData.name,
        broken: this.formData.broken,
      };

      var onSuccess = (response) => {
        if (response) {
          self.getEquipmentList();
          self.cancelAdd();
        }
      };

      this.$AjaxPost(`Admin/UpdateEquipment`, dataToSend, onSuccess);
    },
    confirmDelete(equipment_Id, name) {
      this.deletedEquipment = true;
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
            this.deleteEquipment(equipment_Id);
          }
        });
    },
    deleteEquipment(equipment_Id) {
      var onSuccess = (response) => {
        this.getEquipmentList();
        this.deletedEquipment = false;
      };
      this.$AjaxGet(
        `Admin/DeleteEquipment?equipment_Id=${equipment_Id}`,
        onSuccess
      );
    },
  },
  mounted() {
    this.getEquipmentList();
  },
};
</script>

<style lang="scss"></style>
