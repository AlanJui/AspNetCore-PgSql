# 操作指引

## 佈署到 Heroku

1. 登入 Heroku Docker 平台
```
$ heroku container:login
```

2. 建立新的 Heroku App
```
$ heroku create ccc-pg-sql
```

3. 建立供 Heroku App 使用的 Heroku Postgres 資料庫
```
$ heroku addons:create heroku-postgresql:hobby-dev
```

【註】： 

  a. 查文件 `heroku addons:docs heroku-postgresql`

  b. 查 DATABASE_URL
    ```
    $ heroku config -s | grep DATABASE_URL
    ```

4. 為發行作業備妥完成編譯之程式碼(ASP.NET Core Web / API)
```
$ dotnet publish -o out -c Release
```

5. 執行發行作業，將程式碼佈署到 Heroku Docker 平台
```
$ heroku container:push web
```

6. 執行 Heroku App
```
$ heroku open
```




## 建立 Local 端用 Docker Image

編譯 ASP.NET Core Web / API 原始程式碼

1. 執行發行作業，經編譯後的執行程式碼，放入 out 資料夾中
```
$ dotnet publish -o out
```

2. 將發行作業產出之執行程式碼，製成 Docker Image ： pg-sql 檔案（使用 Dockerfile.local 檔案）
```
$ docker build -f Dockerfile.local -t pg-sql .
```

3. 使用 Docker Image（pg-sql），產生 Docker Container 
```
$ docker run --rm -p 8000:80 pg-sql
```


## Heroku PostgreSQL 工具箱

- 查詢 PgSQL

  ```
  $ heroku pg:info
  ```

- 檢測狀態

  ```
  $ heroku pg:diagnose --app <HerokuApp>
  ```

- 留下 DB 使用紀錄

  ```
  $ heroku logs -t
  ```

  ```
  $ heroku logs -p postgres -t
  ```

- 操作遠端的 Heroku PostgreSQL

  ```
  $ heroku pg:psql
  ```