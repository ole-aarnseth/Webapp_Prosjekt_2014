using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdminDAL
    {
        Admin GetAdmin(string Email, string Password);
        Admin GetAdmin(int AdminId);
    }
}
