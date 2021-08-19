using System;
using System.Collections.Generic;
using System.Text;

namespace MTCmodel
{
    //OrderOUt:
    //===================================
    //client set order => Reserved,
    //Admin set To => Preparing,
    //Admin set to => Sent,
    //Transporter set to => Delivered,

    //OrderIn
    //===================================
    //Admin set order => Reserved, (this mean the order is in the db and the order must set to Sent by Supplier
    //Supplier set to => Sent,
    //Admin set to => Delivered,

    public enum StatusOfOrder
    {

        Reserved,

        Preparing,

        Sent, 
        

        Delivered,


        //OrderedBySupplier,
    }
}
