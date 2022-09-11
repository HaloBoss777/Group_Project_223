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
    path:'/Cart',
    component: ()=>
      import("./pages/Client/Cart.vue"),
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
      name:"Dashboard",
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
        {
          path:'/Equipment',
          name:"Equipment",
          component: ()=>
            import("./pages/Admin/Equipment.vue")
        },
        {
          path:'/Bookings',
          name:"Bookings",
          component: ()=>
            import("./pages/Admin/Bookings.vue")
        },
      ]
    },
]



const router = new createRouter({
  history: createWebHistory(),
  routes, 
})


export default router