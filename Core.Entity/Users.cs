namespace Core.Entity
{
    public class Users
    {
        public string? FullName { get; set; }
        public bool ObjectChanged { get; set; }
        public Int64 ID { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? AlternateEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FCMToken { get; set; }
        public byte RoleId { get; set; }
        public Int64 ParentId { get; set; }
        public string? DeviceID { get; set; }
        public string? UserLastLatitude { get; set; }
        public string? UserLastLongitude { get; set; }
        public string? UserAPIKey { get; set; }
        public bool IsVerified { get; set; }
        public string? VerficationCode { get; set; }
        public string? VerficationDate { get; set; }
        public byte StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string? CompanyName { get; set; }

        public int LanguageId { get; set; }

        public Int64 AvailableSeats { get; set; }
        public Int64 DownAvailableSeats { get; set; }
        public Int64 UpAvailableSeats { get; set; }
        public Int64 RowNumber { get; set; }
        public string? VehicleNo { get; set; }
        public string? DestinationLastLongitude { get; set; }
        public string? DestinationLastLatitude { get; set; }
        public byte IsAvailable { get; set; }
        public string? VehicleType { get; set; }
    }

    public class VehicleDetails
    {
        public Int64 DriverUserID { get; set; }

        public byte IsAvailable { get; set; }
        public Int64 AvailableSeats { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleNo { get; set; }
        public byte StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}