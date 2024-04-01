namespace Core.Entity
{
    public class Transactions
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string? _strUUID;
        private Int64 _intUserID;
        private Int64 _intDriverUserID;
        private Int64 _intLocationMasterIDTo;
        private Int64 _intLocationMasterIDFrom;
        private string? _strPickLocationLatitude;
        private string? _strPickLocationLongitude;
        private string? _strDropLocationLatitude;
        private string? _strDropLocationLongitude;
        private string? _strDriverLocationLatitudeOnBooking;
        private string? _strDriverLocationLongitudeOnBooking;
        private string? _strJourneyStartDateTime;
        private string? _strJourneyEndDateTime;
        private string? _strVerificationCode;
        private byte _bytJourneyStatus;
        private string? _strJourneyStatusDateTime;
        private string? _strUserRequestDatetime;
        private byte? _bytStatusId;
        private DateTime? _datCreatedDate;
        private DateTime? _datUpdatedDate;

        #endregion Declarations

        #region Properties

        public bool ObjectChanged
        {
            get { return this._boolObjectChanged; }
            set { this._boolObjectChanged = value; }
        }

        public Int64 ID
        {
            get { return this._intID; }
            set { this._intID = value; }
        }

        public string? UUID
        {
            get { return this._strUUID; }
            set { this._strUUID = value; }
        }

        public Int64 UserID
        {
            get { return this._intUserID; }
            set { this._intUserID = value; }
        }

        public Int64 DriverUserID
        {
            get { return this._intDriverUserID; }
            set { this._intDriverUserID = value; }
        }

        public Int64 LocationMasterIDTo
        {
            get { return this._intLocationMasterIDTo; }
            set { this._intLocationMasterIDTo = value; }
        }

        public Int64 LocationMasterIDFrom
        {
            get { return this._intLocationMasterIDFrom; }
            set { this._intLocationMasterIDFrom = value; }
        }

        public string? PickLocationLatitude
        {
            get { return this._strPickLocationLatitude; }
            set { this._strPickLocationLatitude = value; }
        }

        public string? PickLocationLongitude
        {
            get { return this._strPickLocationLongitude; }
            set { this._strPickLocationLongitude = value; }
        }

        public string? DropLocationLatitude
        {
            get { return this._strDropLocationLatitude; }
            set { this._strDropLocationLatitude = value; }
        }

        public string? DropLocationLongitude
        {
            get { return this._strDropLocationLongitude; }
            set { this._strDropLocationLongitude = value; }
        }

        public string? DriverLocationLatitudeOnBooking
        {
            get { return this._strDriverLocationLatitudeOnBooking; }
            set { this._strDriverLocationLatitudeOnBooking = value; }
        }

        public string? DriverLocationLongitudeOnBooking
        {
            get { return this._strDriverLocationLongitudeOnBooking; }
            set { this._strDriverLocationLongitudeOnBooking = value; }
        }

        public string? JourneyStartDateTime
        {
            get { return this._strJourneyStartDateTime; }
            set { this._strJourneyStartDateTime = value; }
        }

        public string? JourneyEndDateTime
        {
            get { return this._strJourneyEndDateTime; }
            set { this._strJourneyEndDateTime = value; }
        }

        public string? VerificationCode
        {
            get { return this._strVerificationCode; }
            set { this._strVerificationCode = value; }
        }

        public byte JourneyStatus
        {
            get { return this._bytJourneyStatus; }
            set { this._bytJourneyStatus = value; }
        }

        public string? JourneyStatusDateTime
        {
            get { return this._strJourneyStatusDateTime; }
            set { this._strJourneyStatusDateTime = value; }
        }

        public string? UserRequestDatetime
        {
            get { return this._strUserRequestDatetime; }
            set { this._strUserRequestDatetime = value; }
        }

        public byte? StatusId
        {
            get { return this._bytStatusId; }
            set { this._bytStatusId = value; }
        }

        public DateTime? CreatedDate
        {
            get { return this._datCreatedDate; }
            set { this._datCreatedDate = value; }
        }

        public DateTime? UpdatedDate
        {
            get { return this._datUpdatedDate; }
            set { this._datUpdatedDate = value; }
        }

        public Int64 RowNumber { get; set; }
        public Int64 ActionUserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? VehicleNo { get; set; }
        public string? DropLocation { get; set; }
        public string? PickupLocation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? DriverName { get; set; }

        public string? ActionBy { get; set; }

        #endregion Properties
    }
}