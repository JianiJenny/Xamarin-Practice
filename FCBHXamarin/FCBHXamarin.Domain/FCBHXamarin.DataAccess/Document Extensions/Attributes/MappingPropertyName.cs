﻿using System;

namespace FCBHXamarin.DataAccess.Document_Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MappingPropertyName : Attribute
    {
        public string Name { get; private set; }

        public MappingPropertyName(string name)
        {
            Name = name;
        }
    }
}
