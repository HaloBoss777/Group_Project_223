using EasterneAdventuresApi.Core.DTOs;
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
        bool CreateBooking(ClientBookingDTO New_Booking);
        void PayForCart(List<PayActivityDTO> cartItems);

        //Payment

    }
}
