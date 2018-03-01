using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magacin
{
    public interface MForm
    {
        Help helpWindow { get; set; }
        M.Podesavanja.Forma InitializeForm { get; set; }
    }
}
