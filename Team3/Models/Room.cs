/// <summary>
/// Represents a room in the hospital.
/// </summary>
namespace Team3.Models
{
    public class Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="id">The room ID.</param>
        /// <param name="departmentId">The ID of the department.</param>
        public Room(int id, int departmentId)
        {
            this.Id = id;
            this.DepartmentId = departmentId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the department to which the room belongs.
        /// </summary>
        public int DepartmentId { get; set; }

        public override string ToString()
        {
            return $"Room(Id: {this.Id}, DepartmentId: {this.DepartmentId})";
        }
    }
}