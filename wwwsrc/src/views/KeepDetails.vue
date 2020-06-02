<template>
  <div class="KeepDetails">
    <div class="container-fluid">
      <div class="row my-2 justify-content-around">
        <div class="col-md-5 col-10">
          <div class="card" style="max-width: 24rem;">
            <img :src="this.activeKeep.img" class="card-img text-center shadow rounded img-fuild" />
          </div>
        </div>
        <div class="col-md-5 col-10">
          <div class="card border-dark mb-3" style="max-width: 24rem">
            <div class="card-header">{{this.activeKeep.name}}</div>
            <div class="card-body text-dark">
              <p class="card-text">{{this.activeKeep.description}}</p>
              <ul>
                <li>Views: {{this.activeKeep.views}}</li>
                <li>Keeps: {{this.activeKeep.keeps}}</li>
              </ul>
              <button
                v-if="$auth.isAuthenticated"
                @click="deleteKeep"
                class="btn btn-sm btn-secondary"
              >Delete</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "KeepDetails",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("updateViewCount", this.$route.params.keepId);
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    deleteKeep() {
      if (this.$auth.user.sub != this.activeKeep.userId) {
        window.alert("This is not yours to delete")
      } else if (this.$auth.user.sub == this.activeKeep.userId) {
      swal
        .fire({
          title: "Are you sure?",
          text: "This cannot be undone!",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#85CF4B",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!"
        })
        .then(result => {
          if (result.value) {
            swal.fire("Completed!", "This Keep has been deleted.", "success");
            this.$store.dispatch("deleteKeep", this.$route.params.keepId);
            this.$router.push({ name: "home" });
          }
        });
      }
    }
  },
  components: {}
};
</script>


<style scoped>
</style>