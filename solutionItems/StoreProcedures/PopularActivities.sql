


Create Or Alter Procedure PopularActivities
as
Begin

	Select 
		a.Name,
		SUM(b.Attendees) [Attending]
	from Activity a
	JOIN Booking b
		on b.Activity_Id = a.Activity_Id

	WHERE b.Payment_Id is not null

	GROUP BY a.Name

	Order by Attending desc
END
