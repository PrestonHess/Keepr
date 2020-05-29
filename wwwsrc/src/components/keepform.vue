<template>
  <div class="keepform">
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#exampleModalCenter"
    >Create Keep</button>

    <!-- Modal -->
    <div
      class="modal fade"
      id="exampleModalCenter"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">New Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <div class="form-group row">
                <label for class="col-sm-2 col-form-label">Name</label>
                <div class="col-sm-10">
                  <input v-model="newKeep.Name" type="text" class="form-control" placeholder />
                </div>
              </div>
              <div class="form-group row">
                <label for class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                  <input v-model="newKeep.Description" type="text" class="form-control" placeholder />
                </div>
              </div>
              <div class="form-group row">
                <label for class="col-sm-2 col-form-label">Image</label>
                <div class="col-sm-10">
                  <input v-model="newKeep.Img" type="text" class="form-control" placeholder />
                </div>
              </div>
              <div class="form-check">
                <input class="form-check-input" @click="togglePrivate" type="checkbox" value id="defaultCheck1" />
                <label class="form-check-label" for="defaultCheck1">Make Private</label>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              @click.prevent="createKeep"
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
  name: "keepform",
  data() {
    return {
      newKeep: {},
      IsPrivate: false
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.newKeep.IsPrivate = this.IsPrivate;
      this.$store.dispatch("createKeep", this.newKeep);
      this.$store.dispatch("getKeepsByUser");
      this.newKeep = {};
    },
    togglePrivate() {
      if (this.IsPrivate == false) {
        this.IsPrivate = true;
      } else if (this.IsPrivate == true) {
        this.IsPrivate = false;
      }
    }
  },
  components: {}
};
</script>


<style scoped>
</style>