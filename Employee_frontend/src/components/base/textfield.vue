<template>
  <div class="bg--textfield">
    <div class="text--body" v-if="label != null">
      {{ label }} <span style="color: red;" v-if="validate != null">*</span>
    </div>
    <combobox :list="list" v-if="list != null"></combobox>
    <div class="textfield--input" :class="classBind" v-if="list == null">
      <input
        type="text"
        :placeholder="placeholder"
        :readonly="readonly"
        v-model="typing"
      />
      <div
        @click="callback"
        class="textfield--button"
        v-if="icon != null"
      >
        <iconDiv :nameIcon="classBindIcon"></iconDiv>
      </div>
    </div>
    <div class="textfield--error" v-if="msgError != null">
      {{ msgError }}
    </div>
  </div>
</template>
<script>
import iconDiv from "./icon.vue";
import combobox from "./newComboBox.vue";
export default {
  name: "textFeild",
  props: [
    "validate",
    "value",
    "label",
    "placeholder",
    "icon",
    "error",
    "readonly",
    "list",
  ],
  data() {
    return {
      typing: "",
      msgError: this.error,
      emailRegex: new RegExp(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$/),
    };
  },
  components: { combobox, iconDiv },
  methods: {
    callback() {
      this.$emit("event");
    },
  },
  watch: {
    typing(newValue) {
      if (newValue === "") {
        this.msgError = `Trường '${this.label}' không được để trống`;
      } else if (newValue.match(this.validate) == null) {
        this.msgError = `Trường '${this.label}' không xác thực`;
      }
      else{
        this.msgError = "";
      }
    },
  },
  computed: {
    classBind() {
      let res = this.readonly != null ? "textfield--readonly" : "";

      return `${res} ${this.error != null ? "textfield--error" : ""}`;
    },
    classBindIcon() {
      if (this.validate != null) return "tick";
      return this.icon;
    },
  },
};
</script>
<style lang=""></style>
