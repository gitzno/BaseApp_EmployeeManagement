<template>
  <div class="application">
    <thelayout></thelayout>
    <!-- <router-view /> -->
  </div>
</template>

<script>
import thelayout from "./components/layout/thelayout.vue";


export default {
  name: "App",
  components: {
    thelayout,
  },
};
</script>

<style>
@import "./styles/base/main.css";
</style>
