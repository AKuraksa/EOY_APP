using IDLoginEOY_APP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOY_WEBapp.Data
{
    class EOY_Functions
    {
        private const int apiPort = 7106;
       
        public string GetApiAdress(string ControllerName, int method)
        {
            string ApiAdress;
            return ApiAdress = $"https://localhost:{apiPort}{Route(ControllerName, method)}";

        }
        private string Route(string ControllerName, int method)
        {
            string Route = $"/api/{ControllerName}/{ControllerName}/{SwitchMethod(method)}";
            return Route;
        }
        private static string SwitchMethod(int method)
        {
            switch (method)
            {
                case EOY_Values.GET:
                    {
                        string get = "Get";
                        return get;
                        break;
                    }
                case EOY_Values.POST:
                    {
                        string post = "Post";
                        return post;
                        break;
                    }
                case EOY_Values.PATCH:
                    {
                        string patch = "Patch";
                        return patch;
                        break;
                    }
                case EOY_Values.DELETE:
                    {
                        string delete = "Delete";
                        return delete;
                        break;
                    }
                case EOY_Values.PUT:
                    {
                        string put = "Put";
                        return put;
                        break;
                    }
                default:
                    return null;
            }
        }
        public string MacFormatingString(string input)
        {
            // Vytvoříme StringBuilder pro vytvoření výstupního řetězce
            StringBuilder output = new StringBuilder();

            // Projdeme vstupní řetězec po dvou znacích a přidáme je do výstupu s pomlčkou
            for (int i = 0; i < input.Length; i += 2)
            {
                output.Append(input.Substring(i, 2));
                if (i < input.Length - 2)
                {
                    output.Append("-");
                }
            }

            return output.ToString();
        }
    }
}