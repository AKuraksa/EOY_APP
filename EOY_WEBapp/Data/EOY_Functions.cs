using EOY_WEBapp.Data;
using EOY_WEBapp.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using RestSharp;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using System.Reflection;

namespace EOY_WEBapp.Data
{
    class EOY_Functions
    {
        private const int apiPort = 7106;
        private const string UrlAdress = "https://localhost:";


        public string GetApiAdress(string ControllerName, int method)
        {
            string ApiAdress;
            return ApiAdress = $"{UrlAdress}{apiPort}{Route(ControllerName, method)}";

        }
        public string UniversalApiAdress(string nameOfRoute)
        {
            string route = $"{UrlAdress}{apiPort}/{nameOfRoute}";
            return route;
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

        public async Task<List<T>> EOYrestResponse<T>(string apiControllerName, int method)
        {
            switch (method)
            {
                case EOY_Values.GET:
                    {
                        try
                        {
                            var myClient = new RestClient(GetApiAdress(apiControllerName, method));
                            var request = new RestRequest();
                            var response = await myClient.GetAsync(request);
                            var content = response.Content;
                            if (!string.IsNullOrWhiteSpace(content))
                            {
                                var objectsList = JsonSerializer.Deserialize<List<T>>(content);
                                return objectsList;
                            }
                            else
                            {
                                return new List<T>();
                            }
                        }
                        catch (Exception ex)
                        {
                            return new List<T>();
                        }
                        break;
                    }
                default: return new List<T>();




            }
        }
    }



}

