<template lang="">
  <div
    id="slidebar--container"
    :style="less == false ? 'width: 70px !important;' : ''"
  >
    <div class="slidebar--list">
      <!-- item slidebar -->
      <router-link to="/" class="slidebar--item">
        <div class="item--icon">
          <icon nameIcon="homePage--white"></icon>
        </div>
        <div class="text--body item--name" v-if="less">Trang chủ</div>
      </router-link>
      <!-- item slidebar -->
      <router-link to="/report" class="slidebar--item">
        <div class="item--icon">
          <icon nameIcon="report--white"></icon>
        </div>
        <div class="text--body item--name" v-if="less">Báo cáo</div>
      </router-link>
      <!-- item slidebar -->
      <router-link to="/customer" class="slidebar--item">
        <div class="item--icon">
          <icon nameIcon="customer--white"></icon>
        </div>
        <div class="text--body item--name" v-if="less">Khách hàng</div>
      </router-link>
      <!-- item slidebar -->
      <router-link to="/setting" class="slidebar--item">
        <div class="item--icon">
          <icon nameIcon="setting"></icon>
        </div>
        <div class="text--body item--name" v-if="less">Cài đặt</div>
      </router-link>
    </div>
    <div class="slidebar--button--less">
      <div class="slidebar--item" @click="less = !less">
        <div class="item--icon">
          <icon nameIcon="arrow--white"></icon>
        </div>
        <div class="text--body item--name" v-if="less">Thu gọn</div>
      </div>
    </div>
  </div>
</template>
<script>
import icon from "../base/icon.vue";
export default {
  name: "slideBar",
  components: {
    icon,
  },
  created() {},
  data() {
    return {
      less: true,
    };
  },
  methods: {},
};
</script>
<style>
.slidebar--item.router-link-exact-active {
  background-color: rgba(37, 150, 190, 0.16);
}
#slidebar--container {
  background-color: #041434;
  width: 200px;
  height: 100%;
  padding: 12px 0 0 0;
  display: flex;
  flex-direction: column;
  text-align: center;
  justify-content: space-between;
  box-sizing: border-box;
  /* transition-delay: 0.3s;  */
  transition-duration: 0.5s; 
  transition-property: width;
}
.slidebar--item {
  text-decoration: none;
  cursor: pointer;
  display: flex;
  text-align: center;
  color: white;
  margin: 4px 12px;
  height: 44px;
  border-radius: 4px;
}

.slidebar--item__active {
  background-color: rgba(37, 150, 190, 0.16);
}

.slidebar--item:hover {
  background-color: rgba(37, 150, 190, 0.16);
}
.item--icon {
  margin: 0 12px;
  display: flex;
  height: 100%;
  align-items: center;
}

.item--name {
  display: flex;
  height: 100%;
  align-items: center;
}
.slidebar--button--less {
  border-top: 1px solid #213553;
}
</style>
