<script setup>
import { useAuthStore } from "../store/authStore.js";
import icon from "../assets/Esterne.png";
const authStore = useAuthStore();
</script>

<template>
  <nav>
    <div class="logo">
      <img class="logo-image" :src="icon" alt="">
    </div>
    <ul class="nav-links">
      <li><a @click="goToHomePage" href="#">Home</a></li>
      <li v-if="authStore.isAdmin">
        <a @click="goToDashboardPage" href="#">Dashboard</a>
      </li>
      <li v-if="!authStore.fullName">
        <a @click="goToLoginPage" href="#">Login</a>
      </li>
      <li v-if="authStore.fullName">
        <a href="#">{{ authStore.fullName }}</a>
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
export default {
  name: "NavBar",
  data() {
    return {
      navOpen: false,
      windowWidth: window.innerWidth
    };
  },
  components: {},
  watch: {},
  computed: {},
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
    this.toggleNav();
  },
};
</script>

<style lang="scss"></style>
