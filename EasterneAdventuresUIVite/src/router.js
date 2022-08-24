import {createRouter , createWebHistory } from 'vue-router'


var routes = [{
  path:'',
  component:()=>
    import('./pages/Home.vue')
}]

const router = new createRouter({
  history: createWebHistory(),
  routes, 
})

export default router