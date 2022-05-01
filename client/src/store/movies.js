import HTTP from '../http';

export default {
  namespaced: true,
  state: {
    movies: [],
    movie: {},
  },
  actions: {
    fetchListMovies({ commit }, {directors} = {}) {
      return HTTP().get('MovieItems')
        .then(({data}) => {
          commit('setMovies', {data, directors});
        })
    },
    saveRecordMovies({state}, {callback} = {}) {
      const verb = state.movie.id < 0 ? 'post' : 'put';
      const movieItem = JSON.parse(JSON.stringify(state.movie));
      const id = verb === 'post' ? '' : `/${movieItem.id}`;
      if (verb === 'post') delete movieItem.id;
      return HTTP()[verb](`MovieItems${id}`, movieItem)
        .then(() => {
          if (callback) callback();
        });
    },
    deleteRecordMovies({}, {id, callback} = {}) {
      return HTTP().delete(`MovieItems/${id}`)
        .then(() => {
          if (callback) callback()
        });
    },
  },
  getters: {
  },
  mutations: {
    setMovies(state, {data, directors}) {
      state.movies.splice(0);
      data.forEach((m) => {
        const director = directors.find((d) => d.id === m.director_id);
        if (director) m.director_name = director.name;
      });
      state.movies.push(...data);
    },
    setMovie(state, {id}) {
      state.movie = state.movies.find((m) => m.id === id) || {id};
    },
    setMovieUpdate(state, {movie, values}) {
      const movieTarget = movie || state.movie;
      Object.keys(values).forEach((key) => {
        movieTarget[key] = values[key];
      });
    },
  },
};
