<template>
  <div>
    <NavBar></NavBar>
    <div ref="LoginPage" id="LoginPage"> 
      <div class="login-Page">
        <h2 class="Title">Register</h2>
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
        <a class="mt-1" href="#" @click="goToLogin">I have an account</a>
        <button class="action-button Login-Btn">Register</button>
      </div>
    </div>
  </div>
</template> 


<script>
import NavBar from "../components/Navbar.vue";
export default {
  data() {
    return { 
      formData:{
        email:"",
        password:"",
      },
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
    goToLogin(){
      this.$router.push('/Login');
    }
  },
  mounted() { 

  },
}
</script>


