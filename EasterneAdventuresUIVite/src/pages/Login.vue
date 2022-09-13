
<template>
  <div>
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
import md5 from "md5"
import { useAuthStore } from '../store/authStore.js'
  const authStore = useAuthStore();
export default {
  data() {
    return {
      authStore:useAuthStore(),
      formData:{
        email:"",
        password:"",
      },
      errorMessage:""
    }
  },
  components:{ 
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
      debugger
      if(data.isClient){
        this.authStore.setClient_Id(data.id);
      }
      else{
        this.authStore.setEmp_Id(data.id);
        this.authStore.setIsEmployee(true);
      }
      this.authStore.setIsAdmin(data.isAdmin);
      this.authStore.setIsInstructor(data.isInstructor);
      this.authStore.setJwtToken(data.apiToken);
      this.authStore.setName(data.fullName);

      localStorage.setItem("userData",JSON.stringify(data));

      if(data.isAdmin){
        // this.$router.push("/Dashboard");
        window.open("/Dashboard","_self")
      }
      else{
        this.$router.push("/Home");
      }
    }
  },
  mounted() { 

  },
}
</script>


