<template>
    <div class="navbar">
        <div class="nav">
            <input type="checkbox" id="nav-check">
            <div class="nav-header">
                <div class="nav-title" @click="toHome">
                Forum
                </div>
            </div>
            <div class="nav-btn">
                <label for="nav-check">
                <span></span>
                <span></span>
                <span></span>
                </label>
            </div>
            
            <div class="nav-links">
                <a  @click="toHome">Home</a>
                <a  @click="toPrices"  >{{datatoSend}}</a>
            </div>
        </div>

        <notificationGroup group="Success">
            <div class="notification">
                <div class="max-w-sm w-full">
                <notification v-slot="{notifications}">
                    <div
                    class="notificationDiv"
                    v-for="notification in notifications"
                    :key="notification.id"
                    >
                    <div class="svgContainer">
                        <svg class="h-6 w-6 fill-current text-white" viewBox="0 0 40 40" xmlns="http://www.w3.org/2000/svg">
                            <path d="M20 3.36667C10.8167 3.36667 3.3667 10.8167 3.3667 20C3.3667 29.1833 10.8167 36.6333 20 36.6333C29.1834 36.6333 36.6334 29.1833 36.6334 20C36.6334 10.8167 29.1834 3.36667 20 3.36667ZM19.1334 33.3333V22.9H13.3334L21.6667 6.66667V17.1H27.25L19.1334 33.3333Z"/>
                        </svg>
                    </div>

                    <div class="notificationText">
                        <div class="mx-3">
                            <span class="text-red-500 font-semibold">{{notification.title}}</span>
                            <p class="text-gray-600 text-sm">{{notification.text}}</p>
                        </div>
                    </div>
                    </div>
                </notification>
                </div>
            </div>
        </notificationGroup>
    </div>
</template>


<script>
export default {
    name: "the-navbar",
    components:{
        
    },
    data() {
        return {
            bugerOpen:false,
            scrollPosition: null,
            navbaritem: this.$usersignedIN,
            renderComponent:true,
        }
    },
    computed:{
       
    },
    watch:{

        
    },
    props:{
        datatoSend:{
            type:String,
            required:true
        },
    },
    methods:{
        toHome(){
            var self = this;
            self.bugerOpen = false;
            this.$router.push('/Home');
        },
        toContactUs(){
            var self = this;
            self.bugerOpen = false;
            this.$router.push('/ContactUs');
        },
        toPrices(){
            var self = this;
            self.bugerOpen = false;
            this.$router.push('/SignIn');
        },
        toWorked(){
            var self = this;
            self.bugerOpen = false;
            this.$router.push('/Work');
        },
        changeIcon(){
            var self = this;
            self.bugerOpen = !self.bugerOpen;
        },
        updateScroll() {
            //this.scrollPosition = window.scrollY;
        },
        
    },
    mounted(){
        //window.addEventListener('scroll', this.updateScroll);
        var self = this;
        
    }
}

</script>

