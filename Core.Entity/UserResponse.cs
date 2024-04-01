using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class UserResponse
    {
        public Int64 ID { get; set; }       
        public string UserLastLatitude { get; set; }
        public string UserLastLongitude { get; set; }
        public string UserLastLocation { get; set; }
        
    }
}
