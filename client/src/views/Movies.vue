<template>
  <div>
    <h2>Filmes</h2>
    <List
      :list="movies"
      :deleteRecord="deleteRecord"
      :edditRecord="edditRecord"
    ></List>
    <Item v-if="edditingMode"
      :item="this.movie"
      :saveRecord="saveRecord"
      :cancelUpdate="() => {edditingMode = false;}"
      :updateRecord="setMovieUpdate"
    ></Item>
  </div>
</template>

<script>
import { mapActions, mapMutations, mapState } from 'vuex';
import List from '../components/List.vue';
import Item from '../components/Item.vue';

export default {
  mounted() {
    this.fetchListDirectors({callback: () => {
      this.fetchListMovies({directors: this.directors});
    }});
  },
  data() {
    return {
      edditingMode: false,
    }
  },
  components: {
    List,
    Item,
  },
  computed: {
    ...mapState('directors', ['directors']),
    ...mapState('movies', ['movies', 'movie']),
  },
  methods: {
    ...mapActions('directors', ['fetchListDirectors']),
    ...mapActions('movies', ['fetchListMovies', 'saveRecordMovies', 'deleteRecordMovies']),
    ...mapMutations('movies', ['setMovie', 'setMovieUpdate']),
    deleteRecord({id}) {
      this.deleteRecordMovies({id, callback: () => {
        this.fetchListMovies({directors: this.directors});
      }});
    },
    edditRecord({id}) {
      this.setMovie({id});
      this.edditingMode = true;
    },
    saveRecord() {
      this.saveRecordMovies({callback: () => {
        this.edditingMode = false;
        this.fetchListMovies({directors: this.directors});
      }});
    }
  }
}
</script>

<style>

</style>