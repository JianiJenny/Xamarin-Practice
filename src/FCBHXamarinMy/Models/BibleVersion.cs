using FCBHXamarinMy.Models.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCBHXamarinMy.Models
{
    class BibleVersion: IAggregateRoot
    {
        public string Id;
        public string Language;
        public int LangId;
        public string Iso;
        public string Date;

        public BibleVersion(string id, string language, int langId, string iso, string date)
        {
            Id = id;
            Language = language;
            LangId = langId;
            Iso = iso;
            Date = date;
        }


    }
}
