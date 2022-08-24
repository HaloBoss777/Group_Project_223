<template>
  <div ref="HomePage" id="HomePage"> 
    <h1>Harro</h1>
    <img src="../assets/Esterne.png" alt="">
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
      this.$router.push("/Login");
    }
  },
  mounted() { 

  },
}
</script>


