using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClass
{
    public abstract class DAbstract
    {

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
