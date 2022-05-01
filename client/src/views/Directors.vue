<template>
  <div>
    <h2>Diretores</h2>
    <List
      :list="directors"
      :showDirector="false"
      :deleteRecord="deleteRecord"
      :edditRecord="edditRecord"
    ></List>
    <Item v-if="edditingMode"
      :item="director"
      :showDirector="false"
      :saveRecord="saveRecord"
      :cancelUpdate="() => {edditingMode = false;}"
      :updateRecord="setDirectorUpdate"
    ></Item>
  </div>
</template>

<script>
import { mapActions, mapMutations, mapState } from 'vuex';
import List from '../components/List.vue';
import Item from '../components/Item.vue';

export default {
  mounted() {
    this.fetchListDirectors();
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
    ...mapState('directors', ['directors', 'director']),
  },
  methods: {
    ...mapActions('directors', ['fetchListDirectors', 'saveRecordDirectors', 'deleteRecordDirectors']),
    ...mapMutations('directors', ['setDirector', 'setDirectorUpdate']),
    deleteRecord({id}) {
      this.deleteRecordDirectors({id, callback: () => {
        this.fetchListDirectors();
      }});
    },
    edditRecord({id}) {
      this.setDirector({id});
      this.edditingMode = true;
    },
    saveRecord() {
      this.saveRecordDirectors({callback: () => {
        this.edditingMode = false;
        this.fetchListDirectors();
      }});
    }
  }
}
</script>

<style>

</style>