<template>
  <div id="container">
    <div class="device">
      <ul>
        <li
          v-for="(item, index) in list"
          :key="index"
          :class="{active:item==current}"
          @click="onClick(item)"
        >{{item.name}}</li>
      </ul>
    </div>
    <div class="blogs">
      <table
        cellspacing="0"
        cellpadding="0"
        v-if="current && current.Blogs"
      >
        <thead>
          <tr>
            <th>Id</th>
            <th>标题</th>
            <th>操作</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in current.blogs" :key="index">
            <td>{{item.id?item.id:""}}</td>
            <td>{{item.title?item.title:""}}</td>
            <td>
              <div>
                <router-link :to="{name:'toiletinfo',query:{id:item.id}}">xxx</router-link>
                <!-- <a href="#" @click="ontoiletInfoClick(item)"
                >查看详情</a> -->
                <a href="#">修改</a>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>


<script>
var refreshTimeSpan = 10 * 1000;
export default {
  name: "home",
  components: {},
  data() {
    return {
      refreshTimer:true,
      count: 0,
      list: [],
      current: null
    };
  },

  // mounted: function () {
  //   this.startRefresh()
  // },

  created: function() {
    var that=this;
    console.log('created');
    that.refreshTimer=true;
    that.startRefresh();
  },

  destroyed:function(){
    var that=this;
    console.log('destroyed');
    that.refreshTimer=false;
  },

  methods: {
    ontoiletInfoClick: function(item) {
      if (!item) {
        return;
      }

    },

    onClick: function(item) {
      if (!item) {
        return;
      }

      if (item == this.current) {
        return;
      }

      this.current = item;
    },
    getToilets: function(cb) {
      var that = this;
      that.$api.get('Blog/byPage?page=1', {}, function(err, data) {
        cb(err, data);
      });
    },
    startRefresh: function() {
      var that = this;
      that.doRefresh(function() {
        if(that.refreshTimer){
 that.timer = setTimeout(function() {
          that.startRefresh();
        }, refreshTimeSpan);
        }
       
      });
    },
    doRefresh: function(cb) {
      var that = this;
      that.getToilets(function(err, data) {
        // console.log(err);
        // console.log(data);
        that.count++;
        that.list = data || [];
        if (that.current) {
          var item = that.list.find(function(p) {
            return p.id == that.current.id;
          });
          if (item) {
            that.current = item;
          } else {
            that.current = null;
          }
        }
        cb && cb();
      });
    }
  }
};
</script>

<style>

#container {
  width: 100%;
  height: 100%;
  background-color: black
}
.device {
  width: 200px;
  height: 100%;
  left: 0;
  top: 0;
  /* border-right: 2px solid gray; */
  overflow-x: hidden;
  overflow-y: auto;
}

.device ul {
  position: relative;
  width: 100%;
  height: auto;
  padding: 0;
  margin: 0;
}

.device ul li {
  position: relative;
  height: 50px;
  border-bottom: 1px solid lightgray;
  line-height: 50px;
  text-indent: 15px;
  cursor: pointer;
}

.device ul li.active {
  background-color: #6693b2;
  color: white;
}
.device ul li:hover {
  background-color: #6693b2;
  opacity: 0.5;
  color: white;
}

.blogs {
  position: absolute;
  left: 200px;
  height: 100%;
  top: 0;
  right: 0;
  bottom: 0;
  border-left: 2px solid gray;
  overflow-x: hidden;
  overflow-y: auto;
}

.blogs table {
  position: relative;
  width: 100%;
  height: auto;
  border: none;
}

.blogs table thead tr th {
  font-weight: normal;
  background-color: #6693b2;
  color: white;
}

.blogs table thead tr th,
.blogs table tbody tr td {
  width: 10%;
  height: 50px;
  text-align: center;
  border: 1px solid lightgray;
}
</style>