<template lang="">
  <div class="textfield--input">
    <input
      @click="displayTable = true"
      @keyup.down="onArrowDown"
      @keyup.up="onArrowUp"
      @keyup.enter="onEnter"
      type="text"
      v-model="typing"
    />
    <div class="btn--cb" @click="displayTable = !displayTable">
      <icon nameIcon="arrow--down--black"></icon>
    </div>
  </div>
  <div class="cb--list" v-if="displayTable">
    <div class="comboBox--list">
      <div
        @click="change(item)"
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
</template>
<script>
import icon from "./icon.vue";
import { ref } from "vue";
export default {
  props: ["list"],
  components: {
    icon,
  },
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
      if (newValue == this.input.name) {
        this.array = this.list;
      }
      if (newValue !== this.input.name) {
        this.displayTable = true;
        this.array = [];
        this.list.forEach((element) => {
          let str1 = element.name.toUpperCase();
          let str2 = newValue.toUpperCase();
          if (str1.includes(str2)) {
            this.array.push(element);
          }
        });
      }
    },
  },
  methods: {
    change(e) {
      try {
        // if (e.value != this.input.value) {
        this.typing = e.name;
        this.input = { value: e.value, name: e.name };
        this.displayTable = false;
        // }
      } catch (error) {
        console.error(error);
      }
    },
    hovers(e) {
      this.arrowCounter = e;
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
      this.array = this.list;
    },
  },
};
</script>
<style scoped>
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
.cb--list {
  position: relative;
}
.comboBox--list::-webkit-scrollbar {
  width: 7px;
  /* position: absolute; */
}

.comboBox--list::-webkit-scrollbar-thumb {
  background: #9e9e9e;
  border-radius: 7px;
}
.comboBox--list {
  overflow: hidden;
  max-height: 308px;
  overflow-y: auto;
  background-color: white;
  box-shadow: 0 10px 16px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  width: 100%;
  position: absolute;
  top: -10px;
  padding: 8px;
  box-sizing: border-box;
  border-radius: 4px;
}
.btn--cb {
  display: flex;
  padding: 4px;
  align-items: center;
  height: 100%;
  border: 1px solid #e0e0e0;
}
.item--active {
  color: #5dc748;
}
.container-cb {
  width: 100%;
  position: absolute;
  background-color: aliceblue;
}
</style>
