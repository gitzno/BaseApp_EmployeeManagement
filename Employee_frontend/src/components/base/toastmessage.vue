<!-- 
 <toastMessage v-if="openbtn" @closeBtn="openbtn = false" action="Hoàn tác" type='0'
text="Không thể cập nhật dữ liệu, vui lòng kiểm tra lại kết nối internet"></toastMessage>
data() {
    return {
      openbtn: true,
    };
  }
  @author: gitzno
  @date: 06/12/2023
-->
<template>
    <div class="container--toastmessage">
        <div class="toastmessage--title">
            <icon class="icon" nameIcon="tick"></icon>
            <div class="title text--body" :style="titleList[type].style">{{ titleList[type].content }}</div>
            <div class="content">{{ text }}</div>
        </div>
        <div class="toastmessage--action">
            <div class="action--button" @click="callback" v-if="action != null">{{ action }}</div>
            <div class="close--button" @click="closeBtn">
                <icon class="icon" nameIcon="close--black"></icon>
            </div>
        </div>
    </div>
</template>
<script>
import icon from "./icon.vue";
export default {
    name: 'toastMessage',
    props: ['text', 'action', 'type'],
    components: {
        icon,
    },
    methods: {
        callback: function () {
            this.$emit('event');
            alert('hehe');
        },
        closeBtn() {
            this.$emit('closeBtn');
        }
    },
    data() {

        return {
            titleList: [
                { icon: "tick", content: "Thành Công!", style: "color: green" },
                { icon: "tick", content: "Lỗi!    ", style: "color: red" },
                { icon: "tick", content: "Cảnh báo!", style: "color: orange" },
                { icon: "tick", content: "Thông tin!", style: "color: blue" },
            ],
        }
    },
}
</script>
<style lang="">
    
</style>