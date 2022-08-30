<template>
  <div>
    <NavBar></NavBar>
    <div ref="LoginPage" id="LoginPage"> 
      <div class="login-Page">
        <h2 class="Title">Login</h2>
        <h3 class="mb-2" v-if="errorMessage" >{{errorMessage}}</h3>
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
        <a class="mt-1" href="#" @click="goToRegister">I need an Account</a>
        <button @click="login" class="action-button Login-Btn">Login</button>
      </div>
    </div>
  </div>
</template> 


<script>
import NavBar from "../components/Navbar.vue";
import md5 from "md5"
export default {
  data() {
    return { 
      formData:{
        email:"",
        password:"",
      },
      errorMessage:""
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
    goToRegister(){
      this.$router.push('/Register');
    },
    login(){
      var self = this;
      var passwordHash = md5(this.formData.password);
      var dataToSend = {
        passwordHash: passwordHash,
        userName: this.formData.email
      }
      var onSuccess = response =>{
        self.handleSigninUser(response);
      }

      var onFail = response =>{
        self.errorMessage = "Details are Incorrect";
        setTimeout(() => {
          self.errorMessage = "";
        }, 5000);
      }
      this.$AjaxPostLogin(`Authentication/SignIn`,dataToSend,onSuccess,onFail);
    },
    handleSigninUser(data){

    }
  },
  mounted() { 

  },
}
</script>


