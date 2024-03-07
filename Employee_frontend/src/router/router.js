import theSettingPage from "../components/layout/theSettingPage.vue";
import theCustomerPage from "../components/layout/theCustomerPage.vue";
import theHomePage from "../components/layout/theHomePage.vue";
import theReportPage from "../components/layout/theReportPage.vue";

import { createWebHistory, createRouter } from "vue-router";

const routes = [
  { path: "/", component: theHomePage, name: "home" },
  { path: "/report", component: theReportPage, name: "report" },
  { path: "/customer", component: theCustomerPage, name: "customer" },
  { path: "/setting", component: theSettingPage, name: "setting" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
