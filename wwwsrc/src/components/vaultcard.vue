<template>
  <div class="vaultcard">
    <div class="card bg-light shadow my-2">
      <button type="button" @click.prevent="deleteVault" class="close">
        <span aria-hidden="true">&times;</span>
      </button>
      <div class="card-body text-center text-capitalize" @click.prevent="getVaultKeeps">{{vaultData.name}}</div>
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
.shadow {
  background: #111;
  color:rgb(0, 0, 0);
}

.shadow::before, shadow::after{
  z-index: -1;
  content: '';
  position: absolute;
  width: calc(100% + 6px);
  height: calc(100% + 6px);
  top: -3px;
  left: -3px;
  background: linear-gradient(45deg, #fc0090, #0000ff,
              #00ff00, #ff0000, #ffff00, #fc0090,
              #0000ff, #00ff00, #ff0000, #ffff00);
  background-size: 300%;
  animation: shadow 20s linear infinite;
}

.shadow::after{
  filter: blur(30px)
}

@keyframes shadow{
  0%{ background-position: 0 0; }
  50%{ background-position: 300%; }
  100%{ background-position: 0 0; }
}
</style>