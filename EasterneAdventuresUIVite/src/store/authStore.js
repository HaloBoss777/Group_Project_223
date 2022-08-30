import { defineStore } from "pinia";
export const useAuthStore = defineStore("auth", {
  state: () => ({ 
    fullName: "Eduardo",
  }),
  getters: {
    
  },
  actions: {
    setName(newName){
      this.fullName = newName;
    },
  },
});
