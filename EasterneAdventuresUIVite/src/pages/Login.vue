<template>
  <div ref="LoginPage" id="LoginPage"> 
    <div class="login-Page">
      <h2 class="Title">Login</h2>
      <label for="email" class="inp">
        <input v-model="formData.email" @input="formData.email = $event.target.value" type="email" id="email" placeholder="&nbsp;">
        <span class="label">Email</span>
        <span class="focus-bg"></span>
      </label>
      <label for="password" class="inp">
        <input v-model="formData.password" @input="formData.password = $event.target.value" type="password" id="password" placeholder="&nbsp;"/>
        <span class="label">Password</span>
        <span class="focus-bg"></span>
      </label>
    </div>
  </div>
</template> 


<script>
export default {
  data() {
    return { 
      formData:{
        email:"",
        password:"",
      }
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


