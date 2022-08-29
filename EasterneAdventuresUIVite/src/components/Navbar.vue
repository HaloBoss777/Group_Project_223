<template>
  <div ref="NavBar" id="NavBar"> 
    <button @click="goToLoginPage">Login/Register</button>
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
    }
  },
  mounted() { 

  },
}
</script>


<style lang="scss"> 

</style>