<template>
  <div class="vaultform">
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#vaultModal"
    >Create Vault</button>

    <!-- Vault Modal -->
    <div
      class="modal fade"
      id="vaultModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">New Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <div class="form-group row">
                <label for class="col-sm-2 col-form-label">Name</label>
                <div class="col-sm-10">
                  <input
                    v-model="newVault.Name"
                    required
                    type="text"
                    class="form-control"
                    placeholder
                  />
                </div>
              </div>
              <div class="form-group row">
                <label for class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                  <input
                    v-model="newVault.Description"
                    required
                    type="text"
                    class="form-control"
                    placeholder
                  />
                </div>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              @click.prevent="createVault"
              data-dismiss="modal"
              class="btn btn-primary"
            >Generate</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaultform",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {};
    }
  },
  components: {}
};
</script>
