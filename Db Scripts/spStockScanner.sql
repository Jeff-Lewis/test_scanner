USE [StockMonitor]
GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_Activate]    Script Date: 02/03/2011 20:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spStockCompany_Activate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spStockCompany_Activate]
GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_DeActivate]    Script Date: 02/03/2011 20:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spStockCompany_DeActivate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spStockCompany_DeActivate]
GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_Register]    Script Date: 02/03/2011 20:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spStockCompany_Register]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spStockCompany_Register]
GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_UnRegister]    Script Date: 02/03/2011 20:34:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spStockCompany_UnRegister]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spStockCompany_UnRegister]
GO

USE [StockMonitor]
GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_Activate]    Script Date: 02/03/2011 20:34:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* =============================================
-- Author:		Sergeyb
-- Create date: 3/2/2011
-- Description:	Activate stock company
-- =============================================*/
CREATE PROCEDURE [dbo].[spStockCompany_Activate]
	@CompanyId INT,
	
	@o_Status INT OUTPUT,
	@o_Message VARCHAR(100) OUTPUT
AS
BEGIN
	UPDATE dbo.Stock 
	SET Active = 1
	WHERE Id = @CompanyId
	
	IF @@ROWCOUNT > 0
		SELECT	@o_Status = 0,
				@o_Message = 'Sucess'
	ELSE
		SELECT	@o_Status = -1,
				@o_Message = 'Company is not registered'
	
END


GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_DeActivate]    Script Date: 02/03/2011 20:34:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* =============================================
-- Author:		Sergeyb
-- Create date: 3/2/2011
-- Description:	DeActivate stock company
-- =============================================*/
CREATE PROCEDURE [dbo].[spStockCompany_DeActivate]
	@CompanyId INT,
	
	@o_Status INT OUTPUT,
	@o_Message VARCHAR(100) OUTPUT
AS
BEGIN
	UPDATE dbo.Stock 
	SET Active = 0
	WHERE Id = @CompanyId
	
	IF @@ROWCOUNT > 0
		SELECT	@o_Status = 0,
				@o_Message = 'Sucess'
	ELSE
		SELECT	@o_Status = -1,
				@o_Message = 'Company is not registered'
	
END


GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_Register]    Script Date: 02/03/2011 20:34:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* =============================================
-- Author:		Sergeyb
-- Create date: 3/2/2011
-- Description:	Registers new stock company into Stock table

DECLARE @RC int
DECLARE @Ticker varchar(50)
DECLARE @CompanyName varchar(100)
DECLARE @ExchangeName varchar(100)
DECLARE @IndustryName varchar(100)
DECLARE @SectorName varchar(100)
DECLARE @ExchangeId int
DECLARE @IndustryId int
DECLARE @SectorId int
DECLARE @o_Company int
DECLARE @o_Message varchar(100)

-- TODO: Set parameter values here.
SELECT @Ticker = 'FAKE-ME2'
	,@CompanyName = 'ANWORTH MORTGAGE ASSET CP'
	,@IndustryName = 'Real Estate Investment Trust'
	,@SectorName = 'Financials'
	,@ExchangeName = 'NYSE'
	,@IndustryId = 57
	,@ExchangeId = 1
	,@SectorId = 4

DELETE FROM dbo.Stock WHERE Ticker = @Ticker
	
EXECUTE @RC = [StockMonitor].[dbo].[spStockCompany_Register] 
   @Ticker
  ,@CompanyName
  ,@ExchangeName
  ,@IndustryName
  ,@SectorName
  ,@ExchangeId
  ,@IndustryId
  ,@SectorId
  ,@o_Company OUTPUT
  ,@o_Message OUTPUT


SELECT * FROM vwStockCompany WHERE Id = @o_Company

GO

-- =============================================*/
CREATE PROCEDURE [dbo].[spStockCompany_Register]
	@Ticker VARCHAR(50), 
	@CompanyName VARCHAR(100),
	@ExchangeName VARCHAR(100),
	@IndustryName VARCHAR(100),
	@SectorName VARCHAR(100),
	@ExchangeId INT = NULL,
	@IndustryId INT = NULL,
	@SectorId INT = NULL,
	
	@o_Company INT OUTPUT,
	@o_Message VARCHAR(100) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF LEN(ISNULL(@Ticker,'')) > 0 
		BEGIN
			-- Register Exchange
			IF NOT EXISTS (SELECT Id FROM dbo.Exchange WHERE Id = ISNULL(@ExchangeId,0))
				BEGIN
					IF LEN(@ExchangeName) > 1 
						BEGIN
							INSERT dbo.Exchange (Name) VALUES (@ExchangeName)
							SELECT @ExchangeId = SCOPE_IDENTITY()
						END
					ELSE
						SELECT @ExchangeId = NULL
				END

			-- Register Indusctry
			IF NOT EXISTS (SELECT Id FROM dbo.Industry WHERE Id = ISNULL(@IndustryId,0))
				BEGIN
					IF LEN(@IndustryName) > 1 
						BEGIN

							-- Register Sector
							IF NOT EXISTS (SELECT Id FROM dbo.Sector WHERE Id = ISNULL(@SectorId,0))
								IF LEN(@SectorName) > 1 
									BEGIN
										INSERT dbo.Sector (SectorName) VALUES (@SectorName)
										SELECT @SectorId = SCOPE_IDENTITY()
									END
								ELSE
									SELECT @SectorId = NULL

							
							INSERT dbo.Industry(IndustryName) VALUES (@IndustryName)
							SELECT @IndustryId = SCOPE_IDENTITY()
						END
					ELSE
						SELECT @IndustryId = NULL
				END
			
			-- Register Stock
			IF NOT EXISTS (SELECT Id FROM dbo.Stock WHERE Ticker = @Ticker)
				BEGIN
					INSERT dbo.Stock(Ticker, ExchangeId, Name, IndustryId, Active)
					VALUES(@Ticker, @ExchangeId, @CompanyName, @IndustryId, 1)
					
					SELECT	@o_Company = SCOPE_IDENTITY(),
							@o_Message = 'Success'
				END
			ELSE
				BEGIN
					SELECT	@o_Company = Id, 
							@o_Message = 'Company is already registered'
					FROM dbo.Stock WHERE Ticker = @Ticker
				END
		END	
	ELSE 
		BEGIN
			SELECT	@o_Company = 0,
					@o_Message = 'Company Ticker is not specified'
		END
		
END

GO

/****** Object:  StoredProcedure [dbo].[spStockCompany_UnRegister]    Script Date: 02/03/2011 20:34:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* =============================================
-- Author:		Sergeyb
-- Create date: 3/2/2011
-- Description:	UnRegisters stock company
-- =============================================*/
CREATE PROCEDURE [dbo].[spStockCompany_UnRegister]
	@CompanyId INT,
	
	@o_Status INT OUTPUT,
	@o_Message VARCHAR(100) OUTPUT
AS
BEGIN
	DELETE FROM dbo.Stock WHERE Id = @CompanyId
	
	IF @@ROWCOUNT > 0
		SELECT	@o_Status = 0,
				@o_Message = 'Sucess'
	ELSE
		SELECT	@o_Status = -1,
				@o_Message = 'Company is not registered'
	
END


GO


