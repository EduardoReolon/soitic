import Vue from 'vue';
import VueRouter from 'vue-router';
import Login from '../views/Login.vue';
import Index from '../views/Index.vue';
import Movies from '../views/Movies.vue';
import Directors from '../views/Directors.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'index',
    component: Index,
  },
  {
    path: '/login',
    name: 'login',
    component: Login,
  },
  {
    path: '/movies',
    name: 'movies',
    component: Movies,
  },
  {
    path: '/directors',
    name: 'directos',
    component: Directors,
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

export default router;
