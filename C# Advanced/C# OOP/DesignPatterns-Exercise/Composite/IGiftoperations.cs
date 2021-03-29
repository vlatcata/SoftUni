using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    interface IGiftoperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
