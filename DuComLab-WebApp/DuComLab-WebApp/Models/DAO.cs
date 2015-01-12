using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BusinessLayer
{
   public  class DAO
    {
       protected string connectionString = ConfigurationManager.ConnectionStrings["DuComLab"].ConnectionString;
    }
}
