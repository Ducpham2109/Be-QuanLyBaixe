using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.EmailReponsitory
{
    public interface IEmailService
    {
        Task ForgotPassWordAsync(string toEmail, string body);

    }
}
