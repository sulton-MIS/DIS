SELECT
	code as Dmc_Type
FROM
	[XHEAD]
where ITEM_TYPE like '%FGS%' and MAINBUMO like '%dti32b%' and code not like '%(Do%'
