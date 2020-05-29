<template>
  <div class="vaultcard">
    <div class="card my-2" @click.prevent="getVaultKeeps">
      <button type="button" @click.prevent="deleteVault" class="close">
        <span aria-hidden="true">&times;</span>
      </button>
      <div class="card-body text-center">{{vaultData.name}}</div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaultcard",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    getVault() {
      this.$store.dispatch("getVault", vaultData);
    },
    getVaultKeeps() {
      this.$store.dispatch("getVaultKeeps", this.vaultData.id);
    },
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  },
  components: {}
};
</script>

<style scoped>
</style>