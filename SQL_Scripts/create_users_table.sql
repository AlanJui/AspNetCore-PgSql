DROP TABLE public.users;

CREATE TABLE public.users
(
    ID serial NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50)  NOT NULL,
    blog_site_url character varying(200),
    birthday date,
    CONSTRAINT users_pkey PRIMARY KEY (ID)
);

