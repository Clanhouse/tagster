<template>
  <div class="TagsterContainer">
    <GetAndShowTags />
  </div>
</template>

<script>
import GetAndShowTags from "./TagsterContent/GetAndShowTags.vue";

export default {
  name: "Tagster",
  components: {
    GetAndShowTags,
  },
  data: function () {
    return {
      tags: [],
    };
  },

  created() {},
};
</script>

<style>
.TagsterContainer {
  position: relative;
  background-color: white;
  min-height: 2em;
  display: flex;
  padding: 0.5em;
  width: 100%;
}
</style>
