<template>
  <button @click="$emit('click', $event)">{{ text }}</button>
</template>

<script>
export default {
  name: 'BaseButton',
  props: {
    text: String
  }
}
</script>

<style scoped>
button {
  box-sizing: border-box;
  display: block;
  background-color: var(--button-color);
  color: #fff;
  border: none;
  border-radius: 10rem;
  padding: .6rem 3rem;
  font-size: 1rem;
  outline: none;
}

button.primary {
  background-color: var(--button-primary);
}

button:focus {
  background-color: var(--button-focus);
}

button:hover {
  background-color: var(--button-hover);
}

button[disabled] {
  background-color: var(--button-disable);
}
</style>