using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Core.Entity
{
    public class AppUpdate
    {
        #region Declarations

         private bool _boolObjectChanged;
private int _intID;
private string _strVersion;
private string _strBuild;
private byte _bytAppType;
private byte _bytIsUpdate;
private int _intErrorCode;
private byte _bytStatusId;
private DateTime _datCreatedDate;
private DateTime _datUpdateDate;


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

 public string Version
 { 
    get { return this._strVersion; } 
    set { this._strVersion = value; }
 } 

 public string Build
 { 
    get { return this._strBuild; } 
    set { this._strBuild = value; }
 } 

 public byte AppType
 { 
    get { return this._bytAppType; } 
    set { this._bytAppType = value; }
 } 

 public byte IsUpdate
 { 
    get { return this._bytIsUpdate; } 
    set { this._bytIsUpdate = value; }
 } 

 public int ErrorCode
 { 
    get { return this._intErrorCode; } 
    set { this._intErrorCode = value; }
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

 public DateTime UpdateDate
 { 
    get { return this._datUpdateDate; } 
    set { this._datUpdateDate = value; }
 } 



        #endregion Properties
    }
}
