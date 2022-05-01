// import createPersistedState from 'vuex-persistedstate';
import Vue from 'vue';
import Vuex from 'vuex';
import authentication from './authentication';
import movies from './movies';
import directors from './directors';

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  state: {
  },
  modules: {
    authentication,
    movies,
    directors,
  },
  mutations: {
    setState(state, {key, value}) {
      state[key] = value;
    },
  },
  actions: {
  },
  plugins: [
    // createPersistedState(),
  ],
});
