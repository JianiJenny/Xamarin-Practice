﻿using FCBHXamarin.DataAccess.Document_Extensions.Converters;

namespace FCBHXamarin.DataAccess.Document_Extensions
{
    public static class Settings
    {
        static IPropertyNameConverter _propertyNameConverter;
        public static IPropertyNameConverter PropertyNameConverter
        {
            get => _propertyNameConverter;
            set => _propertyNameConverter = value;
        }
    }
}