<template>
  <div class="dashboard">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 text-center">
          <h1>WELCOME TO THE DASHBOARD</h1>
          <keepform></keepform>
          <vaultform></vaultform>
        </div>
        <div class="col-2">
          <vaultcard v-for="vault in vaults" :vaultData="vault" :key="vault.id"></vaultcard>
        </div>
        <div class="col-10">
          <div class="card-columns">
            <vkcard v-for="keep in vaultKeeps" :keepData="keep" :key="keep.Id"></vkcard>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import keepform from "../components/keepform.vue";
import vkcard from "../components/vkcard.vue";
import vaultform from "../components/vaultform.vue";
import vaultcard from "../components/vaultcard.vue";
export default {
  mounted() {
    this.$store.dispatch("getVaultsByUser");
    this.$store.dispatch("getKeepsByUser");
  },
  computed: {
    vaults() {
      return this.$store.state.userVaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  components: {
    keepform,
    vkcard,
    vaultform,
    vaultcard
  }
};
</script>

<style></style>

