using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    static class Tools  //static utility class
    {
        /// <summary>
        /// An extension method which prints each entity's properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name +
            ": " + item.GetValue(t, null);
            return str;
        }

        //static class Tools
        //{
        //    internal static string ToStringProperty<T>(T t)
        //    {
        //        string str = "";
        //        foreach (PropertyInfo item in t.GetType().GetProperties())
        //            str += "\n" + item.Name
        //            + ": " + item.GetValue(t, null);
        //        return str;
        //    }
        //}
    }
