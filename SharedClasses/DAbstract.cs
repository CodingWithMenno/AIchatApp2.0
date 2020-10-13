using Newtonsoft.Json;
using System;

namespace SharedClasses
{
    public abstract class DAbstract
    {

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
