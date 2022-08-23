<template>
    <div id="Home" class="scrollbar">
        <div>
            <div class="topicContainer">
                <div class="TopicHeader">
                    <h1>Whooo Project{{item}}</h1>
                    <button @click="item++" >Click Here</button>
                </div>
               <div class="topicitemcontainer">
                    <div class="topicItem" v-for="(item, itemIndex) in topics" :key="itemIndex">
                        <h2 @click="ThreadsFilter(item.topic_ID)" >{{item.topic_Name}}</h2>
                    </div>
               </div>
               <div v-if="checkSignedin()" class="addTopicplus">
                    <h3 @click="viewTopicAdd">+ Add Topic</h3>
                </div>
                <div v-if="addTopics" class="addTopic">
                    <input type="text" placeholder="Enter Topic" v-model="topicToAdd" >
                    <button @click="addTopicsmethod">Add Topic</button>
                </div>
            </div>
            <div class="threadContainer" >
                <div class="threadHeader">
                    <h1 >Threads for topic:</h1>
                    <h2 v-if="selectedTopic.length !=0">{{selectedTopic[0].topic_Name}}</h2>
                </div>
                <div class="threadItemContainer">
                    <div @click="postFilter(thread.thread_ID)" class="threadItem" v-for="(thread, threadsIndex) in FilterThreads" :key="threadsIndex">
                        <h2>{{thread.thread_Heading}}</h2>
                    </div>
                    
                </div>
                <div v-if="checkSignedin()" class="addThreadplus">
                        <h3 @click="viewThreadAdd">+ Add Thread</h3>
                    </div>
                    <div v-if="addThread" class="addThread">
                        <input type="text" placeholder="Enter Thread" v-model="threadToAdd">
                        <button @click="addThreadsMethod()">Add Thread</button>
                    </div>
            </div>
            
            <div class="messagecontainer">
                <div class="messageBox" v-if="FilterPosts.length !=0">
                    <div class="messageItem"  v-for="(post, postIndex) in FilterPosts" :key="postIndex">
                        <div class="message">
                            <input v-model="post.post_Content" disabled>
                            <div class="date">
                                <p>{{post.date_Created}}</p>
                            </div>
                            <div class="user">
                                <p>{{post.user_name}}</p>
                            </div>
                        </div>
                        
                    </div>
                    
                </div>
            </div>
            <div v-if="checkSignedin() " class="addPostplus">
                <h3 v-if="selectedThread.thread_ID !=0" @click="viewPostAdd">+ Add Post</h3>
            </div>
            <div v-if="addPost" class="addPost">
                <textarea class="message" type="text" v-model="postToAdd"></textarea>
                <button @click="addPostMethod">Add Post</button>
            </div>


        </div>
    </div>
    
</template>
<script>

import slidervue from '../components/slider.vue';


export default {
    data(){
        return {
            topics:[],
            threads:[],
            selectedTopic:[{topic_Name:null}],
            selectedThread:{thread_ID:0},
            FilterThreads:[],
            Post:[],
            FilterPosts:[],
            UserList:[],
            addTopics:false,
            addThread:false,
            addPost:false,
            topicToAdd:"",
            threadToAdd:"",
            postToAdd:"",
            item:0,
        };
    },
    methods: {
        getUserId(){
            var self = this;
        },
        viewTopicAdd(){
            var self = this;
            self.addTopics = !self.addTopics;
            self.addThread= false;
            self.addPost = false;
        },
        viewThreadAdd(){
            var self = this;
            self.addThread= !self.addThread;
            self.addPost = false;
            self.addTopics = false;
        },
        viewPostAdd(){
            var self = this;
            self.addPost = !self.addPost;
            self.addThread= false;
            self.addTopics = false;
        },
        addTopicsmethod(){
            var self = this;
            var datatoSend = {
                topic_Name: self.topicToAdd
            };
            var onSuccess = response =>{
                self.viewTopicAdd();
                this.$notify({
                    group: "Success", title: "Success", text: "Topic Created"
                },4000);
                
                self.getTopics();
            };

            self.$ajaxPost(self, "CreateTopic" ,datatoSend, onSuccess);
        },

        addThreadsMethod(){
            var self = this;
            var templist = self.topics.filter(x=>x.topic_Name == self.selectedTopic[0].topic_Name);

            var datatoSend = {
                topic_ID: templist[0].topic_ID,
                thread_Heading: self.threadToAdd

            };
            var onSuccess = response =>{
                self.viewThreadAdd();
                this.$notify({
                    group: "Success", title: "Success", text: "Thread Created"
                },4000);
                
                self.getThreads();
            };

            self.$ajaxPost(self, "Createthread" ,datatoSend, onSuccess);
        },

        addPostMethod(){
            var self = this;
            debugger
            var topictoUse = self.topics.filter(x=>x.topic_Name == self.selectedTopic[0].topic_Name);

            var datatoSend = {
                post_Type: "",
                thread_ID: self.selectedThread.thread_ID,
                topic_ID: topictoUse[0].topic_ID,
                post_Content: self.postToAdd,
                Topic_Cat:"2"

            };
            var onSuccess = response =>{
                self.getPosts();
                self.viewPostAdd();
                this.$notify({
                    group: "Success", title: "Success", text: "Thread Created"
                },4000);
                
                self.postFilter(self.selectedThread.thread_ID);
            };

            self.$ajaxPost(self, "AddPost" ,datatoSend, onSuccess);
        },

        getTopics(){
            var self = this;
            var onSuccess = response =>{
                self.topics = response.data;
            };
            self.$ajaxGet(self, "ListTopics" ,self.email, onSuccess);
        },
        getThreads(){
            var self = this;
            var onSuccess = response =>{
                self.threads = response.data;
                self.selectedTopic = self.topics.filter(x=> x.topic_ID == self.threads[0].topic_ID);
            };
            self.$ajaxGet(self, "Listthreads" ,self.email, onSuccess);
        },
        ThreadsFilter(id){
            var self = this;
            self.selectedTopic = self.topics.filter(x=> x.topic_ID == id);
            self.FilterThreads = self.threads.filter(x=>x.topic_ID == id);
            self.FilterPosts = [];
            self.selectedThread={thread_ID:0};
        },

        getPosts(){
            var self = this;
            var onSuccess = response =>{
                self.Post = response.data;
            };
            self.$ajaxGet(self, "ListPosts" ,self.email, onSuccess);
        },
        postFilter(id){
            var self = this;
            self.FilterPosts = self.Post.filter(x=>x.thread_ID == id);
            self.selectedThread.thread_ID = id;
        },
        getUsers(){
            var self = this;

        },
        checkSignedin(){
            var temp = localStorage.getItem("Username");
            if(temp == null || temp == "False"){
                return false
            }
            else
                return true
        }
    },
    components:{
        slidervue
    },
    mounted(){
        if(localStorage.getItem("signedIn")){
            
        }
        else{
            localStorage.clear();
            sessionStorage.clear();
        }
        var self = this;
        self.getPosts();
        self.getTopics();
        self.getThreads();
    }
}
</script>

<style lang="scss">

</style>