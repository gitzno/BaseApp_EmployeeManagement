<template lang="">
  <div class="bg-comboBox">
    <div class="combobox" :class="(this.array.length == 0 )|| (msgError != null)? 'combobox--error':''">
      <div class="label--combobox">
        <input
          @click="displayTable = true"
          @keyup.down="onArrowDown"
          @keyup.up="onArrowUp"
          @keyup.enter="onEnter"
          v-model="typing"
          class="label--input"
          placeholder="Typehere"
          type="text"
        />
        <div class="label--button" @click="displayTable = !displayTable">
          <icon nameIcon="arrow--down--black"></icon>
        </div>
      </div>
    </div>
    <div class="bg--list" v-if="displayTable">
      <div class="comboBox--list">
        <div
          @mouseover="hovers(i)"
          @click="
            change(item);
            displayTable = false;
          "
          class="comboBox--list--item"
          v-for="(item, i) in array"
          :key="i"
          :class="
            (item.value == input.value ? 'item--active' : '') +
            (i == arrowCounter ? 'item--hover' : '')
          "
        >
          <div class="item--name">{{ item.name }}</div>
          <icon
            v-if="item.value == input.value"
            class="icon--item"
            nameIcon="tick"
          ></icon>
        </div>
      </div>
    </div>
    <div class="label--error" v-if="msgError != null">
      {{ msgError }}
    </div>
  </div>
</template>
<script>
import icon from "./icon.vue";
import { ref } from "vue";
export default {
  name: "comboBox",
  data() {
    return {
      // khai báo ref với giá trị là prop list
      //array riêng
      array: ref(this.list),
      //lưu kết quả
      input: ref({}),
      //nội dung gõ
      typing: "",
      //
      arrowCounter: -1,
      // chế độ hiển thị
      displayTable: false,
    };
  },
  watch: {
    typing(newValue) {
      console.log(this.array.length);
      if (newValue !== this.input.name) {
        this.displayTable = true;
      }
      this.array = [];
      this.list.forEach((element) => {
        let str1 = element.name.toUpperCase();
        let str2 = newValue.toUpperCase();
        if (str1.includes(str2)) {
          this.array.push(element);
        }
      });
    },
  },
  methods: {
    hovers(e) {
      this.arrowCounter = e;
    },
    change(e) {
      try {
        if (e.value != this.input.value) {
          this.typing = e.name;
          this.input = { value: e.value, name: e.name };
          this.displayTable = false;
        }
      } catch (error) {
        console.error(error);
      }
    },
    onArrowDown() {
      this.arrowCounter = (this.arrowCounter + 1) % this.array.length;
    },
    onArrowUp() {
      this.arrowCounter =
        this.arrowCounter == 0 ? this.array.length - 1 : this.arrowCounter - 1;
    },
    onEnter() {
      this.change(this.array[this.arrowCounter]);
      this.displayTable = false;
    },
    handleClickOutside(evt) {
      if (!this.$el.contains(evt.target)) {
        this.displayTable = false;
        this.arrowCounter = -1;
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.handleClickOutside);
  },
  unmounted() {
    document.removeEventListener("click", this.handleClickOutside);
  },
  props: ["msgError", "list"],
  components: {
    icon,
  },
};
</script>
<style>

.bg--list {
  position: relative;
}

.label--combobox {
  height: 38px;
  cursor: pointer;
  margin: 8px 0;
  display: flex;
  border-radius: 4px;
}

.label--combobox:hover > .label--input,
.label--combobox:hover > .label--button {
  background-color: #f6f6f6;
}

.comboBox--list::-webkit-scrollbar {
  width: 7px;
  /* position: absolute; */
}

.comboBox--list::-webkit-scrollbar-thumb {
  background: #9e9e9e;
  border-radius: 7px;
}

.comboBox--list--item:hover,
.item--hover {
  background-color: rgba(80, 184, 60, 0.1);
}

.comboBox--list--item {
  height: 36px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 8px;
  box-sizing: border-box;
}

.comboBox--list {
  overflow: hidden;
  max-height: 40px;
  background-color: white;
  box-shadow: 0 10px 16px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  width: 100%;
  position: absolute; 
  padding: 8px;
  box-sizing: border-box;
  border-radius: 4px;
}

.label--input {
  width: 100%;
  border: solid #e6e6e6 1px;
  border-right: none;
  padding: 12px;
  border-radius: 4px 0 0 4px;
  border-right: 2px;
}

.label--input:focus {
  outline: none;
  border: 1px #5dc748 solid;
  border-right: none;
}

.label--input:focus ~ .label--button {
  border: 1px #5dc748 solid;
  border-left: 1px #e6e6e6 solid;
}

.item--active {
  color: #5dc748;
}
.label--error{
  color: red;
}
.label--button {
  background-color: white;
  border: solid #e6e6e6 1px;
  padding: 8px;

  border-left: 1px #e6e6e6 solid;
  border-radius: 0 4px 4px 0;
}
.combobox--error input {
  border-bottom-color: red !important; 
  border-left-color: red !important;
  border-top-color: red !important;
}
.combobox--error .label--button {
  border-bottom-color: red !important;
  border-top-color: red !important;
  border-right-color: red !important;
}
</style>
