/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-02-28 10:56:04
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\config\defaultSettings.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-02-07 10:36:00
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\config\defaultSettings.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import { Settings as LayoutSettings } from '@ant-design/pro-layout';
import { OwConfig } from '@/types/config.d';

const Settings: LayoutSettings & {
  pwa?: boolean;
  logo?: string;
} & OwConfig = {
  navTheme: 'dark',
  primaryColor: '#1890ff',
  layout: 'top',
  contentWidth: 'Fluid',
  fixedHeader: true,
  fixSiderbar: true,
  pwa: false,
  iconfontUrl: '',
  menu: {
    locale: true,
  },
  headerHeight: 48,
  splitMenus: false,
  colorWeak: false,
  title: 'OneWork',
  logo: 'https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg',
  baidu_translate_appId: '20210206000692404',
  baidu_translate_aecretkey: '26ZZ7HwrFuxiOcAQ_inQ',
  baidu_translate_url: '/api/trans/vip/translate',
};

export default Settings;
