<template>
  <div>
    <h2>Guest Book</h2>
    <form novalidate>
      <BaseInputText
          id="guest-name"
          label="Name"
          @keyup="validateName"
          @blur="validateName"
          v-model.trim="comment.author.name"
          :error-message="error.name"/>
      <BaseInputText
          id="callback-contact"
          label="Contact"
          v-model.trim="comment.author.callbackContact"/>
      <BaseSelect
          id="comment-type"
          label="Comment type"
          @change="validateCommentType"
          @blur="validateCommentType"
          :options="commentTypes"
          v-model="comment.commentType"
          :error-message="error.commentType"/>
      <BaseTextarea
          id="text"
          label="Text"
          @keyup="validateText"
          @blur="validateText"
          v-model.trim="comment.text"
          :error-message="error.text"
          maxlength="500"/>
      <BaseButton
          @click.prevent="addComment"
          text="Add"
          class="primary mx-auto"/>
    </form>
  </div>
</template>

<script>
import BaseButton from "@/components/BaseButton";
import BaseInputText from "@/components/BaseInputText";
import BaseTextarea from "@/components/BaseTextarea";
import BaseSelect from "@/components/BaseSelect";

export default {
  name: 'CommentsForm',
  components: {BaseSelect, BaseTextarea, BaseInputText, BaseButton},
  data() {
    return {
      comment: {
        author: {
          name: '',
          callbackContact: ''
        },
        commentType: '',
        text: ''
      },
      commentTypes: ['Thanks', 'Complaint', 'Suggest'],
      error: {
        name: undefined,
        commentType: undefined,
        text: undefined
      }
    }
  },
  computed: {
    formValid() {
      return (this.error.name + this.error.commentType + this.error.text).length === 0
    }
  },
  methods: {
    addComment() {
      if (this.validateForm()) {
        this.$emit('addComment', this.comment)
        this.clearForm()
      }
    },
    clearForm() {
      this.comment.author.name = ''
      this.comment.author.callbackContact = ''
      this.comment.text = ''
    },
    validateForm() {
      this.validateName()
      this.validateCommentType()
      this.validateText()
      return this.formValid
    },
    validateName() {
      if (!this.comment.author.name) {
        this.error.name = 'Please type your name.'
        return
      }
      if (this.comment.author.name.length < 4) {
        this.error.name = 'Name lenght must be at least 4 characters.'
        return
      }
      this.error.name = ''
    },
    validateCommentType() {
      if (!this.comment.commentType) {
        this.error.commentType = 'Please select type of your request.'
        return
      }
      this.error.commentType = ''
    },
    validateText() {
      if (!this.comment.text) {
        this.error.text = 'Please enter text of your request.'
        return
      }
      if (this.comment.text.length < 20) {
        this.error.text = 'Text must be at least 20 characters.'
        return
      }
      this.error.text = ''
    }
  }
}
</script>

<style scoped>
* {
  font-family: Avenir, Helvetica, Arial, sans-serif;
}

h2 {
  text-align: center;
}

form {
  border: 2px solid var(--accent-color);
  border-radius: 1rem;
  padding: 2rem 3rem;
}
</style>
