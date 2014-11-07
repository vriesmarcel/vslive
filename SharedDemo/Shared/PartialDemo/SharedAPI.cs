using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.iOS.PartialDemo
{
    public partial class SharedAPI
    {
        //partial methods must return void, so we use
        // internal state of class to transfer state ....
        partial void InternalSayHello();
        string sharedState = null;
        public string SayHello()
        {
            InternalSayHello();
            return sharedState;
        }
    }
}
