<template>
  <div id="app" >
    <TheNavBar :datatoSend = datatoSend />
    <div class="backgroundImageforsite">
      <img class="backgroundImageforsite" src="https://cdn.discordapp.com/attachments/420648940346540042/848512825005703178/pattern-1622371598269-9891.jpg" alt="">
    </div>
    <router-view class="router-view"></router-view>
  </div>
</template>

<script>

import TheNavBar from "./components/NavBar.vue"


export default {
  name: 'App',
  data(){
        return {
          datatoSend:"Sign In"
        };
    },
  components: {
    TheNavBar
  },
  methods:{
    setSignIn(){
      debugger
      this.datatoSend = "Welcome "+ localStorage.getItem("Username");
    }
  },
  mounted(){

  }
}
</script>

<style scoped src="./assets/main.css">

</style>

