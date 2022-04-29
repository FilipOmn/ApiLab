# ApiLab

Krav:

1: https://localhost:44324/api/persons

2: https://localhost:44324/api/interests/personinterests/{personId}

3: https://localhost:44324/api/links/personlinks/{personId}

4: https://localhost:44324/api/personinterests
   
   POST: {
            "personId": 2,
            "interestId": 4
         }

5: https://localhost:44324/api/links/createnew/linktoperson/{personId}/{interestId}

POST: {
         "link_": "https://stackoverflow.com/"
      }
