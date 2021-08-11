using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public enum TDSreposErrCode
    {
        OK = 0,
        NOTFOUND = 1,
        DUPLICATE_KEY = 2,
        FOREIGNKEY_CONFLICT = 4,


        //als er nog fouten bekend geraken, dan hierboven setten, 
        //(machten van 2 gebruiken)

        WRONG_ARGUMENTTYPE = (int)0b_0010_0000_0000_0000_0000_0000_0000_0000,
        UNKNOW_ERROR = (int)0b_0100_0000_0000_0000_0000_0000_0000_0000,

    }
}
