# 操作指引

## 佈署到 Heroku

1.
```
$ heroku container:login
```

2.
```
$ heroku create ccc-pg-sql
```

3.
```
$ heroku addons:create heroku-postgresql:hobby-dev
```

【註】： 

  a. 查文件 `heroku addons:docs heroku-postgresql`

  b. 查 DATABASE_URL
    ```
    $ heroku config -s | grep DATABASE_URL
    ```

4.
```
$ dotnet publish -o out -c Release
```

5.
```
$ heroku container:push web
```

6.
```
$ heroku open
```




## 建立 Local 端用 Docker Image

1.
```
$ dotnet publish -o out
```

2.
```
$ docker build -f Dockerfile.local -t pg-sql .
```

3.
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