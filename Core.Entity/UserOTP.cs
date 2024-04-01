using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class UserOTP
    {
        #region Declarations

        private bool _boolObjectChanged;
        private int _intID;
        private int _intUserID;
        private string _strMobileNo;
        private string _strOTP;
        private DateTime _datExpiryDate;
        private byte _bytStatusID;
        private DateTime _datCreatedDate;
        private DateTime _datUpdatedDate;

       // public string? FCMToken { get; set; }

        
        public string? UserApiKey { get; set; }

        #endregion Declarations

        #region Properties

        public bool ObjectChanged
        {
            get { return this._boolObjectChanged; }
            set { this._boolObjectChanged = value; }
        }

        public int ID
        {
            get { return this._intID; }
            set { this._intID = value; }
        }

        public int UserID
        {
            get { return this._intUserID; }
            set { this._intUserID = value; }
        }

        public string MobileNo
        {
            get { return this._strMobileNo; }
            set { this._strMobileNo = value; }
        }

        public string OTP
        {
            get { return this._strOTP; }
            set { this._strOTP = value; }
        }

        public DateTime ExpiryDate
        {
            get { return this._datExpiryDate; }
            set { this._datExpiryDate = value; }
        }

        public byte StatusID
        {
            get { return this._bytStatusID; }
            set { this._bytStatusID = value; }
        }

        public DateTime CreatedDate
        {
            get { return this._datCreatedDate; }
            set { this._datCreatedDate = value; }
        }

        public DateTime UpdatedDate
        {
            get { return this._datUpdatedDate; }
            set { this._datUpdatedDate = value; }
        }

        public Int64 RowNumber { get; set; }

        public int? RoleID { get; set; }
        public int? KYCStatus { get; set; }

        #endregion Properties
    }
}
