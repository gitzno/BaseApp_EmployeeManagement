<template lang="">
  <div class="table--container table table--border__cell">
    <loadingVue v-if="!isload"></loadingVue>
    <table v-if="isload">
      <thead>
        <tr>
          <th class="cell--text__center">
            <input
              id="input--selectall"
              type="checkbox"
              :checked="this.sellefctallstatussss"
              @click="handleSelectAll"
            />
          </th>
          <!-- <div>{{ createArray() }}</div> -->
          <th v-for="(item, index) in createArray()" :key="index + 1">
            {{ item }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="listTable.length == 0">
          <td colspan="7">
            <div
              class="tr--message"
              style="display: flex; justify-content: center"
            >
              Không có dữ liệu
            </div>
          </td>
        </tr>
        <tr
          v-for="(item, index) in listTable"
          :key="index"
          :class="checkboxstatus ? 'input--checked' : ''"
        >
          <td class="cell--text__center">
            <input
              type="checkbox"
              @change="checkboxChange"
              :checked="checkboxstatus"
            />
          </td>
          <td>{{ item.CustomerCode }}</td>
          <td>{{ item.FullName }}</td>
          <td>{{ item.Gender }}</td>
          <td>{{ item.DateOfBirth }}</td>
          <td>{{ item.CompanyName }}</td>
          <td class="td--text__right">{{ item.DebitAmount }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
import loadingVue from "./loading.vue";

export default {
  beforeCreate() {
    if (this.listTable == null) {
      this.isload = false;
    }
    this.isload = true;
  },
  name: "tableBase",
  props: ["listTable"],
  components: {
    loadingVue,
  },
  data() {
    return {
      isload: false,
      newArr: [],
      sellectallstatus: false,
      checkboxstatus: false,
      sellefctallstatussss: false,
    };
  },
  watch: {
    sellectallstatus(newValue) {
      this.sellefctallstatussss = newValue;
      let res = newValue ? String(this.listTable.length) : "0";
      this.$emit("checkBoxChange", res);
      this.checkboxstatus = newValue;
    },

    listTable(newValue) {
      this.isload = true;
      this.newArr = newValue;
    },
  },

  methods: {
    handleSelectAll(event) {
      let value = event.target.checked;
      let s = document.querySelectorAll("input[type='checkbox']");
      s.forEach(element => {
        element.checked = value;
        this.inputHandle(element)
      });
      this.sellectallstatus = value;
    },
    inputHandle(z) {
      if (z.checked == true) {
        z.parentElement.parentElement.classList.add("input--checked");
      } else {
        z.parentElement.parentElement.classList.remove("input--checked");
      }
    },
    checkboxChange(event) {
      let checkbox = event.target;
      this.inputHandle(checkbox);
      if (
        this.sellefctallstatussss === true &&
        event.target.checked === false
      ) {
        this.sellefctallstatussss = false;
      }
      let res = event.target.checked;
      if (res === false) {
        this.sellectAll = false;
      }
      this.$emit("checkBoxChange", res ? 1 : -1);
    },
    createArray() {
      try {
        let arr = Object.keys(this.newArr[0]);
        arr.shift();
        return arr;
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>
<style scoped>
/* .table--container {
  /* background-color: mediumslateblue; */
/* } */
</style>
