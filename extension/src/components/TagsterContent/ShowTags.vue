<template>
  <div>
    <div class="form-group" v-if="editMode">
      <input type="text" class="form-input" v-model.lazy="tag.tagName" />
    </div>
    <p v-edit @dblclick="editMode = !editMode">{{ tag.tagName }}</p>
    <button @click="deleteTag(tag.id)">
      <binIcon />
    </button>
  </div>
</template>

<script>
import binIcon from "../svg/bin.vue";
export default {
  name: "ShowTags",
  components: { binIcon },
  data: function () {
    return {
      editMode: false,
    };
  },
  methods: {
    deleteTag: function (id) {
      let tags = this.tags;
      console.log(tags);
      tags = tags.filter((tag) => {
        return tag.id !== id;
      });
      console.log(tags);
      this.tags = tags;
    },
    editTag: function (id) {
      console.log(id); //TODO: implements edit
    },
    addTag: function () {},
  },

  created() {
    console.log("i live");
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
