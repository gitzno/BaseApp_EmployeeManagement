<template>
  <div class="custommer--container">
    <toastmessage
      v-if="uncheck"
      text="Bỏ chọn thành công"
      type="0"
      @closeBtn="uncheck = false"
    ></toastmessage>
    <Dialog
      v-if="openbtnDialog"
      @closeBtn="openbtnDialog = false"
      :info="dialogVar"
    ></Dialog>
    <popup
      @removePopup="popupStatus"
      v-if="popupStatus"
      @hiddenPopup="popupDisplay = false"
      v-show="popupDisplay"
    ></popup>
    <div class="customer--header">
      <div class="header--name text--h1">Quản lý khách hàng</div>
      <ButtonBase
        @click="
          popupDisplay = true;
          popupStatus = true;
        "
        text="Thêm mới"
        icon="tick"
      ></ButtonBase>
    </div>
    <div class="customer--table">
      <div class="table--function">
        <div class="left--content">
          <div class="count--picked" style="margin: 10px">
            Đã chọn: <span>{{ countSelected }}</span>
          </div>
          <ButtonBase
            @click="unselectAll"
            type="button--link"
            style="margin: 10px; color: red"
            text="Bỏ chọn"
          ></ButtonBase>
          <ButtonBase
            @click="deleteall"
            icon="tick"
            style="margin: 10px"
            text="Xoá tất cả"
          ></ButtonBase>
        </div>
        <div class="right--content">
          <ButtonBase
            type="button--icon"
            style="margin: 10px"
            icon="excel"
          ></ButtonBase>
          <ButtonBase
            type="button--icon"
            style="margin: 10px"
            icon="excel"
          ></ButtonBase>
        </div>
      </div>
      <div class="table">
        <!-- <div @click="console.log(this.customAPI())">here</div> -->
        <tableBase
          :listTable="this.customAPI()"
          @checkBoxChange="handleCountChecked"
        ></tableBase>
      </div>
      <div class="table--controller">
        <div class="left--content">
          <div class="count--record">
            Tổng: <span>{{ listCustomers.length }}</span>
          </div>
        </div>
        <div class="right--content">
          <div class="record--page" style="margin: 10px">
            Số bản ghi/trang: 10
          </div>
          <div class="button--page">HeheS</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import ButtonBase from "../base/button.vue";
import tableBase from "../base/table.vue";
import popup from "../base/popup.vue";
import Dialog from "../base/dialog.vue";
import toastmessage from "../base/toastmessage.vue";

export default {
  components: {
    Dialog,
    toastmessage,
    ButtonBase,
    tableBase,
    popup,
  },
  data() {
    return {
      dialogVar: {
        header: "xoá tất cả?",
        iconName: "tick",
        descrition: "Bạn có chắc muốn xoá tất cả không?",
      },
      isload: false,
      openbtnDialog: false,
      popupStatus: false,
      popupDisplay: false,
      listCustomers: [],
      countSelected: 0,
      uncheck: false,
    };
  },
  created() {
    this.fetchAPI();
  },

  methods: {
    inputHandle(z) {
      if (z.checked == true) {
        z.parentElement.parentElement.classList.add("input--checked");
      } else {
        z.parentElement.parentElement.classList.remove("input--checked");
      }
    },
    unselectAll() {
      const checkboxs = document.querySelectorAll("th>input, td>input");
      // checkboxs.checked = false;
      checkboxs.forEach((element) => {
        element.checked = false;
        this.inputHandle(element);
      });
      this.countSelected = 0;
    },
    async fetchAPI() {
      try {
        fetch("https://localhost:7119/api/v1/Employee")
          .then((res) => res.json())
          .then((data) => {
            this.listCustomers = data;
          });
      } catch (error) {
        console.error(error);
      }
    },

    deleteall() {
      this.openbtnDialog = true;
    },
    /**
     * Format date with dd/MM/yyyy
     * @Author: gitzno
     * @Date: 28/11/2023
     */
    formatDate(DATE) {
      try {
        //create new date with string
        let date = new Date(DATE);
        //format date
        let day = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
        //format month
        let month = date.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        // lấy năm
        let year = date.getFullYear();
        return `${day}-${month}-${year}`;
      } catch (error) {
        console.error(`API datetime error`);
      }
    },
    customAPI() {
      let list = [];
      this.listCustomers.forEach((element) => {
        let {
          CustomerId,
          CustomerCode,
          FullName,
          Gender,
          DateOfBirth,
          CompanyName,
          DebitAmount,
        } = element;
        let e = {
          CustomerId,
          CustomerCode,
          FullName,
          Gender,
          DateOfBirth,
          CompanyName,
          DebitAmount,
        };
        e.Gender = e.Gender == 0 ? "Khác" : e.Gender == 1 ? "Nữ" : "Nam";
        e.DateOfBirth = this.formatDate(e.DateOfBirth);

        e.DebitAmount = new Intl.NumberFormat("vi-VN", {
          style: "currency",
          currency: "VND",
        }).format(e.DebitAmount);

        list.push(e);
      });
      return list;
    },
    handleCountChecked(value) {
      let z = typeof value;
      if (z === "string") {
        this.countSelected = Number(value);
      } else {
        this.countSelected += Number(value);
      }
    },
  },
};
</script>
<style scoped>
.table {
  width: 100%;
  height: 666px;
}

.table--controller,
.table--function {
  /* background-color: antiquewhite; */
  height: 50px;
  display: flex;
  width: 100%;
  justify-content: space-between;
  align-items: center;
}
.left--content,
.right--content {
  margin: 10px;
  display: flex;
  align-items: center;
}

.customer--header {
  width: 100%;
  /* background-color: aqua; */
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 24px;
}
.customer--table {
  height: 766px;
  width: 100%;
  background: white;
  border-radius: 4px;
}
</style>
