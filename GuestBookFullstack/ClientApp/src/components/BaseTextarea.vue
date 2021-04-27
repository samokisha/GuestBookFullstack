<template>
  <div class="textarea-container" :class="{error: errorMessage}">
  <textarea
      :id="id"
      :value="value"
      :cols="cols"
      :rows="rows"
      spellcheck="false"
      @input="$emit('input', $event.target.value)"
      @keyup="$emit('keyup')"
      @blur="$emit('blur')"
      required
      :maxlength="maxlength"></textarea>
    <div class="highlight"></div>
    <div class="error-msg" v-if="errorMessage">{{ errorMessage }}</div>
    <div class="char-count">{{ value.length }}<span v-if="maxlength"> / {{ maxlength }}</span></div>
    <label :for="id">{{ label }}</label>
  </div>
</template>

<script>
export default {
  name: 'BaseTextarea',
  props: {
    id: String,
    value: String,
    maxlength: String,
    label: String,
    errorMessage: String,
    cols: String,
    rows: String
  }
}
</script>

<style scoped>
.textarea-container {
  position: relative;
  padding-bottom: .9rem;
  font-family: sans-serif;
  font-weight: 400;
}

.textarea-container > textarea {
  display: block;
  border: none;
  border-bottom: 1px solid var(--input-main-color);
  width: 100%;
  padding: 1.2rem .2rem .2rem;
  font-size: 1rem;
  outline: none;
  resize: vertical;
  transition: .2s ease-in-out;
}

.textarea-container > .highlight {
  position: absolute;
  height: 2px;
  width: 0;
  bottom: .9rem;
  transition: .2s ease-in-out;
}

.textarea-container > label {
  position: absolute;
  top: 0;
  left: 0;
  padding-top: 1.2rem;
  padding-left: .2rem;
  font-size: 1rem;
  color: var(--input-main-color);
  pointer-events: none;
  width: 100%; /* TODO: Fix textarea content scrolling under label text */
  background-color: #fff; /* ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ */
  transition: .2s ease-in-out;
}

.textarea-container.error > .error-msg {
  position: absolute;
  bottom: .1rem;
  left: .2rem;
  font-size: .7rem;
  color: var(--error-color);
}

.textarea-container.error > .highlight {
  width: 100%;
  background-color: var(--error-color);
}

.textarea-container.error > label {
  color: var(--error-color);
}

.textarea-container > textarea:focus ~ .highlight {
  width: 100%;
  background-color: var(--accent-color);
}

.textarea-container > textarea:valid ~ label {
  font-size: .7rem;
  padding-top: .2rem;
}

.textarea-container > textarea:focus ~ label {
  color: var(--accent-color);
  font-size: .7rem;
  padding-top: .2rem;
}

.char-count {
  position: absolute;
  right: .2rem;
  font-size: .8rem;
}
</style>