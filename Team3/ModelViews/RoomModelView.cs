using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Team3.Models;
using Team3.DBServices;
//Mi a trebuit mie clasa si am creato eu cu gpt dar nu e taskul meu sherdy

namespace Team3.ModelViews
{

    public class RoomModelView : IRoomModelView
    {
        // Attributes
        public ObservableCollection<Room> Rooms { get; private set; }
        public ObservableCollection<Room> RoomsInfo { get; private set; }
        private readonly RoomDatabaseService _roomModel;

        // Constructor
        public RoomModelView()
        {
            _roomModel = RoomDatabaseService.Instance;
            Rooms = new ObservableCollection<Room>();
            RoomsInfo = new ObservableCollection<Room>();
            LoadAllRooms();
        }

        // Load all rooms
        private void LoadAllRooms()
        {
            try
            {
                var roomList = _roomModel.GetRooms();
                if (roomList != null && roomList.Count > 0)
                {
                    foreach (var room in roomList)
                    {
                        Debug.WriteLine($"Room: {room.Id}, Department ID: {room.DepartmentId}");
                        Rooms.Add(room);
                        RoomsInfo.Add(room);
                    }
                }
                else
                {
                    Debug.WriteLine("No rooms found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading rooms: {ex.Message}");
            }
        }

        // Filter rooms by department ID
       
        public ObservableCollection<Room> GetRoomsByDepartmentId(int departmentId)
        {
            try
            {
                var filteredRooms = new ObservableCollection<Room>(
                    _roomModel.GetRooms().Where(r => r.DepartmentId == departmentId)
                );

                if (!filteredRooms.Any())
                {
                    Debug.WriteLine($"No rooms found for Department ID: {departmentId}");
                }

                return filteredRooms;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error filtering rooms by Department ID: {ex.Message}");
                throw;
            }
        }

        // Get equipment by Department ID and date range

        //Eu n am avut de facut Equipment dar cand vei da merge ar trebui sa mearga
        //public List<Equipment> GetEquipmentsByDepartmentId(int departmentId, DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        // Get all rooms for the given department
        //        var departmentRooms = _roomModel.GetRooms().Where(r => r.DepartmentId == departmentId).ToList();

        //        if (!departmentRooms.Any())
        //        {
        //            Debug.WriteLine($"No rooms found for Department ID: {departmentId}");
        //            return new List<Equipment>();  //Eu n am avut de facut Equipment dar cand vei da merge ar trebui sa mearga
        //        }

        //        // Get equipment used in these rooms within the date range
        //        var roomIds = departmentRooms.Select(r => r.Id).ToList();
        //        var equipmentList = _equipmentModel.GetEquipmentsByRoomsAndDate(roomIds, startDate, endDate);  //Eu n am avut de facut Equipment dar cand vei da merge ar trebui sa mearga

        //        if (!equipmentList.Any())
        //        {
        //            Debug.WriteLine($"No equipment found for Department ID: {departmentId} between {startDate} and {endDate}");
        //        }

        //        return equipmentList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error retrieving equipment: {ex.Message}");
        //        throw;
        //    }
        //}


        //same here eu n am Hospitalization in taksurile mele si deaia exiosta erorile
        //public List<Hospitalization> GetHospitalizationByDepartmentID(int departmentId, DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        // get the room assosicated with the departments
        //        var roomList = _roomModel.GetRooms();
        //        var departmentRooms = roomList.Where(r => r.DepartmentId == departmentId).Select(r => r.Id).ToList();

        //        if (!departmentRooms.Any())
        //        {
        //            Debug.WriteLine($"Nu există camere pentru departamentul ID: {departmentId}");
        //            return new List<Hospitalization>();  //same here eu n am Hospitalization in taksurile mele si deaia exiosta erorile
        //        }

        //        // get the specializations based on department id
        //        var hospitalizations = _hospitalizationModel.GetHospitalizations()  //same here eu n am Hospitalization in taksurile mele si deaia exiosta erorile
        //            .Where(h => departmentRooms.Contains(h.RoomId) &&
        //                        h.StartDate >= startDate &&
        //                        h.EndDate <= endDate)
        //            .ToList();

        //        if (!hospitalizations.Any())
        //        {
        //            Debug.WriteLine($"Nu s-au găsit spitalizări pentru departamentul {departmentId} în intervalul {startDate} - {endDate}");
        //        }

        //        return hospitalizations;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Eroare la obținerea spitalizărilor: {ex.Message}");
        //        throw;
        //    }
        //}
    }
}
