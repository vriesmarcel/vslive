using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.iOS.PartialDemo
{
    public partial class SharedAPI
    {
        partial void InternalSayHello()
        {
            sharedState = "Hello Android";
        }
    }
}
