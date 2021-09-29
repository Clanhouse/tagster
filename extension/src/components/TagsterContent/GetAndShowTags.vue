<template>
  <div>
    <ul>
      <li class="TagsterTag" v-for="(tag, index) in tags" :key="index">
        <p @dblclick="editTag($event)">{{ tag.tagName }}</p>
        <button @click="deleteTag($event)">
          <binIcon />
        </button>
      </li>
      <li class="TagsterTag addTag" @click="addTag()">
        <p>Click to add more tags</p>
      </li>
    </ul>
  </div>
</template>

<script>
import binIcon from "../svg/bin.vue";
export default {
  name: "GetAndShowTags",
  components: {
    binIcon,
  },
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
    deleteTag: function (event) {
      console.log(event); //TODO: implements delete
    },
    editTag: function (event) {
      console.log(event); //TODO: implements edit
    },
    addTag: function () {},
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
  background-color: #c4c4c4;
  color: black;
  border-radius: 10px;
  display: inline-flex;
  margin: 0.5em;
  padding: 0.5em;
}

.TagsterTag p {
  cursor: pointer;
}

button {
  margin-left: 0.5em;
  display: inline-flex;
  justify-content: center;
  align-items: center;
}

.addTag {
  background-color: #32a852;
  color: white;
  cursor: pointer;
}
.addTag p {
  font-weight: 500;
}

.good {
  background-color: green;
}
.bad {
  background-color: red;
}
</style>
