using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRent.Web.Utils
{
    public static class DBValue
    {
        public static object Convert(object Value)
        {
            return Convert(Value, DBNull.Value);
        }

        public static object Convert(object Value, object NullValue)
        {
            return Value ?? NullValue;
        }
        
        /// <summary>
        /// Аналог функции NULLIF в SQL. Возвращает DBNull, если переданные значения равны, в противном случае возвращает первое значение
        /// </summary>
        /// <param name="firstValue">Первое значение</param>
        /// <param name="secondValue">Второе значение</param>
        /// <returns></returns>
        public static object NullIf<TSource>(TSource firstValue, TSource secondValue)
        {
            if (firstValue.Equals(secondValue))
            {
                return DBNull.Value;
            }
            else
            {
                return firstValue;
            }
        }

        /// <summary>
        /// Конвертация объекта БД в объект С#.
        /// Если объект эквивалентен DBNull.Value, то возвращается null, в остальных случаях - сам объект.
        /// </summary>
        /// <param name="value">Экземпляр объекта.</param>
        /// <returns>Возвращает объект, либо null (если источник DBNull.Value).</returns>
        public static object ConvertToNullable(object value)
        {
            return
                (value.Equals(DBNull.Value))
                    ? null
                    : value;
        }

        /// <summary>
        /// Конвертация объекта БД в объект С#, приведёный к типу "T".
        /// Если объект эквивалентен DBNull.Value, то возвращается null, в остальных случаях - сам объект.
        /// </summary>
        /// <typeparam name="T">Тип к которому преобразуется объект.</typeparam>
        /// <param name="value">Экземпляр объекта.</param>
        /// <returns>Возвращает объект приведённый к типу "T?", либо null (если источник DBNull.Value).</returns>
        public static T? ConvertToNullable<T>(object value) where T : struct
        {
            return
                (value.Equals(DBNull.Value))
                    ? null
                    : (value as T?);
        }
    }
}