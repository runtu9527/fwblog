import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import $ from 'jquery'
import moment from 'moment'

import api from "./api/http.js"
//将API方法绑定到全局
Vue.prototype.$api=api

// 定义全局时间戳过滤器
Vue.filter('formatDate', function(value, pattern = 'YYYY-MM-DD HH:mm:ss') {
  return moment(value).format(pattern)
});


Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
