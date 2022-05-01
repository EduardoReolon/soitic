<template>
  <div class="divList">
    <table>
      <tr>
        <td>Id</td>
        <td>Nome</td>
        <td v-if="showDirector">Diretor</td>
      </tr>
      <tr v-for="(item, indexItem) in list" :key="indexItem">
        <td>{{item.id}}</td>
        <td>{{item.name}}</td>
        <td v-if="showDirector">{{item.director_name}}</td>
        <td><button @click="deleteRecord({id: item.id})"
        >Deletar</button></td>
        <td><button @click="edditRecord({id: item.id})"
        >Editar</button></td>
      </tr>
    </table>
    <button @click="edditRecord({id: -1})"
    >Novo item</button>
  </div>
</template>

<script>
export default {
  props: {
    list: Array,
    showDirector: {
      type: Boolean,
      default: true,
    },
    deleteRecord: Function,
    edditRecord: Function,
  },
}
</script>

<style>
.divList td:not(:last-of-type):not(:nth-last-of-type(2)){
  padding: 0 20px;
}
</style>