<template>
  <div class="input-container" :class="{error: errorMessage}">
    <input
        type="text"
        :value="value"
        @input="$emit('input', $event.target.value)"
        @keyup="$emit('keyup')"
        @blur="$emit('blur')"
        required>
    <div class="highlight"></div>
    <div class="error-msg" v-if="errorMessage">{{ errorMessage }}</div>
    <label :for="id">{{ label }}</label>
  </div>
</template>

<script>
export default {
  name: 'BaseInputText',
  props: {
    id: String,
    value: String,
    label: String,
    errorMessage: String
  }
}
</script>

<style scoped>
.input-container {
  position: relative;
  padding-bottom: .9rem;
  font-family: sans-serif;
  font-weight: 400;
}

.input-container > input {
  border: none;
  border-bottom: 1px solid var(--input-main-color);
  width: 100%;
  height: calc(2.4rem - 1px); /* input{ font-size + paddingY - borderY } */
  padding: 1.2rem .2rem .2rem;
  font-size: 1rem;
  outline: none;
  transition: .2s ease-in-out;
}

.input-container > .highlight {
  position: absolute;
  height: 2px;
  width: 0;
  bottom: .9rem;
  transition: .2s ease-in-out;
}

.input-container > label {
  position: absolute;
  top: 0;
  left: 0;
  padding-top: 1.2rem;
  padding-left: .2rem;
  font-size: 1rem;
  color: var(--input-main-color);
  pointer-events: none;
  transition: .2s ease-in-out;
}

.input-container.error > .error-msg {
  position: absolute;
  bottom: .1rem;
  left: .2rem;
  font-size: .7rem;
  color: var(--error-color);
}

.input-container.error > .highlight {
  width: 100%;
  background-color: var(--error-color);
}

.input-container.error > label {
  color: var(--error-color);
}

.input-container > input:focus ~ .highlight {
  width: 100%;
  background-color: var(--accent-color);
}

.input-container > input:valid ~ label {
  font-size: .7rem;
  padding-top: .2rem;
}

.input-container > input:focus ~ label {
  color: var(--accent-color);
  font-size: .7rem;
  padding-top: .2rem;
}
</style>