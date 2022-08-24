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
  },{
    path:'/Dashboard',
      component:()=>
        import('./pages/Admin/Dashboard.vue')
      ,children:[
        {
          path:'/Activities',
          component: ()=>
            import("./pages/Admin/Activities.vue")
        }

      ]
    },
]

const router = new createRouter({
  history: createWebHistory(),
  routes, 
})

export default router