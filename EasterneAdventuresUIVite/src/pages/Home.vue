<template>
  <div ref="HomePage" id="HomePage"> 
    <h1 class="Cover-Text">WELCOME TO ESTERNE ADVENTURES</h1>
    <h1 class="Cover-Text">THE JOY OF LIFE</h1>
    <div class="activity-area">
      <div class="activity-List-Item" v-for="(activity, index) in activityList" :key="index">
        <h3 style="color: white;">{{activity.name}}</h3>
      </div>
    </div>
  </div>
</template> 


<script>
export default {
  data() {
    return { 
      activityList:[],
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
      this.$router.push("/Login");
    },
    getActivities(){
      var self = this;
      var onSuccess = (response) => {
        self.activityList = response;
      };
      this.$AjaxGet(`Client/ListActivities`, onSuccess);
    },
  },
  mounted() { 
    this.getActivities();
  },
}
</script>


