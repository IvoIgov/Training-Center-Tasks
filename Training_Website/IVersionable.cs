using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Website
{
    public interface IVersionable
    {

        void UpdateVersion(int[] version);
    }
}
