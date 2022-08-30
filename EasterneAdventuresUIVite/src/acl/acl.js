import { computed } from 'vue'; // For VUE 3
import { createAcl, defineAclRules } from 'vue-simple-acl';
import router from '../router.js'

var user = () => {
   // ID of authenticated user
  var userData = localStorage.getItem("userData");
  if(!userData){
    return user = {
      isAdmin:false,
      isEmployee:false
    }
  }
  return user = {
    isAdmin: JSON.parse(userData).isAdmin,
    isEmployee:JSON.parse(userData).isEmployee
  }
}


const rules = () => defineAclRules((setRule) => {
  // setRule('unique-ability', callbackFunction(user, arg1, arg2, ...) { });
  // setRule(['unique-ability-1', 'unique-ability-2'], callbackFunction(user, arg1, arg2, ...) { });
  
  // Define a simple rule for ability with no argument
  setRule('admin', (user) => user.isAdmin);
});

const simpleAcl = createAcl({
  user, // short for user: user
  rules,
  router, // short for rules: rules
  // other optional vue-simple-acl options here... See Vue Simple ACL Options below
});

export default simpleAcl;