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
      import('./pages/Login.vue'),
  },
  {
    path:'/Unauthorized',
    component:()=>
      import('./pages/Unauthorized.vue')
  }
  ,{
    path:'/Register',
      component:()=>
        import('./pages/Register.vue')
    },{
    path:'/Dashboard',
      name:"Home",
      component:()=>
        import('./pages/Admin/Dashboard.vue')
      ,meta:{
        can:'admin',
        onDeniedRoute: '/Unauthorized'
      }
      ,children:[
        {
          path:'/Activities',
          name:"Activities",
          component: ()=>
            import("./pages/Admin/Activities.vue")
        },
        {
          path:'/Employees',
          name:"Employees",
          component: ()=>
            import("./pages/Admin/Employees.vue")
        },
      ]
    },
]



const router = new createRouter({
  history: createWebHistory(),
  routes, 
})


export default router