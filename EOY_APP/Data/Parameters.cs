﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOY_APP.Data
{
    class Parameters
    {
        public int port = 7106;

        public string GetApiAdress()
        {
            string ApiAdress;
            return ApiAdress = $"https://localhost:{port}";



        }
    }
}