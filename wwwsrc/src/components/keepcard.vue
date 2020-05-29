<template>
  <div class="keepcard">
    <div class="card shadow mb-5 bg-white rounded">
      <img class="card-img-top" @click="keepDetails" :src="keepData.img" alt="Card image cap" />
        <h5 class="card-header text-center">{{keepData.name}}</h5>
      <div class="card-body">
        <p
          class="card-text"
        >{{keepData.description}}</p>
        <p class="card-text">
          <small class="text-muted">Views: {{keepData.views}}</small>
          <small class="mx-2 text-muted">Keeps: {{keepData.keeps}}</small>
        </p>
        <button v-if="$auth.isAuthenticated" @click="getUserVaults" type="button" data-toggle="modal" data-target="#exampleModal" class="btn btn-block btn-secondary">Save</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepcard",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    keepDetails() {
      this.$store.commit("setActiveKeep", this.keepData);
      this.$router.push({
        name: "KeepDetails",
        params: { keepId: this.keepData.id }
      });
    },
    getUserVaults() {
      this.$store.dispatch("getVaultsByUser");
      this.setActive();
    },
    setActive() {
      this.$store.commit("setActiveKeep", this.keepData);
    }
  },
  components: {}
};
</script>

<style scoped>
</style>