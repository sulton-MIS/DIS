SELECT
	CNAME as Customer
FROM
	XCUST
where CNAME not like '%(Do%'
				