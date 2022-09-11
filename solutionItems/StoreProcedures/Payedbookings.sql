

Create OR ALTER PROCEDURE Payedbookings
as
BEGIN

Select 
	b.[Booking_Id], 
	c.[Client_Id],
	c.Full_Name [Client_Full_Name],
	c.RSA_ID [Client_RSA_Id] ,
	c.CellNum [Client_Cell] ,
	a.[Activity_Id],
	a.[Name] [Activity_Name] ,
	a.Price_PP [Activity_PP] ,
	p.Payment_Id [Payment_Id] ,
	p.TotalPrice [Payment_Amount] ,
	CONVERT(varchar(255),CONVERT(Date,b.Date_Booked)) [Date_Booked] ,
	b.Attendees [Attendees]
	FROM Booking b
	JOIN Client c
		on c.Client_Id = b.Client_Id
	JOIN Activity a
		on a.Activity_Id = b.Activity_Id
	JOIN Payment p	
		on p.Payment_Id = b.Payment_Id

	ORder by p.Payment_Id desc

END