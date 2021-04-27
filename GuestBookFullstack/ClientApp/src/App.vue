<template>
  <div id="app">
    <div class="container">
      <CommentsForm @addComment="addComment"/>
    </div>
    <div class="container">
      <div class="center-inline">
        <h2>Comments</h2>
      </div>
      <BaseLoader v-if="loading" class="mx-auto"/>
      <div
          v-else-if="comments.length">
        <CommentsItem
            v-for="comment in sortedComments"
            :comment="comment"
            :key="comment.id"
            class="comment-item"/>
      </div>
      <div v-else class="center-inline">
        <strong>No have comments</strong>
      </div>
    </div>
  </div>
</template>

<script>
import CommentsForm from '@/components/CommentsForm.vue'
import CommentsItem from '@/components/CommentsItem.vue'
import BaseLoader from "@/components/BaseLoader";

export default {
  name: 'App',
  data() {
    return {
      loading: true,
      comments: []
    }
  },
  computed: {
    sortedComments() {
      return [...this.comments].sort((a, b) => b.createdAt - a.createdAt)
    }
  },
  methods: {
    addComment(comment) {
      fetch('/api/comments',
          {
            method: 'POST',
            headers: {
              'content-type': 'application/json'
            },
            body: JSON.stringify(comment)
          })
          .then(res => res.json())
          .then(data => {
            if (data.id !== undefined) this.comments.push(data)
          })
    }
  },
  mounted() {
    fetch('/api/comments')
        .then(res => res.json())
        .then(data => {
          this.comments = data
          this.loading = false
        })
  },
  components: {
    BaseLoader,
    CommentsForm,
    CommentsItem
  }
}
</script>

<style>
:root {
  --input-main-color: #121212;
  --accent-color: #34C8E4;
  --accept-color: #ABFA2A;
  --warn-color: #E99635;
  --error-color: #FF5252;
  --button-color: #457C88;
  --button-primary: #43B7DC;
  --button-focus: #68D0F1;
  --button-hover: #2AA2C8;
  --button-disable: #8ED4EA;
}

* {
  box-sizing: border-box;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  margin-top: 60px;
}

.container {
  width: 100%;
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
}

.mx-auto {
  margin-left: auto;
  margin-right: auto;
}

.center-inline {
  text-align: center;
}
</style>
