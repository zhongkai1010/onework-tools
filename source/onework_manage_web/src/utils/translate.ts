/*
 * @Author: 钟凯
 * @Date: 2021-02-07 11:07:52
 * @LastEditTime: 2021-02-07 16:31:16
 * @LastEditors: 钟凯
 * @Description: 
 * @FilePath: \onework_manage_web\src\utils\translate.ts
 * @可以输入预定的版权声明、个性签名、空行等
 */
import defaultSettings from '../../config/defaultSettings'
import md5 from 'md5'
import request from 'umi-request';



export class Translate {

    private static appid = defaultSettings.baidu_translate_appId;
    private static aecretkey = defaultSettings.baidu_translate_aecretkey

    public static async to(quyery: string) {
        const q = encodeURI(quyery)
        const salt = (new Date).getTime();
        const value = `${Translate.appid}${quyery}${salt}${Translate.aecretkey}`
        const sign = md5(value)
        const url = `/api/trans/vip/translate?q=${q}&from=zh&to=en&appid=${Translate.appid}&salt=${salt}&sign=${sign}`;
        let result: any;
        await request.get(url).then((data) => {
            result = data;
        });
        return new Promise((resolve) => {
            resolve(result);
        })
    }
}