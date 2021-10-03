<template>
  <div>
    <div class="form-group" v-if="editMode">
      <input
        @keyup.enter="acceptChanges"
        @dblclick="acceptChanges"
        type="text"
        v-autowidth="{ maxWidth: '960px', minWidth: '20px', comfortZone: 0 }"
        v-model="tag.tagName"
        v-focus
      />
    </div>
    <p v-else @dblclick="editTag">{{ tag.tagName }}</p>
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
  props: ["tag"],

  methods: {
    deleteTag: function (id) {
      console.log(id);
      this.$emit("delete-tag", id);
    },
    editTag: function (id) {
      console.log(id); //TODO: implements edit
      this.editMode = true;
    },
    acceptChanges: function () {
      this.editMode = false;
    },
  },
};
</script>

<style scoped>
button {
  margin-left: 0.5em;
  display: inline-flex;
  justify-content: center;
  align-items: center;
}

.good {
  background-color: green;
}
.bad {
  background-color: red;
}
</style>
