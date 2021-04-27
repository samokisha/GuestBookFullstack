<template>
  <div class="select-container" :class="{error: errorMessage}">
    <select
        :id="id"
        :value="value"
        @input="$emit('input', $event.target.value)"
        @change="$emit('change')"
        @blur="$emit('blur')"
        required>
      <option
          v-for="value in options"
          :value="value"
          :key="value">{{ value }}
      </option>
    </select>
    <div class="highlight"></div>
    <div class="error-msg" v-if="errorMessage">{{ errorMessage }}</div>
    <label :for="id">{{ label }}</label>
  </div>
</template>

<script>
export default {
  name: 'BaseSelect',
  props: {
    id: String,
    label: String,
    options: Array,
    value: String,
    errorMessage: String
  }
}
</script>

<style scoped>
.select-container {
  position: relative;
  padding-bottom: .9rem;
  font-family: sans-serif;
  font-weight: 400;
}

.select-container > select {
  border: none;
  border-bottom: 1px solid var(--input-main-color);
  width: 100%;
  padding: 1.2rem 0 .2rem;
  font-size: 1rem;
  outline: none;
  background-color: transparent;
  transition: .2s ease-in-out;
}

.select-container > .highlight {
  position: absolute;
  height: 2px;
  width: 0;
  bottom: .9rem;
  transition: .2s ease-in-out;
}

.select-container > label {
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

.select-container.error > .error-msg {
  position: absolute;
  bottom: .1rem;
  left: .2rem;
  font-size: .7rem;
  color: var(--error-color);
}

.select-container.error > .highlight {
  width: 100%;
  background-color: var(--error-color);
}

.select-container.error > label {
  color: var(--error-color);
}

.select-container > select:valid ~ label {
  font-size: .7rem;
  padding-top: .2rem;
}

.select-container > select:focus ~ .highlight {
  width: 100%;
  background-color: var(--accent-color);
}
</style>