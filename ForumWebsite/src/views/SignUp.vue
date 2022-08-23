<template>
    <div class="left-right" id="contactUs">
        <div class="panel">
            <div>
                <h1>Sign Up</h1>
            </div>
            <div class="content"> 
                
                <div class="container">
                    <div class="textboxes">
                        <input id="Name" type="text" placeholder="What is your Name" v-model="email.User_Name">
                        <input id="email" type="email" placeholder="What is your Email?" v-model="email.User_Email">
                        <input id="password" type="password" placeholder="Enter Password" v-model="email.User_PasswordHash">
                        <button @click="SignIn">Sign Up</button>
                    </div>
                    <div class="options">
                        <h4 @click="goToSignIn">Already registered ?</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>



export default {
    data(){
        return {
             email:{
                User_Name:"",
                User_Email:"",
                User_PasswordHash:"",
            },
            btnIsDisabled: false,
        };
    },
    methods: {
        SignIn(){
            var self = this;
            var onSuccess = response =>{
                debugger
                this.$notify({
                group: "Success", title: "Success", text: "You have been signed up"
                },4000);
                this.$router.push('/Home');
                localStorage.setItem("signedIn", "true");
            };
            self.$ajaxPost(self, "AddUser" ,self.email, onSuccess);
        },
        goToSignIn(){
            var self = this;
            this.$router.push('/SignIn');
        }
    },
    components:{
    },
    mounted(){

    }
}
</script>

<style lang="scss">

</style>