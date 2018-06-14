import urllib.request as urllib2
import requests
import json

cosmos_headers = {
      'X-Cosmos-Token': 'jbmqi8EV5eSne9sskne2kQ',
      'Content-Type': 'application/json'
        }


req = requests.get('https://api.cosmos.bluesoft.com.br//retailers/products?query=Arroz Tipo 1 PRATO FINO 5kg', headers={'X-Cosmos-Token': 'jbmqi8EV5eSne9sskne2kQ',
      'Content-Type': 'application/json'})
print(req.request.headers.get("X-Cosmos-Token"))
data = req.json()
print(json.dumps(data, indent=4))