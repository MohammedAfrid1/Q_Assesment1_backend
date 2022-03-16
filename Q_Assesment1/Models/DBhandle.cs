using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Q_Assesment1.Models
{
    public class DBhandle
    {
       

        public List<User> getAllRecords()
        {
            EFDBhandle context = new EFDBhandle();
            List<User> listP = context.User_TB.ToList();
            return listP;
        }
        public List<Userdata> GetAllHistory()
        {
            EFDBhandle context = new EFDBhandle();
            List<Userdata> listP = context.History_TB.ToList();
            return listP;
        }
        public void UserData(Userdata c)
        {
            EFDBhandle context=new EFDBhandle();
            context.History_TB.Add(c);
            context.SaveChanges();
            return;

        }
        public void AddUser(User u)
        {
            EFDBhandle context = new EFDBhandle();
            context.User_TB.Add(u);
            context.SaveChanges();
            return;

        }
        public User Login(LoginModel data)

        {

            Response res = new Response();
            List<User> userdata = new List<User>();
            User u = new User();
            EFDBhandle context = new EFDBhandle();
            {

                u = (from a in context.User_TB
                     where a.Email == data.Email && a.Password == data.Password
                     select new User()
                     {
                         Email = a.Email,
                         Password = a.Password,
                         Name = a.Name,
                         Id = a.Id
                     }).SingleOrDefault();
               
                if (u != null)
                {
                 
                    Console.WriteLine("Access granted welcome ");
                }
                else
                {
                    Console.WriteLine("Invalid username/password");
                    res.error = false;
                    res.message = "Success";
                   
                    res.Userdata = userdata;
                    //return JsonConvert.SerializeObject(res);
                }
                return u;
            }


        }



    }
}
