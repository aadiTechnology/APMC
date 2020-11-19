using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Filters
{
    public sealed class Helper
    {
        protected static Random random = new Random();

        public Helper()
        {
        }

        public static string GenerateExceptionLogMessage(Exception ex)
        {
            var message = new StringBuilder();
            message.AppendLine(ex.Message);
            message.AppendLine(ex.StackTrace);
            message.AppendLine(ex.ToString());

            if (ex.InnerException != null)
            {
                message.AppendLine("Inner Exception");
                message.AppendLine(ex.InnerException.Message);
                message.AppendLine(ex.InnerException.StackTrace);

                if (ex.InnerException.InnerException != null)
                {
                    message.AppendLine("Second Level Inner Exception");
                    message.AppendLine(ex.InnerException.InnerException.Message);
                    message.AppendLine(ex.InnerException.InnerException.StackTrace);
                }
            }
            return message.ToString();
        }
    }
}
