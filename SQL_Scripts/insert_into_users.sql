INSERT INTO public.users
	(first_name, last_name, blog_site_url, birthday)
VALUES 
  ('Alan', 'Jui', 'http://www.ccc99.tw', to_date('1960-09-25', 'YYYY-MM-DD')),
  ('Stacy', 'Wu', '', to_date('1967-08-18', 'YYYY-MM-DD')),
  ('Amos', 'Jui', '', to_date('2003-06-04', 'YYYY-MM-DD'));

SELECT * FROM public.users;


