using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOY_WEBapp.Data
{
    class Parameters
    {
        public int port = 7086;

        public string GetApiAdress()
        {
            string ApiAdress;
            return ApiAdress = $"https://localhost:{port}";



        }
    }
}