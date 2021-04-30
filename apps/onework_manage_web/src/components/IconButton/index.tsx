/*
 * @Author: 钟凯
 * @Date: 2021-03-24 16:56:19
 * @LastEditTime: 2021-03-24 22:41:58
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_web\src\components\IconButton\index.tsx
 * 可以输入预定的版权声明、个性签名、空行等
 */
import { UndoOutlined } from '@ant-design/icons';
import type { ButtonProps } from 'antd';
import { Button } from 'antd';
import React, { useState } from 'react';

interface Prpps {
  onClick: () => Promise<any>;
}

const IconButton = (props: Prpps & Omit<ButtonProps, 'onClick'>) => {
  const [loadding, setLoadding] = useState(false);

  return (
    <Button
      type="text"
      icon={<UndoOutlined />}
      style={{ cursor: 'pointer', border: 0, backgroundColor: 'transparent', padding: 0 }}
      {...props}
      loading={loadding}
      onClick={() => {
        setLoadding(true);
        props.onClick().finally(() => {
          if (setLoadding) {
            setLoadding(false);
          }
        });
      }}
    >
      {props.children}
    </Button>
  );
};

export default IconButton;
