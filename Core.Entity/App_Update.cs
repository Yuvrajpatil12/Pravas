using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Core.Entity
{
    public class App_Update
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;

        private byte _bytIsUpdate;
        private string? _strBuild;
        private string? _strVersion;
        private byte _bytAppType;
        private int _intErrorCode;
        private DateTime _datCreatedDate;
        private DateTime _datServerDate;
        private DateTime _datUpdateDate;
        private byte _bytStatusId;


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

    

        public byte IsUpdate
         { 
            get { return this._bytIsUpdate; } 
            set { this._bytIsUpdate = value; }
         } 

         public string? Build
         { 
            get { return this._strBuild; } 
            set { this._strBuild = value; }
         } 

         public string? Version
         { 
            get { return this._strVersion; } 
            set { this._strVersion = value; }
         } 

         public byte AppType
         { 
            get { return this._bytAppType; } 
            set { this._bytAppType = value; }
         } 

         public int ErrorCode
         { 
            get { return this._intErrorCode; } 
            set { this._intErrorCode = value; }
         } 

         public DateTime CreatedDate
         { 
            get { return this._datCreatedDate; } 
            set { this._datCreatedDate = value; }
         }  
         public DateTime ServerDate
         { 
            get { return this._datServerDate; } 
            set { this._datServerDate = value; }
         } 

         public DateTime UpdateDate
         { 
            get { return this._datUpdateDate; } 
            set { this._datUpdateDate = value; }
         } 

         public byte StatusId
         { 
            get { return this._bytStatusId; } 
            set { this._bytStatusId = value; }
         }

        //PRATIK 12/JAN/2022
        public Int64 RowNumber { get; set; }

        #endregion Properties
    }
}
