﻿using System;
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
            if (!context.Orders.Any())
            {
                context.UserTypes.Add(new UserType
                {
                    Name = "Admin",
                    IdUserType = (int)UserTypes.Admin
                }) ;
                context.UserTypes.Add(new UserType
                {
                    Name = "Orderer",
                    IdUserType = (int)UserTypes.Orderer
                });
                context.UserTypes.Add(new UserType
                {
                    Name = "Performer",
                    IdUserType = (int)UserTypes.Performer
                });
                context.SaveChanges();
            }
        }
    }
}