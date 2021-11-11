import Vue from "vue";
import Tagster from "../components/Tagster.vue";
import VueInputAutowidth from "vue-input-autowidth";

const main = document.querySelector("#main");
const node = document.createElement("TagsterContainer");

node.classList.add("TagsterContainer");
main.insertBefore(node, main.firstChild);

Vue.use(VueInputAutowidth); // auto input width

Vue.directive("focus", {
  //directive for v-focus
  inserted: function (el) {
    el.focus();
  },
});

const app = new Vue({
  components: { Tagster },
  template: "<Tagster/>",
});

app.$mount("TagsterContainer");
