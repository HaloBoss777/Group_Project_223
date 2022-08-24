import {createRouter , createWebHistory } from 'vue-router'


var routes = [{
    path:'/',
    component:()=>
      import('./pages/Home.vue')
  },{
  path:'/Home',
    component:()=>
      import('./pages/Home.vue')
  },{
  path:'/Login',
    component:()=>
      import('./pages/Login.vue')
  },
]

const router = new createRouter({
  history: createWebHistory(),
  routes, 
})

export default router