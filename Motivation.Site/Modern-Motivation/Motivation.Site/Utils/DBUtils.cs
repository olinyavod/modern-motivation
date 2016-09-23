using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRent.Web.Utils
{
    public class DBUtils
    {
        private const int DEFAULT_TIMEOUT = 30;
        public static string PortalConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MotivationDb"].ConnectionString;
            }
        }

        /// <summary>
        /// Создает новый объект соединения с базой портала. 
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(PortalConnectionString);
        }

        /// <summary>
        /// Чтение данных из БД. При этом тип запроса = CommandType.Text
        /// </summary>
        /// <typeparam name="TResult">возвращаемый тип</typeparam>
        /// <param name="query">текст запроса</param>
        /// <param name="parameters">параметры запроса</param>
        /// <returns></returns>
        public static TResult ReadValue<TResult>(string query, params SqlParameter[] parameters)
        {
            return ReadValue<TResult>(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Чтение данных из БД.
        /// </summary>
        /// <typeparam name="TResult">возвращаемый тип</typeparam>
        /// <param name="query">текст запроса</param>
        /// <param name="commandType">тип запроса</param>
        /// <param name="parameters">параметры запроса</param>
        /// <returns></returns>
        public static TResult ReadValue<TResult>(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                return ReadValue<TResult>(query, commandType, DEFAULT_TIMEOUT, parameters);
            }
            else
            {
                return ReadValue<TResult>(query, commandType, DEFAULT_TIMEOUT, null);
            }
        }

        /// <summary>
        /// Чтение данных из БД.
        /// </summary>
        /// <typeparam name="TResult">возвращаемый тип</typeparam>
        /// <param name="query">текст запроса</param>
        /// <param name="commandType">тип запроса</param>
        /// <param name="commandTimeout">допустимая длительность запроса</param>
        /// <param name="parameters">параметры запроса</param>
        /// <returns></returns>
        public static TResult ReadValue<TResult>(string query, CommandType commandType, int commandTimeout, params SqlParameter[] parameters)
        {
            using (SqlConnection con = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = commandType;

                if (cmd.CommandTimeout != commandTimeout)
                {
                    cmd.CommandTimeout = commandTimeout;
                }

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();

                if (typeof(TResult) == typeof(DataSet))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    return (TResult)((object)ds);
                }
                else if (typeof(TResult) == typeof(DataTable))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    return (TResult)((object)dt);
                }
                else if (typeof(TResult) == typeof(DataRow))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return (TResult)((object)dt.Rows[0]);
                    }
                    else
                    {
                        return (TResult)((object)null);
                    }
                }
                else if (typeof(TResult) == typeof(String))
                {
                    object commandResult = cmd.ExecuteScalar();

                    if (commandResult == null || commandResult.Equals(DBNull.Value))
                    {
                        return (TResult)((object)null);
                    }

                    return (TResult)commandResult;
                }
                else
                {
                    return (TResult)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Выполнение запроса без возврата данных.
        /// </summary>
        /// <param name="query">текст запроса</param>
        /// <param name="commandType">тип запроса</param>
        /// <param name="commandTimeout">Таймаут</param>
        /// <param name="parameters">параметры запроса</param>
        public static void ExecuteNonQuery(string query, CommandType commandType, int commandTimeout, params SqlParameter[] parameters)
        {
            using (SqlConnection con = CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = commandType;
                    cmd.CommandTimeout = commandTimeout;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Выполнение запроса без возврата данных.
        /// </summary>
        /// <param name="query">текст запроса</param>
        /// <param name="commandType">тип запроса</param>
        /// <param name="parameters">параметры запроса</param>
        public static void ExecuteNonQuery(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            ExecuteNonQuery(query, commandType, DEFAULT_TIMEOUT, parameters);
        }

        /// <summary>
        /// Выполнение запроса без возврата данных.
        /// </summary>
        /// <param name="query">текст запроса</param>
        /// <param name="parameters">параметры запроса</param>
        public static void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Чтениеиз БД значения, которое может быть null.
        /// </summary>
        /// <typeparam name="TResult">тип возвращаемого значения</typeparam>
        /// <param name="query">запрос</param>
        /// <param name="commandType">Тип команды</param>
        /// <param name="parameters">параметр команды</param>
        /// <returns></returns>
        public static TResult? ReadNullableValue<TResult>(string query, CommandType commandType, params SqlParameter[] parameters) where TResult : struct
        {
            using (SqlConnection con = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();
                object commandResult = cmd.ExecuteScalar();
                con.Close();

                TResult? result = (commandResult == null || commandResult.Equals(DBNull.Value)) ? null : commandResult as TResult?;
                return result;
            }
        }

        public static TResult? ReadNullableValue<TResult>(string query, params SqlParameter[] parameters) where TResult : struct
        {
            return ReadNullableValue<TResult>(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Процедура заполнения любого списочного контрола.
        /// </summary>
        /// <param name="list">Название списочного контрола</param>
        /// <param name="cmd">SQL-команда заполнения списка</param>
        /// <param name="parameters">Набор SQL-параметров</param>
        public static void BindList(Control list, SqlCommand cmd, params SqlParameter[] parameters)
        {
            if (cmd.Connection == null)
            {
                cmd.Connection = CreateConnection();
            }

            cmd.Parameters.AddRange(parameters);

            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                sda.Fill(table);

                if (list is ListControl)
                {
                    ListControl listControl = list as ListControl;
                    listControl.DataSource = table;
                    listControl.DataValueField = "OptionValue";
                    listControl.DataTextField = "OptionText";
                    listControl.DataBind();
                }
                else if (list is BaseDataList)
                {
                    BaseDataList baseDataList = list as BaseDataList;
                    baseDataList.DataSource = table;
                    baseDataList.DataBind();
                }
                else if (list is Repeater)
                {
                    Repeater repeater = list as Repeater;
                    repeater.DataSource = table;
                    repeater.DataBind();
                }
                else if (list is System.Web.UI.HtmlControls.HtmlSelect)
                {
                    System.Web.UI.HtmlControls.HtmlSelect listControl = list as System.Web.UI.HtmlControls.HtmlSelect;
                    listControl.DataSource = table;
                    listControl.DataValueField = "OptionValue";
                    listControl.DataTextField = "OptionText";
                    listControl.DataBind();
                }
            }
        }

        public static void BindList(Control list, string query, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection sql = CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.CommandType = commandType;
                    BindList(list, cmd, parameters);
                }
            }
        }
        public static void BindList(Control list, string query, params SqlParameter[] parameters)
        {
            BindList(list, query, CommandType.Text, parameters);
        }

        public static SqlParameter CreateArraySqlParameter(string name, params int[] array)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(int));

            foreach (int value in array)
            {
                dt.Rows.Add(value);
            }

            return new SqlParameter { ParameterName = name, SqlDbType = SqlDbType.Structured, TypeName = "dlfe.Array", Value = dt };
        }

        /// <summary>
        /// Создает SQL-параметр типа dlfe.PeriodsList (табличный пользовательский тип)
        /// </summary>
        /// <param name="name">>Имя параметра</param>
        /// <param name="periods">Таблица с датой начала и окончания</param>
        /// <returns>SqlParameter указанного типа</returns>
        public static SqlParameter CreatePeriodsListSqlParameter(string name, DataTable periods)
        {
            DataTable periodsList = new DataTable();
            periodsList.Columns.Add("StartDate", typeof(DateTime));
            periodsList.Columns.Add("EndDate", typeof(DateTime));

            foreach (DataRow rowItem in periods.Rows)
            {
                periodsList.Rows.Add(rowItem["StartDate"], rowItem["EndDate"]);
            }

            return new SqlParameter { ParameterName = name, SqlDbType = SqlDbType.Structured, TypeName = "dlfe.PeriodsList", Value = periodsList };
        }

        /// <summary>
        /// Создает SQL-параметр типа dlfe.KeyValuePairs (табличный пользовательский тип)
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="keyValuePairs">Набор пар "ключ-значение". Булевы значения преобразуются в 0 или 1</param>
        /// <returns>SqlParameter указанного типа</returns>
        public static SqlParameter CreateKeyValuePairsSqlParameter(string name, params KeyValuePair<object, object>[] keyValuePairs)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Key", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            foreach (KeyValuePair<object, object> pair in keyValuePairs)
            {
                if (pair.Key.ToString().Length > 80)
                {
                    throw new Exception("Длина ключа не может быть более 80 символов");
                }

                DataRow row = dt.NewRow();

                row["Key"] = pair.Key;
                row["Value"] = pair.Value;

                dt.Rows.Add(row);
            }

            return new SqlParameter { ParameterName = name, SqlDbType = SqlDbType.Structured, TypeName = "dlfe.KeyValuePairs", Value = dt };
        }

        /// <summary>
        /// Создает SqlParameter из трёх аргументов, SqlDbType явно указывает к какому типу необходимо преобразовать передаваемое значение
        /// </summary>
        /// <param name="parameterName">имя параметра</param>
        /// <param name="value">значение</param>
        /// <param name="sqlDbType">тип БД, к которому необходимо преобразовать передаваемое значение</param>
        /// <returns></returns>
        public static SqlParameter CreateSqlParameter(string parameterName, object value, SqlDbType sqlDbType)
        {
            return new SqlParameter(parameterName, DBValue.Convert(value)) { SqlDbType = sqlDbType };
        }

        /// <summary>
        /// Создает SqlParameter из двух аргументов, автоматически выводит SqlDbType аналогичный типу передаваемого значения
        /// </summary>
        /// <param name="parameterName">имя параметра</param>
        /// <param name="value">значение</param>
        /// <returns></returns>
        public static SqlParameter CreateSqlParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, DBValue.Convert(value));
        }

    }
}