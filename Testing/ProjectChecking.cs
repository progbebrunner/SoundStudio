using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class ProjectChecking
    {
        public static bool ValidateUser(string username, string password)
        {
            if (username == "" || password == "") {  return false; }
            else { return true; }
        }

        public static bool BtnCheck(bool btn_click)
        {
            if (!btn_click) { return false; } else { return true; }
        }

        public static bool ValidateQuantity(string quantuty)
        {
            if(int.TryParse(quantuty, out int q)) { return true; } else { return false;}
        }
    }
}
