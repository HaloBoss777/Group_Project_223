﻿using EasterneAdventuresApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IClientArea
    {
        //Activities

        List<ActivityDTO> GetAllActivities();

        //Bookings
        bool CreateBooking(BookingDTO New_Booking);

        //Payment

    }
}
