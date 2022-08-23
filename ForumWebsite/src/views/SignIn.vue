<template>
    <div class="left-right" id="contactUs">
        <div class="panel">
            <div>
                <h1>Sign In</h1>
            </div>
            <div class="content"> 
                
                <div class="container">
                    <div class="textboxes">
                       <!-- <input id="Name" type="text" placeholder="First Name" v-model="email.firstName">
                        <input id="Surname" type="text" placeholder="Last Name" v-model="email.lastName">-->
                        <input id="email" type="email" placeholder="What is your Email?" v-model="forum.user_Email">
                        <input id="password" type="password" placeholder="Enter Password" v-model="forum.user_PasswordHash">
                        <button @click="SignIn">Sign In</button>
                    </div>
                    <div class="options">
                        <h4 @click="goToSignUp">Do not have an account ?</h4>
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
            forum:{
                user_Email:"",
                user_PasswordHash:"",
            },
            btnIsDisabled: false,
        };
    },
    methods: {
        SignIn(){
            var self = this;
            debugger
            // const requestOptions = {
            //     method:"POST",
            //     headers:{"Content-Type":"application/json"},
            //     body:JSON.stringify(self.forum),
            // };
            // fetch("https://localhost:44393/api/SignIn",requestOptions)
            //     .then(response => response.json())
            //     .then(data => data);





            var onSuccess = response =>{
                if(response.data != "false"){
                    localStorage.setItem("signedIn", "true");
                    localStorage.setItem("Username",response.data);
                    self.$usersignedIN = response.data;
                    this.$notify({
                    group: "Success", title: "Success", text: "You have been signed in"
                    },4000);
                    this.$router.push('/Home');
                }else{

                }

            };
            self.$ajaxPost(self, "SignIn" ,self.forum, onSuccess);
        },
        goToSignUp(){
            var self = this;
            this.$router.push('/SignUp');
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