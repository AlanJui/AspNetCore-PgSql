## 匯出 Table

"/Library/PostgreSQL/9.6/bin/psql/psql" --command " "\\copy public.users (id, first_name, last_name, blog_site_url, birthday) TO '/Users/AlanJui/workspace/PostgreSQL/pgSQL/SQL_Scripts/users' DELIMITER ',' CSV HEADER ENCODING 'UTF8' QUOTE '\"' ESCAPE '''';""

