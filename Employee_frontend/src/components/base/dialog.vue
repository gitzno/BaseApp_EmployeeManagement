<template>
  <div class="bg--dialog" id="bg--sth">
    <div class="dialog">
      <div class="dialog--header">{{info.header}}</div>
      <div class="dialog--description">
        <div class="dialog--icon">
          <icon :nameIcon="this.info.iconName"></icon>
        </div>
        <div class="dialog--message">
          {{info.descrition}}
        </div>
      </div>
      <div class="dialog--button">
        <div class="button button--secondary" @click="closeBtn" id="btn--close">Hủy</div>
        <div class="button button--primary" @click="closeBtn">Đồng Ý</div>
      </div>
    </div>
  </div>
</template>
<script>
import icon from "./icon.vue";
export default {
  name: "diaLog",
  props: ["info"],
  components: {
    icon,
  },
  methods: {
    callback: function () {
      this.$emit("event");
    },
    closeBtn() {
      this.$emit("closeBtn");
    },
  },
  data() {
    return {
      titleList: [
        { icon: "tick", content: "Thành Công!", style: "color: green" },
        { icon: "tick", content: "Lỗi!    ", style: "color: red" },
        { icon: "tick", content: "Cảnh báo!", style: "color: orange" },
        { icon: "tick", content: "Thông tin!", style: "color: blue" },
      ],
    };
  },
};
</script>
<style lang=""></style>
