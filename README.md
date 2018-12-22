# dfo-test

This application is seperated into 2 projects:
(1) Api: built by webapi in .net core, 
(2) Frontend: built by Angular7
Both are running on Docker

. Prerequisite:
 - Docker (Linux containers)

1. How to start api (backend)
- Open command line at root folder where located source code
- Run command: docker-compose up
- Check the api at http:localhost:32773

2. How to start frontend
- From root folder: cd Frontend
- Run command: docker build -t dfo.assignment.frontend .    // Have a dot (.) at the end
- Start app: docker run -p 4200:4200 dfo.assignment.frontend
- Check the result at http:localhost:4200
