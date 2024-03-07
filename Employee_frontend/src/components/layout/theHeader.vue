<template lang="">
  <div id="header--container">
    <div class="header--left">
      <div class="icon--header">
        <icon nameIcon="candy--box--black"></icon>
      </div>
      <div class="logo--header">
        <div class="logo"></div>
      </div>
      <div class="header--search">
        <textFeild></textFeild>
      </div>
    </div>
    <div class="header--right">
      <div class="avatar">

      </div>
    </div>
  </div>
</template>
<script>
import icon from "../base/icon.vue";
import textFeild from "../base/textfield.vue";
export default {
  components: {
    icon,
    textFeild,
  },
};
</script>
<style scoped>
.header--search{
  display: flex;
  align-items: center;
}
.icon--header{
  display: flex;
  align-items: center;
}
#header--container {
  justify-content: space-between;
  background-color: white;
  width: 100%;
  height: 56px;
  display: flex;
  align-items: center;
}
.header--left {
  display: flex;
}
#header--container .icon--header {
  padding: 20px;
}
.logo {
  background: url("../../assets/icon/icon.svg") no-repeat -1131px -1688px;
  width: 150px;
  height: 36px;
}
.logo--header {
  padding: 20px;
}
.avatar{
  margin-right: 30px;
  border-radius: 100%;
  height: 40px;
  width: 40px;
  background-color: black;
}
</style>
