<template>
  <nav class="nav-bar">
    <div class="logo">
      <img class="logo-image" src="../assets/Esterne.png" alt="">
    </div>
    <ul class="nav-links toggle">
      <li class="cartIcon"><a  @click="goToCart" ><vue-feather type="shopping-cart" size="20"></vue-feather><p>{{cartStore.getCartCount}}</p></a></li>
      <li><a @click="goToHomePage" >Home</a></li>
      <li >
        <a v-if="isAdmin" @click="goToDashboardPage" >Dashboard</a>
      </li>
      <li >
        <a v-if="!isLoggedIn" @click="goToLoginPage" >Login</a>
      </li>
      <li >
        <a v-if="isLoggedIn" >{{ authStore.fullName }}</a>
      </li>
      <li  >
        <a v-if="isLoggedIn" @click="logout" >Logout</a>
      </li>
    </ul>
    <div class="burger">
      <div class="line1"></div>
      <div class="line2"></div>
      <div class="line3"></div>
    </div>
  </nav>
</template>

<script>
import { useAuthStore } from "../store/authStore.js";
import { useCartStore } from "../store/cartStore.js";
export default {
  name: "NavBar",
  data() {
    return {
      cartStore:useCartStore(),
      authStore:useAuthStore(),
      navOpen: false,
      windowWidth: window.innerWidth,
      loggedIn:false,
    };
  },
  components: {},
  watch: {},
  computed: {
    isLoggedIn(){
      return this.authStore.jwtToken.length != 0;
    },
    isAdmin(){
      return this.authStore.isAdmin;
    }
  },
  methods: {
    clickBurgerMenu() {
      if(this.windowWidth <= 768){
        const burger = document.querySelector(".burger").click();
      }
    },
    goToLoginPage() {
      this.$router.push("/Login");
      this.clickBurgerMenu();
    },
    goToHomePage() {
      this.$router.push("/Home");
      this.clickBurgerMenu();
    },
    goToDashboardPage() {
      this.$router.push("/Dashboard");
      this.clickBurgerMenu();
    },
    changeNameHere() {
      this.authStore.setName("Whoop Whoop");
    },
    goToCart(){
      this.$router.push("/Cart");
    },
    logout(){
      localStorage.clear();
      this.authStore.logout();
      window.open("/Home","_self");
    },
    toggleNav() {
      const burger = document.querySelector(".burger");
      const nav = document.querySelector(".nav-links");
      const navLinks = document.querySelectorAll(".nav-links li");

      //Toggle Nav
      burger.addEventListener("click", () => {
        nav.classList.toggle("nav-active");
        this.navOpen = true;
        //Animate Links
        navLinks.forEach((link, index) => {
          if (link.style.animation) {
            link.style.animation = "";
          } else {
            link.style.animation = `navLinkFade 0.5s ease forwards ${
              index / 7 + 0.5
            }s`;
          }
        });

        //burger animation
        burger.classList.toggle("toggle");
      });
    },
  },
  mounted() {
    setTimeout(() => {
      this.toggleNav();
    }, 100);
  },
};
</script>

<style lang="scss"></style>
