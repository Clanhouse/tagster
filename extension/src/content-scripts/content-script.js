import Vue from "vue";
import Tagster from "../components/Tagster.vue";

const main = document.querySelector("#main");
const node = document.createElement("TagsterContainer");

node.classList.add("TagsterContainer");
main.insertBefore(node, main.firstChild);

const app = new Vue({
  components: { Tagster },
  template: "<Tagster/>",
});

app.$mount("TagsterContainer");
