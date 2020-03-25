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
                  Name="Admin"
                });
                context.UserTypes.Add(new UserType
                {
                    Name = "Orderer"
                });
                context.UserTypes.Add(new UserType
                {
                    Name = "Performer"
                });
                context.SaveChanges();
            }
        }
    }
}
