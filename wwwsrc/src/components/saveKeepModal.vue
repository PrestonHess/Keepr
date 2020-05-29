<template>
  <div class="saveKeepModal">
    <div
      class="modal fade"
      id="exampleModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Keepsake</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div v-for="vault in userVaults" :key="vault.id">
              <div class="form-check">
                <input class="form-check-input" @click="setVault(vault)" type="checkbox" value id="defaultCheck1" />
                <label class="form-check-label" for="defaultCheck1">{{vault.name}}</label>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" @click="createVaultKeep" data-dismiss="modal" class="btn btn-primary">Save</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "saveKeepModal",
  data() {
    return {
      checkedVault: {}
    };
  },
  computed: {
    userVaults() {
      return this.$store.state.userVaults;
    },
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    setVault(vault) {
      this.checkedVault = vault;
    },
    createVaultKeep() {
      let vaultKeep = {
        vaultId : this.checkedVault.id,
        keepId : this.keep.id
      }
      this.$store.dispatch("updateKeptCount", this.keep.id);
      this.$store.dispatch("createVaultKeep", vaultKeep);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>