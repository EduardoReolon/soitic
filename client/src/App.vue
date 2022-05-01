<template>
  <div id="app">
    <button @click="goToHome()"
    >Página inicial</button>
    <button @click="goToMovies()"
    >Filmes</button>
    <button @click="goToDirectors()"
    >Diretores</button>
    <router-view/>
  </div>
</template>

<script>
import router from './router';

export default {
  name: 'App',
  methods: {
    goToHome() {
      router.push('/').catch(() => {});
    },
    goToMovies() {
      router.push('/movies').catch(() => {});
    },
    goToDirectors() {
      router.push('/directors').catch(() => {});
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 20px;
}
</style>
