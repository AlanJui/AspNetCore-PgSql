COPY public.users (first_name, last_name, blog_site_url, birthday) 
FROM '/Users/AlanJui/workspace/PostgreSQL/Users.csv' 
DELIMITER ',' CSV HEADER;

SELECT * FROM public.users;
