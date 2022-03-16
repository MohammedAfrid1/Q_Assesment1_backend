using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q_Assesment1.Models
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
   [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly IMailService _mailService;
        public WebApiController(IMailService mailService)
        {
            this._mailService = mailService;
        }

        // GET: api/<WebApiController>
        [HttpGet]
        public string Get()
        {
            DBhandle db = new DBhandle();
            List<User> listP = db.getAllRecords();
            return JsonConvert.SerializeObject(listP);

        }
       

        [HttpPost]
        [Route("Store")]
        public void Post(Userdata c)
        {
            DBhandle db = new DBhandle();
            db.UserData(c);
         
            return;
            
        }
        [HttpPost]
        [Route("AddUser")]
        public void Send(User u)
        {
            DBhandle db = new DBhandle();
            db.AddUser(u);

            return;

        }
        [HttpPost]
        [Route("Login")]
        public User Login(LoginModel value)
        {
            User u = new User();
            DBhandle db=new DBhandle();
            

            u= db.Login(value);
            return u;
        }







        [HttpPost]
        [Route("Send")]
        public void SendEmailAsync(MailRequest data)
        {
   
           // Maildata data=new Maildata();
            data.ToEmail= data.Userdata.selectedmails;
            data.Subject = "Zoom Meeting";
            var x = data.Email;
            data.Body ="Afrid invited you to join the meet on " + data.Userdata.mydate + " on this time " + data.Userdata.mytime +
                " Meeting link:https://support.zoom.us/hc/en-us/articles/201362413-Scheduling-meetings";


            try { 
              
                  _mailService.SendEmailAsync(data);
               
              }
              catch (Exception)
              {
                  throw;
              }

            //Console.WriteLine(obj.Mail);

           /* List<Userdata> u=new List<Userdata>();
            foreach (var list in u)
            {
                Userdata da = new Userdata();
                da.selectedmails = data.selectedmails;
                da.mydate = data.mydate;
                da.mytime = data.mytime;
                u.Add(da);



            }*/
          

            // Console.WriteLine(data.selectedmails);
            //  Console.WriteLine(data.mydate);
            //  Console.WriteLine(data.mytime);
        }
        [HttpGet]
        [Route("History")]
        public string get()
        {
            DBhandle db = new DBhandle();
            List<Userdata> listP = db.GetAllHistory();
            return JsonConvert.SerializeObject(listP);

        }

    }
   
}
