-- START QUERY--
SELECT
	A.[CODE] as code
    ,A.KCODE as kcode
	,B.[NAME] as name
  FROM [TxDTIPRD].[dbo].XPRTS A
  JOIN [XHEAD] B ON A.KCODE = B.CODE
WHERE 
	(A.CODE LIKE '%' + @DMC_CODE + '%')
ORDER BY
	A.CODE, A.KCODE, B.NAME ASC


--select 
--	p.*,
--	h.NAME as OYANAME,
--	h2.NAME as KONAME,
--	v.BNAME as BUMONAME,
--	i1.BUNR,
--	i2.BUNR as KOBUNR,
--	h.DORIREKIOYA,
--	h2.DORIREKIKO,
--	h2.DOSEIBAN,
--	i2.LINKSLIP
--from 
--	TxDTIPRD.dbo.XPRTS p 
--	left join  TxDTIPRD.dbo.XHEAD h on p.CODE=h.CODE 
--	left join TxDTIPRD.dbo.XHEAD h2 on p.KCODE=h2.CODE 
--	left join TxDTIPRD.dbo.XSECT v on p.BUMO=v.BUMO 
--	left join TxDTIPRD.dbo.XITEM i1 on i1.CODE=p.CODE and i1.BUMO=h.MAINBUMO 
--	left join TxDTIPRD.dbo.XITEM i2 on i2.CODE=p.KCODE and i2.BUMO=h2.MAINBUMO
--Where 
--	(ISNULL(h.Z_FLG_KINSHI,N'') <> N'1' 
--	and ISNULL(h2.Z_FLG_KINSHI,N'') <> N'1' 
--	and (p.CODE Like N'%' + @DMC_CODE + '%'))
--order by p.CODE





-- END QUERY-- 
 
