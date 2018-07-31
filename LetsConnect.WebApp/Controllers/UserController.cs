using LetsConnect.DBContext;
using LetsConnect.Entities.Models;
using LetsConnect.Models;
using LetsConnect.Service.Services;
using LetsConnect.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web.Http;

namespace LetsConnect.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {        
        IUserService _userService;
        IUserTechnologiesServices _userTechnologiesService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
            //this._userTechnologiesService = userTechnologiesServices;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {           
            return _userService.GetAllUsers();
        }
      
        [HttpGet]
        [Route("{id:int}")]
        public User GetUserByUserId(int id)
        {
            return _userService.GetUserByUserId(id);
        }
       
        [HttpPost]
        public HttpResponseMessage SaveUserDetails([FromBody] User objUser)
        {           
            try
            {
                objUser.ModifiedOn = DateTime.Now;//.ParseExact(objUser.ModifiedOn.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objUser.CreatedOn = DateTime.Now;// (objUser.CreatedOn.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _userService.SaveUserDetails(objUser);
                //userTechnologiesService.SaveUserTechnologiesDetails(objUser.Technology);
                var message = new HttpResponseMessage(HttpStatusCode.Created);
                return message;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return message;
            }
   
        }
        
        [HttpPut]
        public void UpdateUserDetails([FromBody] User objUser)
        {
            _userService.UpdateUserDetails(objUser);
        }
      
        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteUserDetails(int id)
        {
            _userService.DeleteUserDetails(id);
        }

        [HttpPost]
        public HttpResponseMessage UploadProfileImage([FromBody] FileUpload file)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string path = @"C:\Practice_Project\LetsConnectWeb\LetsConnect\LetsConnect.WebApp\Documents\Images\";
                string extension = file.FileName.Split('.')[1];
                if (extension !="jpeg"&& extension!="png"&& extension!="jpg")
                {
                    path = @"C:\Practice_Project\LetsConnectWeb\LetsConnect\LetsConnect.WebApp\Documents\Resumes\";
                }
                string fileNameWitPath = path + file.FileName;
                //chekc if directory exist, if not, create
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(file.FileContent);
                        bw.Write(data);
                        bw.Close();
                    }
                }
                var message = new HttpResponseMessage(HttpStatusCode.OK);
                return message;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return message;
            }
            
        }

    }
}
