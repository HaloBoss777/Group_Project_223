
<script setup>
import { useAuthStore } from '../store/authStore.js'
const authStore = useAuthStore();
</script>

<template>
  <div ref="NavBar" id="NavBar">
    <button @click="goToHomePage">Home</button>
    <button @click="goToDashboardPage">Dashboard</button>
    <button @click="goToLoginPage">Login/Register</button>
    <button @click="changeNameHere">{{authStore.fullName}}</button>
  </div>
</template> 


<script>
export default {
  name:'NavBar',
  data() {
    return { 
      

    }
  },
  components:{ 

  },
  watch:{ 

  },
  computed: { 

  },
  methods: { 
    goToLoginPage(){
      this.$router.push("/Login");
    },
    goToHomePage(){
      this.$router.push("/Home");
    },
    goToDashboardPage(){
      this.$router.push("/Dashboard");
    },
    changeNameHere(){
      this.authStore.setName("Whoop Whoop");
    }
  },
  mounted() { 

  },
}
</script>


<style lang="scss"> 

</style>