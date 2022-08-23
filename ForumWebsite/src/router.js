

import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)



const router = new Router({
    mode: 'hash',
    base: process.env.BASE_URL,
    scrollBehavior() {
        return { x: 0, y: 0 }
    },
    routes: [
        {
            path: '',
            redirect: '/Home',
            component: () =>
                import ('./views/Home.vue'),
            children:[
                {
                    path: '/',
                    redirect: '/Home'
                },
                {
                    path: '/Home',
                    name: 'Home',
                    component: () =>
                        import ('./views/Home.vue'),
                    meta: {
                        pageTitle: 'Home'
                    }
                },
                
                
            ],
            
        },
        {
            path: '/ContactUs',
            name: 'ContactUs',
            component: () =>
                import ('./views/ContactUs.vue'),
            meta: {
                pageTitle: 'Contact Us'
            },
        },
        {
            path: '/Work',
            name: 'Work',
            component: () =>
                import ('./views/Worked.vue'),
            meta: {
                pageTitle: 'Worked for'
            },
        },{
            path: '/SignIn',
            name: 'SignIn',
            component: () =>
                import ('./views/SignIn.vue'),
            meta: {
                pageTitle: 'SignIn'
            },
        },,{
            path: '/SignUp',
            name: 'SignUp',
            component: () =>
                import ('./views/SignUp.vue'),
            meta: {
                pageTitle: 'SignUp'
            },
        },
    ]
});

router.afterEach((to, from) => {
    // Remove initial loading

    if (from.name) {
        var currentModuleId = localStorage.getItem("currentModule");
        if (to.name == "CourseBuilder") {
            if (currentModuleId) {
                document.location.href = to.path;
            } else {
                //use routing
                router.push({ path: '/selectcourse' });
            }
        }
    }
    const appLoading = document.getElementById('loading-bg')
    if (appLoading) {
        appLoading.style.display = "none";
    }
})

router.beforeEach((to, from, next) => {
    return next();
    //firebase.auth().onAuthStateChanged(() => {
    //  const firebaseCurrentUser = firebase.auth().currentUser;

    //  if (
    //    to.path === "/login" ||
    //    to.path === "/digilogin" ||
    //    to.path === "/forgot-password" ||
    //    to.path === "/pages/error-404" ||
    //    to.path === "/pages/error-500" ||
    //    to.path === "/pages/register" ||
    //    to.path === "/callback" ||
    //    to.path === "/pages/comingsoon" ||
    //    (firebaseCurrentUser)
    //  ) {

    //  }
    //  router.push({ path: '/login' })
    //});

});

export default router