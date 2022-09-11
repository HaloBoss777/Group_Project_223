


Create Or Alter Procedure PopularActivities
as
Begin

	Select 
		a.Name,
		SUM(b.Attendees) [Attending]
	from Activity a
	JOIN Booking b
		on b.Activity_Id = a.Activity_Id
	JOIN Payment p
		on b.Payment_Id = p.Payment_Id

	WHERE p.Paid is not null

	GROUP BY  a.Name

	Order by Attending desc
END
