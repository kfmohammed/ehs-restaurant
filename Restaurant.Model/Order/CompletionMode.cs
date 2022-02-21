using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Restaurant.Model
{
    public enum CompletionMode
    {
        [Description("Collection")]
        Collection = 1,
        [DescriptionAttribute("Delivery")]
        Delivery = 2
    }
}
