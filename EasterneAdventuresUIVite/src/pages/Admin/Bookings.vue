<template>
  <div>
    <div class="app-content-header">
      <h1 class="app-content-headerText">Bookings</h1>
      
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
          Client
          <button class="sort-button">
            <vue-feather
              class="small-Icon"
              type="arrow-up"
              size="36px"
            ></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Activity
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">
          Price_PP
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
        <div class="product-cell image">
          Paid
          <button class="sort-button">
            <vue-feather class="small-Icon" type="arrow-up"></vue-feather>
          </button>
        </div>
        <div class="product-cell image">Booked For</div>
      </div>
      <div
        class="products-row ItemBelow"
        v-for="(booking, index) in pageAbleBookingList"
        :key="index"
        @click.prevent="activitySelected(booking)"
      >
        <div class="product-cell category">
          <span>{{ booking.client_Full_Name }}</span>
        </div>
        <div class="product-cell category">
          <span>{{ booking.activity_Name }}</span>
        </div>
        <div class="product-cell category">
          <span>R{{ booking.activity_PP }}</span>
        </div>
        <div class="product-cell category">
          <span v-if="booking.attendees">{{ booking.attendees }}</span>
          <span v-else>0</span>
        </div>
        <div class="product-cell category">
          <span>R{{booking.activity_PP * booking.attendees}}</span>
        </div>
        <div class="product-cell">
          <span>{{ booking.date_Booked}}</span>
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
            v-model="formData.activity_Name"
            @input="formData.activity_Name = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Activity</span>
          <span class="focus-bg"></span>
        </label>
        <label for="name" class="inp">
          <input
            v-model="formData.client_Full_Name"
            @input="formData.client_Full_Name = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Client Full Name</span>
          <span class="focus-bg"></span>
        </label>
        <label for="name" class="inp">
          <input
            v-model="formData.client_Cell"
            @input="formData.client_Cell = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Client Cell</span>
          <span class="focus-bg"></span>
        </label>
        <label for="name" class="inp">
          <input
            v-model="formData.client_RSA_Id"
            @input="formData.client_RSA_Id = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Client RSA Id</span>
          <span class="focus-bg"></span>
        </label>
        <label for="name" class="inp">
          <input
            v-model="formData.attendees"
            @input="formData.attendees = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Attending</span>
          <span class="focus-bg"></span>
        </label>
        <label for="name" class="inp">
          <input
            v-model="formData.activity_PP"
            @input="formData.activity_PP = $event.target.value"
            disabled="true"
            type="text"
            id="name"
            placeholder="&nbsp;"
          />
          <span class="label">Activity Cost PP</span>
          <span class="focus-bg"></span>
        </label>
      </div>
      <div class="right-side">
        <button class="app-content-cancelButton mr-2" @click="cancelAdd">
          Cancel
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
      bookingList: [],
      filteredBookingList: [],
      pageAbleBookingList: [],
      addActivivityOpen: false,
      editActivivityOpen: false,
      deletedBooking: false,
      formData: {
        booking_Id:0,
        client_Id:0,
        client_Full_Name:"",
        client_RSA_Id:"",
        client_Cell:"",
        activity_Id:0,
        activity_Name:"",
        payment_Id :0,
        payment_Amount:0,
        date_Booked:"",
        attendees:0,
        activity_PP:0
      },
      filterValue: "",
      equipmentList: [],
      filteredEquipmentList: [],
      focuedOnDropDown: false,
      filerEquipment: null,
      windowWidth:window.innerWidth,
      maxItems: 10,
      pageNumber: 1,
      maxPages: 1,
    };
  },
  components: {},
  watch: {
    filterValue: function UpdateFilter(value) {
      this.filteredBookingList = this.bookingList.filter((x) => {
        var stringValue = x.payment_Amount.toString();
        return (
          x.client_RSA_Id.includes(value) ||
          x.activity_Name.includes(value) ||
          x.client_Full_Name.includes(value) ||
          x.date_Booked.includes(value) ||
          x.client_Cell.includes(value) ||
          x.attendees.toString().includes(value) ||
          stringValue.includes(value)
        );
      });
      this.pageNumber = 1;
      this.pageAbleBookingList = this.filteredBookingList.slice(
        (this.pageNumber - 1) * this.maxItems,
        this.pageNumber * this.maxItems
      );
      this.maxPages = Math.ceil(this.filteredBookingList.length / this.maxItems);
    },
    maxItems: function UpdatePaging(value) {
      value = parseInt(value);
      if (value < 1) {
        value = 1;
      }
      this.pageAbleBookingList = this.filteredBookingList.slice(
        (this.pageNumber - 1) * value,
        this.pageNumber * value
      );
      this.maxPages = Math.ceil(this.filteredBookingList.length / value);
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
      this.pageAbleBookingList = this.filteredBookingList.slice(
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
    getBookingList() {
      var self = this;
      var onSuccess = (response) => {
        self.bookingList = response;
        self.filteredBookingList = self.bookingList;
        self.maxPages = Math.ceil(self.filteredBookingList.length / self.maxItems)
        self.setPage();
      };
      this.$AjaxGet(`Admin/GetBookings`, onSuccess);
    },
    cancelAdd() {
      this.addActivivityOpen = false;
      this.editActivivityOpen = false;
    },
    activitySelected(dataChosen) {
      this.formData.booking_Id=dataChosen.booking_Id;
      this.formData.client_Id=dataChosen.client_Id;
      this.formData.client_Full_Name=dataChosen.client_Full_Name;
      this.formData.client_RSA_Id=dataChosen.client_RSA_Id;
      this.formData.client_Cell=dataChosen.client_Cell;
      this.formData.activity_Id=dataChosen.activity_Id;
      this.formData.activity_Name=dataChosen.activity_Name;
      this.formData.payment_Id =dataChosen.payment_Id;
      this.formData.payment_Amount=dataChosen.payment_Amount;
      this.formData.date_Booked=dataChosen.date_Booked;
      this.formData.attendees=dataChosen.attendees;
      this.formData.activity_PP=dataChosen.activity_PP;
      this.addActivivityOpen = true;
      this.editActivivityOpen = true;
    },
    resizeHandler(){
      this.windowWidth = window.innerWidth;
    }
  },
  mounted() {
    this.getBookingList();
  },
  created() {
    window.addEventListener("resize", this.resizeHandler);
  },
};
</script>

<style lang="scss"></style>
