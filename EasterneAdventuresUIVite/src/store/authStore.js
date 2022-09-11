import { defineStore,acceptHMRUpdate  } from "pinia";
export const useAuthStore = defineStore({
  id:"auth",
  state: () => ({ 
    fullName: "",
    isEmployee:false,
    isAdmin:false,
    isInstructor:false,
    jwtToken:"",
    client_Id:0,
    emp_Id:0
  }),
  getters: {
    isUserAdmin(){
      return this.isAdmin;
    }
  },
  actions: {
    setName(newName){
      this.fullName = newName;
    },
    setIsEmployee(isEmployee){
      this.isEmployee = isEmployee;
    },
    setIsAdmin(isAdmin){
      this.isAdmin = isAdmin;
    },
    setIsInstructor(isInstructor){
      this.isInstructor = isInstructor;
    },
    setJwtToken(jwtToken){
      this.jwtToken = jwtToken;
    },
    setClient_Id(client_Id){
      this.client_Id = client_Id;
    },
    setEmp_Id(emp_Id){
      this.emp_Id = emp_Id;
    },
    logout(){
      this.fullName= "",
      this.isEmployee=false,
      this.isAdmin=false,
      this.isInstructor=false,
      this.jwtToken="",
      this.client_Id=0,
      this.emp_Id=0
    }
  },
});

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useAuthStore, import.meta.hot))
}
