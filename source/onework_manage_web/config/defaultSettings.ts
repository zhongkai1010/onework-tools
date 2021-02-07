/*
 * @Author: 钟凯
 * @Date: 2021-02-03 14:28:04
 * @LastEditTime: 2021-02-07 15:48:44
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
import { OwConfig } from '@/types/config.d'

const Settings: LayoutSettings & {
  pwa?: boolean;
  logo?: string;
} & OwConfig = {
  navTheme: 'light',
  // 拂晓蓝
  primaryColor: '#1890ff',
  layout: 'mix',
  contentWidth: 'Fluid',
  fixedHeader: false,
  fixSiderbar: true,
  colorWeak: false,
  title: 'Ant Design Pro',
  pwa: false,
  logo: 'https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg',
  iconfontUrl: '',
  baidu_translate_appId: '20210206000692404',
  baidu_translate_aecretkey: '26ZZ7HwrFuxiOcAQ_inQ',
  baidu_translate_url:'/api/trans/vip/translate'
};

export default Settings;
