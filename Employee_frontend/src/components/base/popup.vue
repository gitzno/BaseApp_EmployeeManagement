<template lang="">
  <div class="container--popup">
    <form action="" name="add-form" id="add-form">
      <div class="popup">
        <div class="popup--header">
          <div class="popup--header__left">
            <h2>Thông tin khách hàng</h2>
          </div>
          <div
            class="popup--header__right"
            @click="hiddenPopup"
            id="btn--close"
          >
            <icon nameIcon="tick"></icon>
          </div>
        </div>
        <div class="popup--content">
          <textfield
            style="width: 20%"
            label="Mã khách hàng"
          ></textfield>
          <textfield
            style="width: 30%; padding-left: 8px"
            label="Họ và tên"
          ></textfield>
          <textfield
            style="width: 25%; padding-left: 8px"
            label="Ngày sinh"
          ></textfield>
          <textfield
            style="width: 25%; padding-left: 8px"
            label="Giới tính"
            :list="list"
          ></textfield>

          <textfield style="width: 50%" label="Số điện thoại"></textfield>
          <textfield
            style="width: 25%; padding-left: 8px"
            label="Số CCCD"
          ></textfield>
          <textfield
            style="width: 25%; padding-left: 8px"
            label="Ngày Cấp"
          ></textfield>

          <textfield :validate='new RegExp(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$/)' style="width: 50%" label="Email"></textfield>
          <textfield
            style="width: 50%; padding-left: 8px"
            label="Nơi cấp"
          ></textfield>
          <textfield style="width: 30%" label="Số tiền nợ"></textfield>
          <textfield style="width: 100%" label="Công ty"></textfield>
          <textfield style="width: 100%" label="Địa chỉ"></textfield>
        </div>
        <div class="popup--buttonbox">
          <div
            class="button button--secondary"
            @click="hiddenPopup"
            id="btn--close"
          >
            Hủy
          </div>
          <div class="button button--primary" id="form__btn--save">Cắt</div>
        </div>
      </div>
    </form>
  </div>
</template>
<script>
import icon from "./icon.vue";
import textfield from "./textfield.vue";
export default {
  name: "popUp",
  components: {
    icon,
    textfield,
  },
  methods: {
    hiddenPopup() {
      this.$emit("hiddenPopup");
    },
    removePopup() {
      this.$emit("removePopup");
    },
  },
  data() {
    return {
      list: [
        { value: 1, name: "khác" },
        { value: 2, name: "nam" },
        { value: 3, name: "nữ" },
      ],
    };
  },
};
</script>
<style scoped>
.container--popup {
  display: flex;
  align-items: center;
  justify-content: center;
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  background-color: rgba(0, 0, 0, 0.242);
  z-index: 100000;
}
</style>
