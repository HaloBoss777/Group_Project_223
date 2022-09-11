<template>
  <div ref="Dashboard" id="Dashboard">
    <div class="app-container">
      <div
        class="sidebar"
        :class="sidebarIsOpen && windowWidth <= 1024 ? 'show-nav-items' : ''"
      >
        <div
          @click="toggleSidebar"
          v-if="sidebarIsOpen && windowWidth <= 1024"
          class="sidebar-header"
        >
          <div class="app-icon">
            <vue-feather type="menu" size="16"></vue-feather>
          </div>
        </div>
        <ul class="sidebar-list">
          <li
            v-for="(item, index) in routelistData"
            :key="index"
            class="sidebar-list-item"
            :class="$route.name == item.routeName ? 'active' : ''"
          >
            <a href="#" @click="goToRoute(item.routeUrl)">
              <vue-feather :type="item.icon" size="16"></vue-feather>
              <span>{{ item.routeName }}</span>
            </a>
          </li>
        </ul>
        <div class="account-info">
          <div class="account-info-picture">
            <img
              src="https://images.unsplash.com/photo-1527736947477-2790e28f3443?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTE2fHx3b21hbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60"
              alt="Account"
            />
          </div>
          <div class="account-info-name">Monica G.</div>
          <button class="account-info-more">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
              class="feather feather-more-horizontal"
            >
              <circle cx="12" cy="12" r="1" />
              <circle cx="19" cy="12" r="1" />
              <circle cx="5" cy="12" r="1" />
            </svg>
          </button>
        </div>
      </div>
      <!-- Put anything like images in above...NOT in app-content -->
      <div class="app-content">
        <router-view v-slot="{ Component }">
          <transition name="slide-fade">
            <div>
              <div
                class="app-icon"
                v-if="windowWidth <= 1024"
                @click="toggleSidebar"
              >
                <vue-feather type="menu" size="16"></vue-feather>
              </div>
              <component :is="Component" />
              <div v-if="$route.name == 'Dashboard'">
                <div class="dashboard-Layout">
                  <div class="headerSection">
                      <div class="row">
                        <div class="column card">
                          <div class="body">
                            <div class="row header">
                              <h5>Monthly Income</h5>
                            </div>
                            <div >
                              <LineChart
                                cssClasses="chartClass"
                                :options="monthlyIncomeOptions"
                                :chartData="monthlyIncome"
                              />
                            </div>
                          </div>
                        </div>
                        <div class="column card">
                          <div class="body">
                            <div class="row header">
                              <h5>Activity Popularity by Attendees</h5>
                            </div>
                            <div>
                              <DoughnutChart 
                                cssClasses="chartClass"
                                :options="popularActivitiesOptions"
                                :chartData="popularActivities"
                              />
                            </div>
                          </div>
                        </div>
                      </div>
                  </div>
                </div>
              </div>
            </div>
          </transition>
        </router-view>
      </div>
    </div>
  </div>
</template>

<script>
import i18n from "./i18n";
import { LineChart,DoughnutChart  } from "vue-chart-3";
import { Chart, registerables } from "chart.js";
Chart.register(...registerables);
export default {
  data() {
    return {
      routelistData: [],
      windowWidth: window.innerWidth,
      sidebarIsOpen: false,
      popularActivities: {
        labels: [],
        datasets: [
          {
            data: [],
            backgroundColor: [],
            fill: false,
            borderColor: "#283046",
          },
        ],
      },
      monthlyIncome: {
        labels: [],
        datasets: [
          {
            data: [],
            backgroundColor: ["#fff", "#fff", "#fff", "#fff", "#fff"],
            fill: false,
            borderColor: "#4bc0c0",
          },
        ],
      },
      popularActivitiesOptions: {
        plugins: {
          legend: true,
          tooltip: true,
        },
        scales: {
          
          x: {
            display:false,
            ticks:{
              color: "white"
            },
            grid: {
              color: "white",
              display:false,
              borderColor: "white", // <-- this line is answer to initial question
            },
          },
          y: {
            display:false,
            ticks:{
              color: "white"
            },
            grid: {
              display:false,
              color: "white",
              borderColor: "white", // <-- this line is answer to initial question
            },
          },
        },
        elements: {
          line: {
            fill: false,
            backgroundColor: "#000",
            borderColor: "#000",
          },
        },
      },
      monthlyIncomeOptions: {
        plugins: {
          legend: false,
          tooltip: true,
        },
        scales: {
          x: {
            ticks:{
              color: "white"
            },
            grid: {
              color: "white",
              display:false,
              borderColor: "white", // <-- this line is answer to initial question
            },
          },
          y: {
            ticks:{
              color: "white"
            },
            grid: {
              display:false,
              color: "white",
              borderColor: "white", // <-- this line is answer to initial question
            },
          },
        },
        elements: {
          line: {
            fill: false,
            backgroundColor: "#000",
            borderColor: "#000",
          },
        },
      },
    };
  },
  components: { LineChart,DoughnutChart  },
  watch: {},
  computed: {},
  methods: {
    goToRoute(route) {
      this.sidebarIsOpen = false;
      this.$router.push(`/${route}`);
    },
    toggleSidebar() {
      this.sidebarIsOpen = !this.sidebarIsOpen;
    },
    resizeHandler() {
      this.windowWidth = window.innerWidth;
    },
    getChartData(){
      var onSuccess = (response) => {
        this.monthlyIncome.datasets[0].data = response.values;
        this.monthlyIncome.datasets[0].backgroundColor = response.backgroundColor;
        this.monthlyIncome.labels = response.labels
      };
      this.$AjaxGet(`Admin/ChartMonthlyIncome`,onSuccess);
    },
    getpopularActivities(){
      var onSuccess = (response) => {
        this.popularActivities.datasets[0].data = response.values;
        this.popularActivities.datasets[0].backgroundColor = response.backgroundColor;
        this.popularActivities.labels = response.labels
      };
      this.$AjaxGet(`Admin/PopularActivities`,onSuccess);
    }
  },
  mounted() {
    this.routelistData = i18n.routeList;
    this.getChartData();
    this.getpopularActivities();
  },
  created() {
    window.addEventListener("resize", this.resizeHandler);
  },
};
</script>

<style lang="scss"></style>
