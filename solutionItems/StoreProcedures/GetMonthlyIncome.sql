

Create Or Alter PROCEDURE [GetMonthlyIncome]
AS
BEGIN
	Select 
		DATEPART(MM, p.Paid) [Month],
		DATEPART(YYYY, p.Paid) [Year],
		SUM(TotalPrice) [Amount]
	from Payment p 
	Where p.Paid is not null
	Group by 
	DATEPART(MM, p.Paid),
	DATEPART(YYYY, p.Paid)
END






