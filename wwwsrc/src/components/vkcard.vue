<template>
  <div class="vkcard">
    <div class="card">
      <img class="card-img-top" @click="keepDetails" :src="keepData.img" alt="Card image cap" />
      <div class="card-body">
        <h5 class="card-title">{{keepData.name}}</h5>
        <p
          class="card-text"
        >{{keepData.description}}</p>
        <p class="card-text">
          <small class="text-muted">Views: {{keepData.views}}</small>
          <small class="mx-2 text-muted">Keeps: {{keepData.keeps}}</small>
        </p>
        <button v-if="$auth.isAuthenticated" @click="removeVaultKeep" type="button" data-toggle="modal" data-target="#exampleModal" class="btn btn-sm btn-secondary">Remove Keep</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: 'vkcard',
  props: ['keepData'],
  data(){
    return {}
  },
  computed:{},
  methods:{
    keepDetails() {
      this.$store.commit("setActiveKeep", this.keepData);
      this.$router.push({
        name: "KeepDetails",
        params: { keepId: this.keepData.id }
      });
    },
    removeVaultKeep() {
      this.$store.dispatch("removeVaultKeep", this.keepData.vaultKeepId);

    }
  },
  components:{}
}
</script>


<style scoped>

</style>