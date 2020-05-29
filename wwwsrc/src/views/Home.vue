<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row justify-content-center">
        <div class="col-10">
          <div class="card-columns">
            <keepcard v-for="keep in pubKeeps" :keepData="keep" :key="keep.Id"></keepcard>
          </div>
          <save-keep-modal></save-keep-modal>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import keepcard from "../components/keepcard.vue";
import saveKeepModal from "../components/saveKeepModal.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPubKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    pubKeeps() {
      return this.$store.state.publicKeeps;
    },
    userVaults() {
      return this.$store.state.userVaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keepcard,
    saveKeepModal
  }
};
</script>

<style>
</style>