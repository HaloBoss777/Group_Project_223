<template>
  <div ref="HomePage" id="HomePage"> 
    <h1>Login Page</h1>
    <button @click="goToOtherPage" >Click here</button>
  </div>
</template> 


<script>
export default {
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
    goToOtherPage(){
      this.$router.push("/Home");
    }
  },
  mounted() { 

  },
}
</script>


