## Distibuted Databse MongoDb 

Instruction

```
sudo docker network create my-mongo-cluster

sudo docker run --name mongo -p 27017:27017 mongo
sudo docker run --name mongo-node1 -d -p 5051:27017 --net my-mongo-cluster mongo mongod --replSet "rs0"
sudo docker run --name mongo-node2 -d -p 5052:27017 --net my-mongo-cluster mongo mongod --replSet "rs0"
sudo docker run --name mongo-node3 -d -p 5053:27017 --net my-mongo-cluster mongo mongod --replSet "rs0"

sudo docker exec -it mongo-node1 mongo

config = {
      "_id" : "rs0",
      "members" : [
          {
              "_id" : 0,
              "host" : "mongo-node1:27017"
          },
          {
              "_id" : 1,
              "host" : "mongo-node2:27017"
          },
          {
              "_id" : 2,
              "host" : "mongo-node3:27017"
          }
      ]
  }

rs.initiate(config)

sudo docker build -t mono-app .
suod docker run --net my-mongo-cluster mono-app
```
