<template>
  <div id="container">
     <nav>
       <ul>
         <li>分类</li>
         <li>标签</li>
         <li>归档</li>
         <li>关于</li>
         <li>搜索</li>
       </ul>
     </nav>
  </div>
</template>

<script>
export default {
  name: "home",
  components: {},
  data() {
    return {
      count: 0,
      list: [],
      current: null
    };
  },

  created: function() {
    var that=this;
    console.log('created');
  },

  destroyed:function(){
    var that=this;
    console.log('destroyed');
  },

  methods: {
  }
};
</script>

<style>
</style>