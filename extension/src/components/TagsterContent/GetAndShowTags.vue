<template>
  <div>
    <TagsterLogo />
    <ul>
      <li
        class="TagsterTag"
        is="ShowTags"
        v-for="(tag, index) in tags"
        :key="index"
        :tag="tag"
        @delete-tag="deleteTag"
      >
        <ShowTags />
      </li>
      <li class="TagsterTag addTag">
        <p v-if="!addNewTagMode" @click="addNewTagMode = !addNewTagMode">
          Click to add more tags
        </p>
        <input
          v-else
          @keyup.enter="addNewTag"
          @dblclick="addNewTag"
          type="text"
          v-autowidth="{ maxWidth: '960px', minWidth: '20px', comfortZone: 0 }"
          v-model="newTag"
          v-focus
        />
      </li>
    </ul>
  </div>
</template>

<script>
import ShowTags from "./ShowTags.vue";
import TagsterLogo from "./TagsterLogo.vue";
export default {
  name: "GetAndShowTags",
  components: {
    ShowTags,
    TagsterLogo,
  },
  data: function () {
    return {
      tags: [],
      newTag: "",
      addNewTagMode: false,
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
    deleteTag: function (id) {
      let tags = this.tags;
      tags = tags.filter((tag) => {
        return tag.id !== id;
      });
      this.tags = tags;
    },
    addNewTag: function () {
      this.addNewTagMode = false;
      this.tags.push({ id: 8, profileId: 8, tagName: this.newTag });
      //TODO: implements Add
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
.addTag {
  background-color: #32a852;
  color: white;
  cursor: pointer;
}
.addTag p {
  font-weight: 500;
}
</style>
