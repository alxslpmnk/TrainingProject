using System.Collections.Generic;
using System.Linq;
using TrainingProject.Data.Models;

namespace TrainingProject.Web
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> GetWithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.GetUserInfo());
        }

        public static User GetUserInfo(this User user) {
            user.Password = null;
            return user;
        }
    }
}