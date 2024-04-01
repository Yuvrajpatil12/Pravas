using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Core.Entity
{
    public class AccessMember
    {
        #region Declarations

         private bool _boolObjectChanged;
private decimal _decID;
private Int64 _intUserID;
private byte _bytRoleID;
private string _strPort;
private string _strUrl;
private string _strReferrerURL;
private string _strBrowserType;
private string _strBrowserVersion;
private string _strOperatingSystem;
private string _strDeviceType;
private string _strDeviceName;
private string _strDeviceModel;
private string _strBuild;
private string _strVersion;
private string _strHost;
private string _strRemoteHost;
private string _strRemoteAddrIP;
private string _strUserAgent;
private string _strPlatform;
private string _strClickedBy;
private byte _bytStatusID;
private DateTime? _datCreatedDate;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
 { 
    get { return this._boolObjectChanged; } 
    set { this._boolObjectChanged = value; }
 } 

 public decimal ID
 { 
    get { return this._decID; } 
    set { this._decID = value; }
 } 

 public Int64 UserID
 { 
    get { return this._intUserID; } 
    set { this._intUserID = value; }
 } 

 public byte RoleID
 { 
    get { return this._bytRoleID; } 
    set { this._bytRoleID = value; }
 } 

 public string Port
 { 
    get { return this._strPort; } 
    set { this._strPort = value; }
 } 

 public string Url
 { 
    get { return this._strUrl; } 
    set { this._strUrl = value; }
 } 

 public string ReferrerURL
 { 
    get { return this._strReferrerURL; } 
    set { this._strReferrerURL = value; }
 } 

 public string BrowserType
 { 
    get { return this._strBrowserType; } 
    set { this._strBrowserType = value; }
 } 

 public string BrowserVersion
 { 
    get { return this._strBrowserVersion; } 
    set { this._strBrowserVersion = value; }
 } 

 public string OperatingSystem
 { 
    get { return this._strOperatingSystem; } 
    set { this._strOperatingSystem = value; }
 } 

 public string DeviceType
 { 
    get { return this._strDeviceType; } 
    set { this._strDeviceType = value; }
 } 

 public string DeviceName
 { 
    get { return this._strDeviceName; } 
    set { this._strDeviceName = value; }
 } 

 public string DeviceModel
 { 
    get { return this._strDeviceModel; } 
    set { this._strDeviceModel = value; }
 } 

 public string Build
 { 
    get { return this._strBuild; } 
    set { this._strBuild = value; }
 } 

 public string Version
 { 
    get { return this._strVersion; } 
    set { this._strVersion = value; }
 } 

 public string Host
 { 
    get { return this._strHost; } 
    set { this._strHost = value; }
 } 

 public string RemoteHost
 { 
    get { return this._strRemoteHost; } 
    set { this._strRemoteHost = value; }
 } 

 public string RemoteAddrIP
 { 
    get { return this._strRemoteAddrIP; } 
    set { this._strRemoteAddrIP = value; }
 } 

 public string UserAgent
 { 
    get { return this._strUserAgent; } 
    set { this._strUserAgent = value; }
 } 

 public string Platform
 { 
    get { return this._strPlatform; } 
    set { this._strPlatform = value; }
 } 

 public string ClickedBy
 { 
    get { return this._strClickedBy; } 
    set { this._strClickedBy = value; }
 } 

 public byte StatusID
 { 
    get { return this._bytStatusID; } 
    set { this._bytStatusID = value; }
 } 

 public DateTime? CreatedDate
 { 
    get { return this._datCreatedDate; } 
    set { this._datCreatedDate = value; }
 } 



        #endregion Properties
    }
}
