# Mercury Api

Backend for the Mercury Smart Occupancy Tracker available on the [app store](https://apps.apple.com/ca/app/mercury-occupancy-tracker/id1535347240)

## To run

First fill out and follow instructions mentioned in the provided [sample.json](sample.json)

then run the application using

`docker-compose up -d`

if you are using docker-compose or

```

docker build -t mercury_api .

docker run -e MERCURY_API_DB_HOST=localhost -e MERCURY_API_APPLICATION_PORT=8080 -e MERCURY_API_DB_NAME=db -e MERCURY_API_DB_USER=user -e MERCURY_API_DB_PASSWORD=password -p 8080:8080 -d mercury_api

```