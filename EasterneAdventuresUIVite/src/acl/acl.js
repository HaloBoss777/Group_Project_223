import { computed } from 'vue'; // For VUE 3
import { createAcl, defineAclRules } from 'vue-simple-acl';
import router from '../router.js'
var user = () => {
  var userData = localStorage.getItem("userData");
  if(!userData){
    return {
      isAdmin:false,
      isEmployee:false,
      permissions: ['admin']
    }
  }
  return {
    isAdmin: JSON.parse(userData).isAdmin,
    isEmployee:!JSON.parse(userData).isClient,
    permissions: ['admin']
  };
}

const rules = () => defineAclRules((setRule) => {
  // setRule('unique-ability', callbackFunction(user, arg1, arg2, ...) { });
  // setRule(['unique-ability-1', 'unique-ability-2'], callbackFunction(user, arg1, arg2, ...) { });
  var ruleToUse = user();
  // Define a simple rule for ability with no argument
  setRule('admin', (user) => ruleToUse.isAdmin );
});

const simpleAcl = createAcl({
  user,
  rules,
  router, // short for rules: rules
  // other optional vue-simple-acl options here... See Vue Simple ACL Options below
});

export default simpleAcl;