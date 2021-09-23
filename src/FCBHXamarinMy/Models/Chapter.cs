using FCBHXamarinMy.Models.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCBHXamarinMy.Models
{
    class Chapter : ValueObject
    {
        public int Number;
        public List<Verse> Verses;
    }
}
