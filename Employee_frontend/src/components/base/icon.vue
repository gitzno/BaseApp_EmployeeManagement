<template>
    <div class="icon--container">
        <div class="icon" :style="styleObject"></div>
    </div>
</template>

<script>

    
export default {
    name: 'iconDiv',
    props: ['nameIcon'],
    data() {
        return {
            iconList: [
                { iconName: 'excel', iconPosition: '-705px -258px', iconWidth: 23, iconHight: 20 },
                { iconName: 'setting', iconPosition: '-144px -88px', iconWidth: 24, iconHight: 24 },
                { iconName: 'warning', iconPosition: '-593px -145px', iconWidth: 22, iconHight: 23},
                { iconName: 'tick', iconPosition: '-1225px -363px', iconWidth: 14, iconHight: 11},
                { iconName: 'search--black', iconPosition: '-1041px -89px', iconWidth: 22, iconHight: 22},
                { iconName: 'close--gray', iconPosition: '-83px -316px', iconWidth: 9, iconHight: 8},
                { iconName: 'close--black', iconPosition: '-1758px -476px', iconWidth: 8, iconHight: 8},
                { iconName: 'arrow--down--black', iconPosition: '-1129px -365px', iconWidth: 14, iconHight: 8},
                { iconName: 'candy--box--black', iconPosition: '-1157px -32px', iconWidth: 16, iconHight: 16},
                { iconName: 'homePage--white', iconPosition: '-294px -1589px', iconWidth: 18, iconHight: 17},
                { iconName: 'report--white', iconPosition: '-251px -1667px', iconWidth: 17, iconHight: 14},
                { iconName: 'customer--white', iconPosition: '-165px -1664px', iconWidth: 17, iconHight: 17},
                { iconName: 'arrow--white', iconPosition: '-36px -409px', iconWidth: 8, iconHight: 14},
                
            ],
        }
    },
    computed: {
        styleObject() {
            try {
                
                let elementchosse = {};
                const props = this.nameIcon;
                this.iconList.forEach(element => {
                    if (props === element.iconName) {
                        // console.log(props);
                        elementchosse = element;
                        return element;
                    }
                });
                return {
                    backgroundPosition: `${elementchosse.iconPosition}`,
                    width: `${elementchosse.iconWidth}px`,
                    height: `${elementchosse.iconHight}px`,
                    scale: `calc(20 / ${elementchosse.iconWidth > elementchosse.iconHight ? elementchosse.iconWidth : elementchosse.iconHight})`
                };
            } catch (error) {
                console.error("icon không hợp lệ!");
                return {};
            }
        }
    }
}
</script>
  
<style scoped>
.icon {
    padding: 2px;
    box-sizing: border-box;
    background: url('../../assets/icon/icon.svg') no-repeat;
}

.icon--container {
    width: 24px;
    height: 24px;
    padding: 2px;
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>
  