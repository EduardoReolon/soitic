<template>
  <div>
    <label>
      Id
      <input type="numeric" :value="item.id" disabled>
    </label>
    <label>
      Nome
      <input type="text" :value="item.name"
        @change="updateRecord({values: {name: $event.target.value}});">
    </label>
    <label v-if="showDirector">
      Diretor
      <select :value="item.director_id"
        @change="updateRecord({values: {director_id: parseInt($event.target.value)}});">
        <option v-for="(director, indexDirector) in directors" :key="indexDirector"
          :value="director.id">{{director.name}}</option>
      </select>
    </label>
    <button @click="saveRecord()"
    >Salvar</button>
    <button @click="cancelUpdate()"
    >Cancelar</button>
  </div>
</template>

<script>
import { mapState } from 'vuex'
export default {
  props: {
    item: Object,
    showDirector: {
      type: Boolean,
      default: true,
    },
    saveRecord: Function,
    cancelUpdate: Function,
    updateRecord: Function,
  },
  computed: {
    ...mapState('directors', ['directors']),
  }
}
</script>

<style>

</style>