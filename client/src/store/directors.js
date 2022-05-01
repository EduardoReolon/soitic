import HTTP from '../http';

export default {
  namespaced: true,
  state: {
    directors: [],
    director: {},
  },
  actions: {
    fetchListDirectors({ commit }, {callback} = {}) {
      return HTTP().get('DirectorItems')
        .then(({data}) => {
          commit('setDirectors', {data});
          if (callback) callback();
        })
    },
    saveRecordDirectors({state}, {callback} = {}) {
      const verb = state.director.id < 0 ? 'post' : 'put';
      const directorItem = JSON.parse(JSON.stringify(state.director));
      const id = verb === 'post' ? '' : `/${directorItem.id}`;
      if (verb === 'post') delete directorItem.id;
      return HTTP()[verb](`DirectorItems${id}`, directorItem)
        .then(() => {
          if (callback) callback();
        });
    },
    deleteRecordDirectors({}, {id, callback} = {}) {
      return HTTP().delete(`DirectorItems/${id}`)
        .then(() => {
          if (callback) callback()
        });
    },
  },
  getters: {
  },
  mutations: {
    setDirectors(state, {data}) {
      state.directors.splice(0);
      state.directors.push(...data);
    },
    setDirector(state, {id}) {
      state.director = state.directors.find((d) => d.id === id) || {id};
    },
    setDirectorUpdate(state, {values}) {
      Object.keys(values).forEach((key) => {
        state.director[key] = values[key];
      });
    },
  },
};
