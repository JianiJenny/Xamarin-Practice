using FCBHXamarinMy.Models.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCBHXamarinMy.Models
{
    class Bible: ValueObject
    {
        public int Id;
        public List<BibleBook> Books;

        public Bible()
        {

        }
    }
}
