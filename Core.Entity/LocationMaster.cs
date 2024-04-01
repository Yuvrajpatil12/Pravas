using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Core.Entity
{
    public class LocationMaster
    {
        #region Declarations

         private bool _boolObjectChanged;
private int _intID;
private int _intCompanyID;
private string _strLocationName;
private string _strLocationLatitude;
private string _strLocationLongitude;
private byte _bytStatusId;
private DateTime _datCreatedDate;
private DateTime _datUpdatedDate;


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

 public int CompanyID
 { 
    get { return this._intCompanyID; } 
    set { this._intCompanyID = value; }
 } 

 public string LocationName
 { 
    get { return this._strLocationName; } 
    set { this._strLocationName = value; }
 } 

 public string LocationLatitude
 { 
    get { return this._strLocationLatitude; } 
    set { this._strLocationLatitude = value; }
 } 

 public string LocationLongitude
 { 
    get { return this._strLocationLongitude; } 
    set { this._strLocationLongitude = value; }
 } 

 public byte StatusId
 { 
    get { return this._bytStatusId; } 
    set { this._bytStatusId = value; }
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



        #endregion Properties
    }
}
