import pymongo

client = pymongo.MongoClient("mongodb+srv://mongodb-stitch-justatest-ivbyf:rcwy19pqpR#@clusterroberto-xwqzu.mongodb.net/test?retryWrites=true")
db = client.test

print(db)
