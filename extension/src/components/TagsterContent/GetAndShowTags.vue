<template>
  <div>
    <ul>
      <li class="TagsterTag" v-for="(tag, index) in tags" :key="index">
        {{ tag.tagName }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "GetAndShowTags",
  data: function () {
    return {
      tags: [],
    };
  },
  methods: {
    getTagsFromApi: async function () {
      let vm = this;
      await chrome.runtime.sendMessage(
        { type: "GET_DATA", link: "hello" },
        function (response) {
          vm.tags = response.data[0];
        }
      );
    },
  },
  created() {
    this.getTagsFromApi();
  },
};
</script>

<style scoped>
.TagsterContainer {
  background-color: white;
  min-height: 2em;
  display: flex;
  padding: 0.5em;
  width: 100%;
}
.TagsterTag {
  background-color: grey;
  color: white;
  border-radius: 0.2em;
  display: inline-block;
  margin: 0.5em;
  padding: 0.5em;
}

.good {
  background-color: green;
}
.bad {
  background-color: red;
}
</style>
