<template lang="">
  <div class="loading--container">
    <div class="loading" @click="loading">
        
    <div class="lds-ring" style="width:40px"><div></div><div></div><div></div><div></div></div>
      <div class="circle circle--1"></div>
      <div class="circle circle--2"></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "loadingVue",
  data() {
    return {
      turn: 30,
    };
  },
  //   beforeUpdate() {
  //     console.log(this.turn);
  //     this.turn += 10;
  //   },
  watch: {
    turn(newValue) {
      console.log(newValue);
    },
  },
  methods: {
    loading: function (show) {
      if (show) {
        document.getElementById("circle").classList.remove("hide");
      } else {
        setTimeout(function () {
          document.getElementById("circle").classList.add("hide");
          setTimeout(function () {
            document.getElementById("circle").classList.add("esconder");
          }, 2000);
        }, 3000);
      }
    },
  },
};
</script>
<style scoped>.lds-ring {
    display: inline-block;
    position: relative;
    width: 80px;
    height: 80px;
  }
  .lds-ring div {
    box-sizing: border-box;
    display: block;
    position: absolute;
    width: 40px;
    height: 40px;
    border: 2px solid #fff;
    border-radius: 50%;
    animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
    border-color: var(--primary--cl-bg) transparent transparent transparent;
  }
  .lds-ring div:nth-child(1) {
    animation-delay: -0.45s;
  }
  .lds-ring div:nth-child(2) {
    animation-delay: -0.3s;
  }
  .lds-ring div:nth-child(3) {
    animation-delay: -0.15s;
  }
  @keyframes lds-ring {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }
  
.loading--container {
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}
.loading {
  position: absolute;
}
</style>
