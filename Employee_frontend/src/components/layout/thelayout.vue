<template>
  <div id="layout">
    <theHeader></theHeader>
    <div id="container--main">
      <theSlidebar></theSlidebar>
      <router-view class="main--content"/>
      <!-- <theCustomerPage class="main--content"></theCustomerPage> -->
    </div>
  </div>
</template>

<script>
import theHeader from "./theHeader.vue";
import theSlidebar from "./theSlidebar.vue";
// import theCustomerPage from "./theCustomerPage.vue";
export default {
  name: "TheLayOut",
  components: {
    theHeader,
    theSlidebar,
    // theCustomerPage,
  },
  data() {
    return {
      openbtn: true,
      list: [
        { value: 1, name: "Hà Nội" },
        { value: 2, name: "Sơn La" },
        { value: 3, name: "Làng Lá" },
        { value: 4, name: "Hoa Phượng Đỏ" },
        { value: 5, name: "HoLa" },
        { value: 6, name: "Halo" },
      ],
    };
  },
};
</script>

<style>
#layout {
  display: flex;
  flex-direction: column;
  background-color: #f4f5f7;
  width: 100vw;
  height: 100vh;
}

#container--main {
  height: calc(100% - 56px);
  display: flex;
}

.main--content {
  overflow: hidden;
  padding: 24px;
  box-sizing: border-box;
  width: 100%;
  
  /* background-color: aquamarine; */
}
</style>
