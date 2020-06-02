import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userVaults: [],
    vaultKeeps: [],
    userKeeps: [],
    activeKeep: {}
  },
  mutations: {
    setPubKeeps(state, payload) {
      state.publicKeeps = payload;
    },
    setUserVaults(state, payload) {
      state.userVaults = payload;
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload;
    },
    setVaultKeeps(state, payload) {
      state.vaultKeeps = payload;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#region ---- KEEPS ----
    async createKeep({ dispatch, commit}, keepData) {
      try {
        let res = await api.post("keeps", keepData);
        console.log(res.data);
        // NEXT ACTION?
      } catch (error) {
        console.error(error);
      }
    },
    async getPubKeeps({ dispatch, commit}) {
      try {
        let res = await api.get("keeps");
        commit("setPubKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeepsByUser({ dispatch, commit }) {
      try {
        let res = await api.get(`keeps/user`);
        commit("setVaultKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getOneKeep({ dispatch, commit }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId);
        commit("setActiveKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async updateViewCount({ dispatch, commit}, keepId) {
      try {
        await api.put(`keeps/${keepId}/views`);
        dispatch("getOneKeep", keepId);
      } catch (error) {
        console.error(error);
      }
    },
    async updateKeptCount({dispatch, commit}, keepId) {
      try {
        await api.put(`keeps/${keepId}/kepts`);
        dispatch("getPubKeeps");
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ dispatch, commit}, keepId) {
      try {
        await api.delete(`keeps/${keepId}`);
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion
    //#region ---- VAULTS -----
    async createVault({ dispatch, commit}, vaultData) {
      try {
        let res = await api.post("vaults", vaultData);
        dispatch("getVaultsByUser");
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultsByUser({ dispatch, commit }) {
      try {
        let res = await api.get("vaults");
        commit("setUserVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getVault({ dispatch, commit }, vaultData) {
      try {
        let res = await api.get("vaults/" + vaultData.name, vaultData)
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({ dispatch, commit }, vaultId) {
      try {
        await api.delete(`vaults/${vaultId}`);
        dispatch("getVaultsByUser");
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion
    //#region ---VaultKeeps----
    async createVaultKeep({dispatch, commit}, vaultKeep) {
      try {
        await api.post("vaultkeeps", vaultKeep);
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultKeeps({ dispatch, commit }, vaultId) {
      try {
        let res = await api.get(`vaults/${vaultId}/keeps`);
        commit('setVaultKeeps', res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async removeVaultKeep({ dispatch, commit }, vkId) {
      try {
        await api.delete(`vaultkeeps/${vkId}`);
        dispatch("getKeepsByUser");
      } catch (error) {
        console.error(error);
      }
    }
  }
});
