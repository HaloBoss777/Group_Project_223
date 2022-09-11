<template>
  <div>
    <div class="app-content-header">
      <h1 class="app-content-headerText">Employees</h1>
      <button
        v-if="!addActivivityOpen"
        @click="addNewEmployee"
        class="app-content-headerButton"
      >
        Add Employees
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
      <div v-if="windowWidth > 1024" class="app-content-actions-wrapper">
        <button
          @click="setList"
          class="action-button list"
          :class="listViewActive && windowWidth > 1024 ? 'active' : ''"
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
          :class="!listViewActive && windowWidth > 1024 ? 'active' : ''"
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
      :class="listViewActive && windowWidth > 1024 ? 'tableView' : 'gridView'"
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
          Cell
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          RSA ID
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Admin
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image"></div>
      </div>
      <div
        class="products-row ItemBelow"
        v-for="(employee, index) in pageAbleEmployeeList"
        :key="index"
        @click.prevent="activitySelected(employee)"
      >
        <div class="product-cell category">
          <span>{{ employee.full_Name }}</span>
        </div>
        <div class="product-cell category">
          <span>{{ employee.cellNum }}</span>
        </div>
        <div class="product-cell category">
          <span>{{ employee.rsA_Id }}</span>
        </div>
        <div class="product-cell category">
          <span>{{ employee.admin }}</span>
        </div>
        <div class="product-cell">
          <button
            class="sort-button ItemAbove"
            @click.prevent="confirmDelete(employee.emp_ID, employee.full_Name)"
          >
            <vue-feather type="trash-2" size="24"></vue-feather>
          </button>
        </div>
      </div>
      <!-- v-if="pageNumber != 1" -->
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
      <div class="Input-Section column">
        <div class="row">
          <label for="name" class="inp">
            <input
              v-model="formData.full_Name"
              @input="formData.full_Name = $event.target.value"
              type="text"
              id="name"
              placeholder="&nbsp;"
            />
            <span class="label">Full Name</span>
            <span class="focus-bg"></span>
          </label>
          <label for="rsa" class="inp">
            <input
              cols="20"
              v-model="formData.rsA_Id"
              @input="formData.rsA_Id = $event.target.value"
              type="text"
              id="rsa"
              placeholder="&nbsp;"
            />
            <span class="label">RSA ID</span>
            <span class="focus-bg"></span>
          </label>
          <label for="cell" class="inp">
            <input
              cols="20"
              v-model="formData.cellNum"
              @input="formData.cellNum = $event.target.value"
              type="text"
              id="cell"
              placeholder="&nbsp;"
            />
            <span class="label">Cell Number</span>
            <span class="focus-bg"></span>
          </label>
          <label for="cell" class="inp">
            <input
              cols="20"
              v-model="formData.passwordHash"
              @input="formData.passwordHash = $event.target.value"
              type="text"
              id="cell"
              placeholder="&nbsp;"
            />
            <span class="label">Password</span>
            <span class="focus-bg"></span>
          </label>
        </div>
        <div class="row">
          <label for="PO" class="inp">
            <input
              cols="20"
              v-model="formData.pO_Box"
              @input="formData.pO_Box = $event.target.value"
              type="text"
              id="PO"
              placeholder="&nbsp;"
            />
            <span class="label">PO BOX</span>
            <span class="focus-bg"></span>
          </label>
          <label for="price" class="inp">
            <input
              v-model="formData.str_Num"
              @input="formData.str_Num = $event.target.value"
              type="text"
              id="price"
              placeholder="&nbsp;"
            />
            <span class="label">Street Number</span>
            <span class="focus-bg"></span>
          </label>
          <label for="price" class="inp">
            <input
              v-model="formData.street"
              @input="formData.street = $event.target.value"
              type="text"
              id="price"
              placeholder="&nbsp;"
            />
            <span class="label">Street</span>
            <span class="focus-bg"></span>
          </label>
          <label for="area" class="inp">
            <input
              v-model="formData.area_Num"
              @input="formData.area_Num = $event.target.value"
              type="text"
              id="area"
              placeholder="&nbsp;"
            />
            <span class="label">Area Number</span>
            <span class="focus-bg"></span>
          </label>
        </div>
        <h3 style="color: white">Roles</h3>
        <div style="display: flex">
          <label class="checkbox path">
            <input type="checkbox" v-model="formData.admin" />
            <svg viewBox="0 0 21 21">
              <path
                d="M5,10.75 L8.5,14.25 L19.4,2.3 C18.8333333,1.43333333 18.0333333,1 17,1 L4,1 C2.35,1 1,2.35 1,4 L1,17 C1,18.65 2.35,20 4,20 L17,20 C18.65,20 20,18.65 20,17 L20,7.99769186"
              ></path>
            </svg>
          </label>
          <span class="checkbox-label">Admin</span>
        </div>
        <div style="display: flex">
          <label class="checkbox path">
            <input type="checkbox" v-model="formData.instructor" />
            <svg viewBox="0 0 21 21">
              <path
                d="M5,10.75 L8.5,14.25 L19.4,2.3 C18.8333333,1.43333333 18.0333333,1 17,1 L4,1 C2.35,1 1,2.35 1,4 L1,17 C1,18.65 2.35,20 4,20 L17,20 C18.65,20 20,18.65 20,17 L20,7.99769186"
              ></path>
            </svg>
          </label>
          <span class="checkbox-label">Instructor</span>
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
          @click="updateEmployee"
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
      activityList: [],
      filteredEmployeeList: [],
      pageAbleEmployeeList: [],
      addActivivityOpen: false,
      editActivivityOpen: false,
      deletedEmployee: false,
      formData: {
        emp_Id: 0,
        full_Name: "",
        pO_Box: null,
        street: "",
        str_Num: 0,
        area_Num: "",
        cellNum: "",
        rsA_Id: "",
        instructor: false,
        admin: false,
        passwordHash: "",
      },
      filterValue: "",
      windowWidth: window.innerWidth,
      maxItems: 10,
      pageNumber: 1,
      maxPages: 10,
    };
  },
  components: {},
  watch: {
    filterValue: function UpdateFilter(value) {
      this.filteredEmployeeList = this.activityList.filter((x) => {
        var nameToLookFor = x.full_Name.toLowerCase();
        return nameToLookFor.includes(value.toLowerCase()) || x.cellNum.includes(value) || x.rsA_Id.includes(value);
      });
      this.pageNumber = 1;
      this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
      this.maxPages = Math.ceil(this.filteredEmployeeList.length / this.maxItems);
    },
    maxItems: function UpdatePaging(value) {
      value = parseInt(value);
      if (value < 1) {
        value = 1;
      }
      this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
        (this.pageNumber - 1) * value,
        this.pageNumber * value
      );
      this.maxPages = Math.ceil(this.filteredEmployeeList.length / value);
      this.pageNumber = 1;
    },
  },
  computed: {},
  methods: {
    initFormData() {
      this.formData.emp_Id = 0;
      this.formData.pO_Box = null;
      this.formData.street = "";
      this.formData.str_Num = 0;
      this.formData.cellNum = "";
      this.formData.instructor = false;
      this.formData.admin = false;
      this.formData.rsA_Id = "";
      this.formData.area_Num = "";
      this.formData.full_Name = "";
      this.formData.passwordHash = "";
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
    nextPage() {
      if (this.pageNumber != this.maxPages) {
        this.pageNumber++;
        this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
          (this.pageNumber - 1) * this.maxItems,
          this.pageNumber * this.maxItems
        );
      }
    },
    prevPage() {
      if (this.pageNumber != 1) {
        this.pageNumber--;
        this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
          (this.pageNumber - 1) * this.maxItems,
          this.pageNumber * this.maxItems
        );
      }
    },
    goToFirstPage() {
      this.pageNumber = 1;
      this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
    },
    goToLastPage() {
      this.pageNumber = this.maxPages;
      this.pageAbleEmployeeList = this.filteredEmployeeList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
    },
    getEmployeeList() {
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
        self.filteredEmployeeList = self.activityList;
        self.pageNumber = 1;
        self.maxPages = Math.ceil(
          self.filteredEmployeeList.length / self.maxItems
        );
        self.pageAbleEmployeeList = self.filteredEmployeeList.slice(
          0,
          self.maxItems
        );
      };
      this.$AjaxGet(`Admin/ListEmployee`, onSuccess);
    },
    addNewEmployee() {
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
        emp_Id: this.formData.emp_Id,
        full_Name: this.formData.full_Name,
        pO_Box: this.formData.pO_Box,
        street: this.formData.street,
        str_Num: parseInt(this.formData.str_Num),
        area_Num: this.formData.area_Num,
        cellNum: this.formData.cellNum,
        rsA_Id: this.formData.rsA_Id,
        instructor: this.formData.instructor,
        admin: this.formData.admin,
        passwordHash: this.formData.passwordHash,
      };

      if (dataToSend.passwordHash) {
        dataToSend.passwordHash = md5(dataToSend.passwordHash);
      }

      var onSuccess = (response) => {
        if (response) {
          self.getEmployeeList();
          self.cancelAdd();
        }
      };
      this.$AjaxPost(`Admin/AddEmployee`, dataToSend, onSuccess);
    },
    activitySelected(dataChosen) {
      this.initFormData();
      if (this.deletedEmployee) {
        return;
      }
      this.formData.emp_Id = dataChosen.emp_ID;
      this.formData.pO_Box = dataChosen.pO_Box;
      this.formData.street = dataChosen.street;
      this.formData.str_Num = parseInt(dataChosen.str_Num);
      this.formData.cellNum = dataChosen.cellNum;
      this.formData.instructor = dataChosen.instructor;
      this.formData.admin = dataChosen.admin;
      this.formData.rsA_Id = dataChosen.rsA_Id;
      this.formData.area_Num = dataChosen.area_Num;
      this.formData.full_Name = dataChosen.full_Name;
      this.addActivivityOpen = true;
      this.editActivivityOpen = true;
    },
    updateEmployee() {
      var self = this;
      var dataToSend = {
        emp_Id: this.formData.emp_Id,
        full_Name: this.formData.full_Name,
        pO_Box: this.formData.pO_Box,
        street: this.formData.street,
        str_Num: parseInt(this.formData.str_Num),
        area_Num: this.formData.area_Num,
        cellNum: this.formData.cellNum,
        rsA_Id: this.formData.rsA_Id,
        instructor: this.formData.instructor,
        admin: this.formData.admin,
        passwordHash: this.formData.passwordHash,
      };

      var onSuccess = (response) => {
        if (response) {
          self.getEmployeeList();
          self.cancelAdd();
        }
      };

      if (dataToSend.passwordHash) {
        dataToSend.passwordHash = md5(dataToSend.passwordHash);
      }

      this.$AjaxPost(`Admin/UpdateEmployee`, dataToSend, onSuccess);
    },
    confirmDelete(employee_Id, name) {
      this.deletedEmployee = true;
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
            this.deleteEmployee(employee_Id);
          }
        });
    },
    deleteEmployee(employee_Id) {
      var onSuccess = (response) => {
        this.getEmployeeList();
        this.deletedEmployee = false;
      };
      this.$AjaxGet(
        `Admin/DeleteEmployee?employee_Id=${employee_Id}`,
        onSuccess
      );
    },
    resizeHandler() {
      this.windowWidth = window.innerWidth;
    },
  },
  mounted() {
    this.getEmployeeList();
  },
  created() {
    window.addEventListener("resize", this.resizeHandler);
  },
};
</script>

<style lang="scss"></style>
