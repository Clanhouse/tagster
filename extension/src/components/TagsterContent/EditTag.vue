<template>
  <div class="popup">
    <input type="text" v-model="TagValue" />
    <button>Deny</button>
    <button>Accept</button>
  </div>
</template>

<script>
export default {
  name: "EditTag",
  data: function () {
    return {
      TagValue: "",
    };
  },
  methods: {
    acceptEdit: function () {},
  },
};
</script>

<style scoped></style>
