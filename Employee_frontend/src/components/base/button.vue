<template>


<div class="button primary-btn">
    <div class="content-button">
        
    </div>
</div>
<div class="button secondary-btn">
    <div class="content-button">

    </div>
</div>
<div class="button link-btn">
    <div class="content-button">

    </div>
</div>
<div class="button icon-btn">
    <div class="content-button">

    </div>
</div>


    <div class="button--bg">
        <div class="button" :class="type">
            <iconDiv id="button__icon" :nameIcon="icon"></iconDiv>
            <div class="text">Cái nút</div>
        </div>
        <div class="button button--combo__ar" v-if="type === 'button--combo'">
            <iconDiv id="button__icon" :nameIcon="icon"></iconDiv>
        </div>
    </div>


nút 3 loai

</template>
  
<script>
import iconDiv from './icon.vue';
export default {
    name: 'ButtonBase',
    props: ['text', 'type', 'icon'],
    components: {
        iconDiv,
    }
}
</script>
  
<style></style>
  