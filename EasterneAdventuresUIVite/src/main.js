import { createApp, h } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueFeather from 'vue-feather';
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';
import {createPinia} from 'pinia'

const app = createApp({
  render:()=>h(App)
});

const pinia = createPinia();

app.use(pinia);
app.use(VueSweetalert2);
app.use(router);
app.component(VueFeather.name,VueFeather);






var UrlBuilder = (url) => {
  return `https://localhost:44393/api/${url}`;
}


app.config.globalProperties.$AjaxGetAnon = (url,OnSuccess,onFinally) =>{
  var urlBuilt = UrlBuilder(url);
  return axios({
    method:'get',
    url:urlBuilt
  }).then(response =>{
    if(OnSuccess){
      OnSuccess(response.data)
    }
  }).catch(error =>{

  }).finally(response =>{
    if(onFinally){
      onFinally(response);
    }
  })
}

app.config.globalProperties.$AjaxGet = (url,OnSuccess,onFinally) =>{
  var urlBuilt = UrlBuilder(url);
  var myAccessToken = JSON.parse(localStorage.getItem("userData")).apiToken.toString();
  return axios({
    method:'get',
    url:urlBuilt,
    headers:{
      'Authorization': 'Bearer ' + myAccessToken, 
    }
  }).then(response =>{
    if(OnSuccess){
      OnSuccess(response.data)
    }
  }).catch(error =>{

  }).finally(response =>{
    if(onFinally){
      onFinally(response);
    }
  })
}

app.config.globalProperties.$AjaxPostAnon = (url,sendData,OnSuccess,onFinally) =>{
  var urlBuilt = UrlBuilder(url);
  return axios({
    method:'post',
    url:urlBuilt,
    data:sendData,
  }).then(response =>{
    if(OnSuccess){
      OnSuccess(response.data)
    }
  }).catch(error =>{

  }).finally(response =>{
    if(onFinally){
      onFinally(response);
    }
  })
}

app.config.globalProperties.$AjaxPostLogin = (url,sendData,OnSuccess,onFail) =>{
  var urlBuilt = UrlBuilder(url);
  return axios({
    method:'post',
    url:urlBuilt,
    data:sendData,
  }).then(response =>{
    if(OnSuccess){
      OnSuccess(response.data)
    }
  }).catch(error =>{
    onFail(error)
  }).finally(response =>{
  })
}



app.mount('#app')
