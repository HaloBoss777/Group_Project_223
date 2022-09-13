<template>
  <div>
    <NavBar></NavBar>
    <router-view></router-view>
  </div>
</template>

<script>
import NavBar from "./components/Navbar.vue";
import { useAuthStore } from './store/authStore.js'
export default {
  data() {
    return {
      navOpen: false,
      authStore:useAuthStore()
    };
  },
  components: {NavBar},
  watch: {},
  computed: {},
  methods: {
    setStore() {
      var userData = localStorage.getItem("userData");
      if (userData) {
        var data = JSON.parse(userData);
        if (data.isClient) {
          this.authStore.setClient_Id(data.id);
        } else {
          this.authStore.setEmp_Id(data.id);
          this.authStore.setIsEmployee(true);
        }
        this.authStore.setIsAdmin(data.isAdmin);
        this.authStore.setIsInstructor(data.isInstructor);
        this.authStore.setJwtToken(data.apiToken);
        this.authStore.setName(data.fullName);
      }
    },
  },
  mounted() {
    this.setStore();
  },
};
</script>

<style lang="scss">
@import "./assets/main.scss";

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
