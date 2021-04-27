<template>
  <div class="card">
    <div class="dot" :class="comment.commentType.toLowerCase()"></div>
    <strong>{{ comment.author.name }}</strong>
    <small v-if="comment.author.callbackContact">&nbsp;&lt;{{ comment.author.callbackContact }}&gt;</small>
    <small class="created-at">{{ comment.createdAt | formatDateTime }}</small>
    <p><em>{{ comment.text }}</em></p>
  </div>
</template>

<script>
export default {
  name: 'CommentsItem',
  props: {
    comment: Object
  },
  filters: {
    formatDateTime(unixtime) {
      const date = new Date(unixtime * 1000)
      return date.toLocaleString(undefined,
          {
            day: 'numeric',
            month: '2-digit',
            year: '2-digit',
            hour: 'numeric',
            minute: '2-digit'
          })
    }
  }
}
</script>

<style scoped>
.card {
  box-sizing: border-box;
  padding: 1rem 3rem;
  margin: .7rem 0;
  border-radius: .3rem;
  box-shadow: 0 .3rem .6rem 0 #0003;
  transition: 0.3s;
}

.card:hover {
  box-shadow: 0 .6rem 1.2rem 0 #0003;
}

.created-at {
  float: right;
}

.dot {
  display: inline-block;
  width: .5rem;
  height: .5rem;
  border-radius: .5rem;
  margin-right: .5rem;
}

.thanks {
  background-color: var(--accept-color);
}

.suggest {
  background-color: var(--warn-color);
}

.complaint {
  background-color: var(--error-color);
}
</style>
