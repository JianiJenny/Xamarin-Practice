using FCBHXamarinMy.Models.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCBHXamarinMy.Models
{
    class BibleBook: ValueObject
    {
        public BookName BookName;
        public List<Chapter> Chapters;
        public enum Testament
        {
            NT = 1,
            OT = 2,
            Unknown
        }

        public BibleBook()
        {

        }
    }
}
