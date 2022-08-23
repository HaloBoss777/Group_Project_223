import Vue from 'vue'
import App from './App.vue'

import router from './router'

import Vuesax from 'vuesax'

import '../src/assets/main.css'; 

Vue.use(Vuesax)

import Notifications from "vt-notifications";

Vue.use(Notifications);
// axios
import axios from 'axios'


axios.defaults.baseURL = 'https://www.carnagehosting.com/api/'
//axios.defaults.baseURL = 'https://localhost:44393/api/'
import '../themeConfig.js'
Vue.prototype.$http = axios
Vue.config.productionTip = false


Vue.prototype.$digiSetPermissions = function (self, success) {
  if(localStorage.getItem("signedIn")){

  }else{
    localStorage.setItem("signedIn", "false");
  }
    success();
}

import VueAnalytics from 'vue-analytics';
Vue.use(VueAnalytics, {
  id: 'UA-159115893-5',
  router
});

Vue.prototype.$VUE_APP_ROOT_API = process.env.VUE_APP_ROOT_API;
Vue.prototype.$buildUrl = function(path) {
  return  "https://www.carnagehosting.com/api/" + path;
  //return  "https://localhost:44393/api/" + path;
}
localStorage.setItem("signedin","false");

Vue.prototype.$ajaxGet = function (self, myUrl, formData, onSuccess, onFinally) {
  var mySelf = this;
  return axios({
    method: 'get',
    url: mySelf.$buildUrl(myUrl),
    headers:{'Content-type': 'application/x-www-form-urlencoded'},
    params:{formData},
  }).then(response => {
    if (onSuccess && typeof onSuccess == "function")
      onSuccess(response);
  })
    .catch(function (error) {
      var exception = "";
      var colour = "danger";
      if (error.response) {
        if (error.response.status == 401) {
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 405) {
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 498) {
          localStorage.setItem("accessToken","");
          router.push('/login');
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 500) {
          exception = error.response.data.message;
          colour = "danger";
        }
      } else {
        exception = error.message;
        colour = "danger";
      }
    })
    .finally(onFinally)
}

Vue.prototype.$usersignedIN = "Sign In";


Vue.prototype.$checkSignInUser = function(){
  var temp = localStorage.getItem("Username");
  if(temp != null || temp != "False"){
    return true
  }
  else
    return false
}

Vue.prototype.$ajaxPost = function (self, myUrl, formData, onSuccess, onFinally) {
  var mySelf = this;
  return axios({
    method: 'post',
    url: mySelf.$buildUrl(myUrl),
    data: formData,
  }).then(response => {
    if (onSuccess && typeof onSuccess == "function")
      onSuccess(response);
  })
    .catch(function (error) {
      var exception = "";
      var colour = "danger";
      if (error.response) {
        if (error.response.status == 401) {
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 405) {
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 498) {
          localStorage.setItem("accessToken", "");
          router.push('/login');
          exception = error.response.data.message;
          colour = "warning";
        } else if (error.response.status == 500) {
          exception = error.response.data.message;
          colour = "danger";
        }
      } else {
        exception = error.message;
        colour = "danger";
      }
    })
    .finally(onFinally);
}

Vue.prototype.$redirectToRegPage = function () {
  if (window.location.href.includes("vanzylboorwerke")) {
    window.open('http://http://vanzylboorwerke.com/index.html?page=reg', '_blank')
  }
}
Vue.prototype.$http = 'https://vanZylboorwerke.com/api';

Vue.prototype.$_primary = "#212121";
Vue.prototype.$_secondary = "#F6F6F6";
Vue.prototype.$setColors = function() {
  
  this.$_primary = "#212121";
  this.$_secondary = "#F6F6F6";
  this.$vs.theme({ primary: this.$_primary });
  this.$vs.theme({ secondary: this.$_secondary });
}


new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
