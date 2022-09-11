
<script setup>
  import { useAuthStore } from '../store/authStore.js'
  const authStore = useAuthStore();
</script>

<template>
  <div>
    <div ref="LoginPage" id="LoginPage"> 
      <div class="login-Page">
        <h2 class="Title">Register</h2>
        <h3 style="color: red;" v-if="errorMessage">{{errorMessage}}</h3>
        <label for="email" class="inp">
          <input v-model="formData.email" @input="formData.email = $event.target.value" type="email" id="email" placeholder="&nbsp;">
          <span class="label">Email</span>
          <span class="focus-bg"></span>
        </label>
        <label for="password" class="inp">
          <input v-model="formData.full_name" @input="formData.full_name = $event.target.value" type="text" id="password" placeholder="&nbsp;"/>
          <span class="label">Full Name</span>
          <span class="focus-bg"></span>
        </label>
        <label for="password" class="inp">
          <input pattern="^(\+27|0)[6-8][0-9]{8}$" v-model="formData.cellNum" @input="formData.cellNum = $event.target.value" type="number" id="password" placeholder="&nbsp;"/>
          <span class="label">Cell Number</span>
          <span class="focus-bg"></span>
        </label>
        <label for="password" class="inp">
          <input v-model="formData.rSA_ID" @input="formData.rSA_ID = $event.target.value" type="text" id="password" placeholder="&nbsp;"/>
          <span class="label">RSA ID</span>
          <span class="focus-bg"></span>
        </label>
        <label for="password" class="inp">
          <input v-model="password" @input="password = $event.target.value" type="password" id="password" placeholder="&nbsp;"/>
          <span class="label">Password</span>
          <span class="focus-bg"></span>
        </label>
        <a class="mt-1" href="#" @click="goToLogin">I have an account</a>
        <button class="action-button Login-Btn" @click="validate">Register</button>
      </div>
    </div>
  </div>
</template> 


<script>
import md5 from "md5"
export default {
  data() {
    return { 
      formData:{
        email:"",
        passwordHash:"",
        full_name:"",
        cellNum:"",
        rSA_ID:""
      },
      password:"",
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
    goToLogin(){
      this.$router.push('/Login');
    },
    validate(){
      var emailValid = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(this.formData.email);
      if(!this.formData.email || !emailValid){
        this.$toast.error(`Email is invalid`);
        return ;
      }
      if(!this.formData.full_name || this.formData.full_name.length < 2){
        this.$toast.error(`Full Name is invalid`);
        return ;
      }
      if(!this.formData.cellNum || this.formData.cellNum.length != 10){
        this.$toast.error(`Cell Number is invalid`);
        return ;
      }
      if(!this.formData.rSA_ID || this.formData.rSA_ID.length != 13){
        this.$toast.error(`RSA ID is invalid`);
        return ;
      }
      if(!this.password || this.password.length < 8){
        this.$toast.error(`Password is invalid`);
        return ;
      }
      this.register();
    },
    register(){
      var self = this;
      var onSuccess = response =>{
        self.handleSigninUser(response);
      }

      var onError = response =>{
        if(response.response.data.includes("User exists")){
          this.$toast.error(`User exists`);
          this.errorMessage = "User Exists"
        }
        else{
          this.$toast.error(`Error`);
          this.errorMessage = "Error"
        }
        setTimeout(() => {
          self.errorMessage = ""
        }, 5000);
      }
      var dataToSend = {
        email:self.formData.email,
        passwordHash:md5(self.password),
        full_name:self.formData.full_name,
        cellNum:self.formData.cellNum,
        rSA_ID:self.formData.rSA_ID
      }
      self.$AjaxPostLogin("Client/Register" , dataToSend , onSuccess, onError);
    },
    handleSigninUser(data){
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


