<template>
<!-- Make a div wrapped slider,set height and width -->
 <div style="width:100%;margin:20px auto;">
   <img src="" alt="">
      <!-- Using the slider component -->
      <slider ref="slider" :options="options">
          <!-- slideritem wrapped package with the components you need -->
          <slideritem v-for="(item,index) in itemsforslider" :key="index" :style="item.style" v-html="item.html"></slideritem>
          <!-- Customizable loading -->
          <div slot="loading">loading...</div>
      </slider>
 </div>
</template>
<script>
// import slider components
import { slider, slideritem } from 'vue-concise-slider'
export default {
   name: "slidervue",
   data () {
      return {
        //data list [array]
        someList:[
          {
            html: '<div style:"height:50vh; width:50vw;" class:"sliderItem"><div/>',
                    style: {
                        'background-image': 'url(../assets/images/img1.jpg)',
                    }
          },
          {
            html: '',
            style: {
              'background': '#4bbfc3'
            }
          },
          {
            html: '',
            style: {
              'background': '#7baabe'
            }
          }
        ],
        //Slider configuration [obj]
        options: {
          loop: true,
          pagination: false
        },
        
      }
    },
    components: {
      slider,
      slideritem
    },
    props:{
        itemsforslider: {
        type: Array,
        required: true
      },
    }
}
</script>