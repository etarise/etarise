using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class PersonController : Controller  // person controller containing application logic
    {
        [HttpGet]
        public IActionResult Index() //get action takes user to the form to capture details
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person person) // post action result receives object person from the view
        {
            // file and file path  declaration
            string TextFile = "Data.json";
            string path = @"c:\\MyWebTest\\";
            string Filepath = path + TextFile;

            //converting the posted person object data to json using the JsonConvert.SerializeObject  method from the json namespace
            string json = JsonConvert.SerializeObject("First Name ===> "+ person.FirstName +"  "+ "Last Name ===> "+ person.LastName);

           
           
            // create path to write our json object  if it does not exist 
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(path);

            }else
            {
               // write our json object to file 
                System.IO.File.WriteAllText(Filepath, json);
            }

            return View();
        }

    }
}
