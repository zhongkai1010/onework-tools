 import App from './App.vue'
import { createApp } from 'vue';
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';

const app = createApp(App).mount('#app')

app.use(Antd)
