
SELECT	Number = 1
	  , Sid			= NEWID()
      ,	PlantCode	= '1'
      ,	Printer		= 'LSX-01'
	  ,	Model		= 'INNOVA'
	  ,	pageType	= 'A4'
      ,	CreatedBy	= 'Admin'
      ,	CreatedDate = GETUTCDATE()
	  ,	ChangedBy   = 'Admin'
      ,	ChangedDate	= GETUTCDATE()

UNION

SELECT	Number = 2
	  , Sid			= NEWID()
      ,	PlantCode	= '1'
      ,	Printer		= 'LSX-02'
	  ,	Model		= 'FORTUNNER'
	  ,	pageType	= 'A4'
      ,	CreatedBy	= 'Admin'
      ,	CreatedDate = GETUTCDATE()
	  ,	ChangedBy   = 'Admin'
      ,	ChangedDate	= GETUTCDATE()

UNION

SELECT	Number = 3
	  , Sid			= NEWID()
      ,	PlantCode	= '2'
      ,	Printer		= 'DLX-01'
	  ,	Model		= 'VIOS'
	  ,	pageType	= 'A3'
      ,	CreatedBy	= 'Admin'
      ,	CreatedDate = GETUTCDATE()
	  ,	ChangedBy   = 'Admin'
      ,	ChangedDate	= GETUTCDATE()