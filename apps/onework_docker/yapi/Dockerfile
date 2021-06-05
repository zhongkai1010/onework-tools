FROM node:12.22.0-alpine

# RUN mkdir -p /app/docker-app/yapi \
#     && wget https://github.com/YMFE/yapi/archive/refs/tags/v1.9.2.zip -P /app/docker-app/yapi \
#     && unzip -o /app/docker-app/yapi/v1.9.2.zip -d /app/docker-app/yapi/ \
#     && mv /app/docker-app/yapi/yapi-1.9.2 /app/docker-app/yapi/vendors \
#     && cp /app/docker-app/yapi/vendors/config_example.json /app/docker-app/yapi/config.json 

RUN mkdir -p /app/docker-app/yapi

COPY . ./app/docker-app/yapi

WORKDIR  /app/docker-app/yapi/vendors

RUN npm install --global node-gyp --registry https://registry.npm.taobao.org \
    && npm install --production --registry https://registry.npm.taobao.org  
WORKDIR  /app/docker-app/yapi/vendors/server

EXPOSE 3000

ENTRYPOINT [ "node","app.js"]