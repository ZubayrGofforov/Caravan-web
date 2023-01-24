using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Common.Attributes
{
    public class IdentitySingelton
        {
         public long userId { get; set; }
         public long updateId { get; set; }

         private static IdentitySingelton _instance;
         private static IdentitySingelton _updateId;

         public IdentitySingelton()
         {

         }

          public static void SaveId(long id)
          {
                if (_instance == null)
                {
                    _instance = new IdentitySingelton();
                    _instance.userId = id;
                }
          }

            public static IdentitySingelton currentId()
            {
                return _instance;
            }

            public static void SaveUpdateId(long id)
            {
                _updateId = new IdentitySingelton();
                _updateId.updateId = id;
            }

            public static IdentitySingelton UpdateId()
            {
                return _updateId;
            }
        }
}
