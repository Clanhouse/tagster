<template>
  <div class="TagsterTagsMenu">
    <button>edit</button>
    <button>delete</button>
  </div>
</template>

<script>
export default {
  name: "TagsterTagsMenu",
  data: function () {
    return {
      tags: [],
    };
  },
  methods: {},
};
</script>

<style scoped>
.TagsterTagsMenu {
  position: absolute;
  display: flex;
  flex-direction: column;
  right: 0;
}
button {
  padding: 0.5em;
  background-color: grey;
  color: white;
  border: 1px solid black;
}
</style>
