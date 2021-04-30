/*
 * @Author: 钟凯
 * @Date: 2021-03-13 10:24:18
 * @LastEditTime: 2021-03-14 09:23:09
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\pages\DataBase\components\RefreshConnectionButton.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { UndoOutlined } from '@ant-design/icons';
import type { ButtonProps } from 'antd';
import { Button } from 'antd';
import React from 'react';

const RefreshConnectionButton = (props: ButtonProps) => {
  return <Button icon={<UndoOutlined />} style={{ cursor: 'pointer', border: 0 }} {...props} />;
};

export default RefreshConnectionButton;
