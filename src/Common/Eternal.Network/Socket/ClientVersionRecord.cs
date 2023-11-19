using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternal.Network.Socket
{
    public record ClientVersionRecord(string Version, short Patch, ClientLocale Locale)
    {
    }
}
