using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Web
{
    public class AppContextInit
    {
        enum UserTypes
        {
            Admin = 1,
            Orderer,
            Performer
        }
            
        
        public static void Init(AppContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "ADmin",
                    Login = "ttt",
                    Password = "hhh",
                    IdUserType = 1
                });
                context.SaveChanges();
            }
        }
    }
}
