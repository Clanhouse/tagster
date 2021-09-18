<template>
  <div>
    <h2>Tagster is working!!</h2>
    <a
      target="_blank"
      href="https://linkedin.com"
      id="checkPage"
      class="button button2"
      >Go and tag some people</a
    >
    <a id="searchNames" class="button button3" @click="consoleLog"
      >Search people</a
    >
  </div>
</template>

<script>
export default {
  name: "Popup",
  methods: {
    consoleLog: function () {
      browser.runtime.sendMessage("hi");
    },
  },
  mounted() {
    browser.runtime.sendMessage({});
  },
};
</script>

<style scoped>
.button {
  background-color: #4caf50;
  border: none;
  color: black;
  padding: 5px 14px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  transition-duration: 0.4s;
  cursor: pointer;
}
.button2 {
  background-color: white;
  color: black;
  border: 2px solid #008cba;
}
.button2:hover {
  background-color: #008cba;
  color: white;
}
.button3 {
  background-color: white;
  color: black;
  border: 2px solid #c22b05;
}
.button3:hover {
  background-color: #c22b05;
  color: white;
}
</style>
