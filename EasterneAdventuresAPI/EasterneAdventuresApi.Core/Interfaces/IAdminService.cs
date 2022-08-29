using EasterneAdventuresApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAdminService
    {
        //Activities

        List<ActivityDTO> GetAllActivities();
        bool AddActivity(ActivityDTO activity);
        bool UpdateActivity(ActivityDTO activity);
        bool DeleteActivity(int activity_Id);

        //Employee

        List<EmployeeDTO> GetAllEmployee();

        bool AddEmployee(EmployeeDTO employee);

        bool UpdateEmployee(EmployeeDTO employee);

        bool DeleteEmployee(int employee_Id);

        //Booking

        List<BookingDTO> GetAllBookings();

        bool AddBooking(BookingDTO booking);

        bool UpdateBooking(BookingDTO booking);

        bool DeleteBooking(int booking_Id);

        //Equipment

        List<EquipmentDTO> GetAllEquipment();

        bool AddEquipment(EquipmentDTO equipment);

        bool UpdateEquipment(EquipmentDTO equipment);

        bool DeleteEquipment(int equipment_Id);
    }
}
