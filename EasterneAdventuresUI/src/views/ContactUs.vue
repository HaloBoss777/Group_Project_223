<template>
    <div id="contactUs">
        
        <div class="contentHeader">
        </div>
        <div class="panel">
            <div class="">
                <h1>Get in touch</h1>
                    <div class="ContactnumContainer">
                        <div class="Contactnum">
                            <h2>Martin van Zyl</h2>
                            <h4>0828525533</h4>
                        </div>
                        <div class="Contactnum">
                            <h2>Hannes van Zyl</h2>
                            <h4>0833796104</h4>
                        </div>
                    </div>
                </div>
            </div>
        <div class="panel">
            <div>
                <h1>Email Us</h1>
            </div>
            <div class="content"> 
                <div class="icon">
                    
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 64 64" width="512" height="512"><g id="Email"><path d="M61.6,24.2,56,19.953V9a1,1,0,0,0-1-1H40.247L32.6,2.2a1,1,0,0,0-1.208,0L23.753,8H9A1,1,0,0,0,8,9V19.954L2.4,24.2A1,1,0,0,0,2,25V61a1,1,0,0,0,1,1H61a1,1,0,0,0,1-1V25A1,1,0,0,0,61.6,24.2ZM4,27.014,25.074,43,4,58.986ZM32,40.255,58.027,60H5.973ZM38.926,43,60,27.014V58.986ZM59.345,25,56,27.537V22.464ZM32,4.255,36.937,8H27.063ZM54,10V29.054L37.271,41.743,32.6,38.2a1,1,0,0,0-1.208,0l-4.667,3.541L10,29.054V10ZM8,27.537,4.655,25,8,22.463Z"/><path d="M32,33h3a1,1,0,0,0,0-2H32a7,7,0,1,1,7-7v2a1,1,0,0,1-2,0V24a5.024,5.024,0,1,0-1.534,3.59A2.994,2.994,0,0,0,41,26V24a9,9,0,1,0-9,9Zm0-6a3,3,0,1,1,3-3A3,3,0,0,1,32,27Z"/></g></svg>

                </div>
                <div class="container">
                    <div class="textboxes">
                        <input id="Name" type="text" placeholder="First Name" v-model="email.firstName">
                        <input id="Surname" type="text" placeholder="Last Name" v-model="email.lastName">
                        <input id="email" type="email" placeholder="What is your Email?" v-model="email.email">
                        <textarea id="message" class="message" placeholder="Your message..." v-model="email.message"></textarea>
                        <button @click="SignIn">Send Message</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

import axios from "axios";

export default {
    data(){
        return {
            email:{
                firstName:"",
                lastName:"",
                email:"",
                message:"",
            },
            btnIsDisabled: false,
        };
    },
    methods: {
        sendMessage(){
            var self = this;
            var onSuccess = response =>{
                this.$notify({
                    group: "Success", title: "Success", text: "Your email has been sent"
                },4000);
                this.initvalues();

            };
            self.$ajaxPost(self, "SendEmail" ,self.email, onSuccess);
            
        },
        SignIn(){

        },
        initvalues(){
            this.email.firstName = "";
            this.email.lastName = "";
            this.email.email = "";
            this.email.message = "";
        }
    },
    computed:{

    },
    components:{

    },
    mounted(){

    }
}
</script>

<style lang="scss">

</style>