FROM nginx:alpine

WORKDIR /webgl
COPY build/ .

WORKDIR /etc/nginx/templates
COPY deployment/default.conf.template default.conf.template

