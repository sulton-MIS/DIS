SELECT
	code as DMC_CODE
FROM
	[XHEAD]
where ITEM_TYPE like '%FGS%' and MAINBUMO like '%dti32b%' and code not like '%(Do%'
