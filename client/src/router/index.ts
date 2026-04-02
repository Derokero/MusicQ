import { createRouter, createWebHistory } from "vue-router";
import MainPage from "@/pages/MainPage.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: MainPage,
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
