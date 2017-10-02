using System;

namespace Nutrimeal.Common
{
    public static class EnumExtentions
    {
        public static string ConvertToString(this Enum eff)
        {

            return Enum.GetName(eff.GetType(), eff);

        }

        public static string ConvertToStringUnderscore(this Enum eff)
        {

            return (Enum.GetName(eff.GetType(), eff).Replace('_','-'));

        }
    }
}