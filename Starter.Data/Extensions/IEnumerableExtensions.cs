using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Starter.Data.Extensions
{
    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            Type tOb2 = objectTo.GetType();
            tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue);
        }
    }

    public static class IENumerableExtensions
    {
        public static IEnumerable<T> FromDataReader<T>(this IEnumerable<T> list, DbDataReader dr)
        {
            //Instance reflec object from Reflection class coded above
            Reflection reflec = new Reflection();
            //Declare one "instance" object of Object type and an object list
            Object instance;
            List<Object> lstObj = new List<Object>();

            //dataReader loop
            while (dr.Read())
            {
                //Create an instance of the object needed.
                //The instance is created by obtaining the object type T of the object
                //list, which is the object that calls the extension method
                //Type T is inferred and is instantiated
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);

                // Loop all the fields of each row of dataReader, and through the object
                // reflector (first step method) fill the object instance with the datareader values
                foreach (DataRow drow in dr.GetSchemaTable().Rows)
                {
                    reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()] == DBNull.Value ? null : dr[drow.ItemArray[0].ToString()]);
                }

                //Add object instance to list
                lstObj.Add(instance);
            }

            List<T> lstResult = new List<T>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((T)Convert.ChangeType(item, typeof(T)));
            }

            return lstResult;
        }
    }
}
