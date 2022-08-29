<template>
  <div ref="HomePage" id="HomePage"> 
    <NavBar></NavBar>
    <h1 class="Cover-Text">WELCOME TO ESTERNE ADVENTURES</h1>
    <h1>THE JOY OF LIFE</h1>
    <img src="../assets/Esterne.png" alt="">
    <button @click="goToOtherPage" >Click here</button>
  </div>
</template> 


<script>
  import NavBar from "../components/Navbar.vue";
export default {
  data() {
    return { 

    }
  },
  components:{ 
    NavBar
  },
  watch:{ 

  },
  computed: { 

  },
  methods: { 
    goToOtherPage(){
      this.$router.push("/Login");
    }
  },
  mounted() { 

  },
}
</script>


