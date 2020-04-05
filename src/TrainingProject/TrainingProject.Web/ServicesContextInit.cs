using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Web
{
    public class ServicesContextInit
    {
        public static void Init(ServicesContext context)
        {
            if (!context.Orders.Any())
            {
                context.UserTypes.Add(new UserType
                {
                    Name = "Admin",
                    id_userType = 1
                }) ;
                context.UserTypes.Add(new UserType
                {
                    Name = "Orderer",
                    id_userType = 2
                });
                context.UserTypes.Add(new UserType
                {
                    Name = "Performer",
                    id_userType=3
                });
                context.SaveChanges();
            }
        }
    }
}
