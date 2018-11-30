FROM node:8.9.3-alpine
RUN mkdir -p /bin/
COPY ./app/ /bin/
WORKDIR /bin
RUN npm install
CMD node index.js