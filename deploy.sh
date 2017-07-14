#!/usr/bin/env sh

APP_NAME=ccc-pg-sql

# ASP.NET Core Build
dotnet publish -o out -c Release

# Docker Image Build
docker build -f Dockerfile -t $APP_NAME .

# Deploy to Heroku
docker tag $APP_NAME registry.heroku.com/$APP_NAME/web  
docker push registry.heroku.com/$APP_NAME/web  