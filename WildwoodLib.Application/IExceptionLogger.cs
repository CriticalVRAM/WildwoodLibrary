using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Application
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
