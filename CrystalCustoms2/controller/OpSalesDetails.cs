using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalCustoms2.model;
using CrystalCustoms2.common;
using System.Data.SQLite;

namespace CrystalCustoms2.controller
{
    class OpSaleDetails
    {
        public static String tableName = "sales_details";
        public static String fkName = "sales_detail_id";
        public static String[] fieldNames = {
            "sales_detail_id",
            "sales_id",
            "sales_detail_name",
            "sales_detail_type",
            "sales_detail_amount",
            "sales_detail_datetime"
        };

        // get last row number
        public static int GetLastNumber()
        {
            int last_num = 0;

            try
            {
                using (SQLiteConnection conn = DBUnit.conn())
                {
                    conn.Open();
                    string sql = "SELECT MAX(" + fkName + ") AS LASTNUM FROM " + tableName;
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                last_num = Int32.Parse(reader["LASTNUM"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SQLiteException e)
            {
                // exception code
            }

            return last_num;
        }

        // get item
        public static List<SalesDetails> GetItems(int rowId)
        {
            List<SalesDetails> QueryItems = new List<SalesDetails>();
            try
            {
                using (SQLiteConnection conn = DBUnit.conn())
                {
                    conn.Open();
                    string sql = "SELECT * FROM " + tableName + " WHERE " + fkName + " = " + rowId;

                    if (rowId == 0)
                    {
                        sql = "SELECT * FROM " + tableName;
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SalesDetails st = new SalesDetails();
                                st.SalesDetailId = Int32.Parse(reader["sales_detail_id"].ToString());
                                st.SalesId = Int32.Parse(reader["sales_id"].ToString());
                                st.SalesDetailName = reader["sales_detail_name"].ToString();
                                st.SalesDetailType = reader["sales_detail_name"].ToString();
                                st.SalesDetailAmount = reader["sales_detail_amount"].ToString();
                                st.SalesDetailDatetime = DateTime.Parse(reader["selas_detail_datetime"].ToString());
                                QueryItems.Add(st);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                // exception code
            }
            return QueryItems;
        }

        // update item
        public static int UpdateItem(SalesDetails st)
        {
            int result = -1;
            using (SQLiteConnection conn = DBUnit.conn())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    String fieldsGlued1 = "";
                    for (int i = 0; i < fieldNames.Length; i++)
                    {
                        fieldsGlued1 += fieldNames[i] + " = '@" + fieldNames[i] + "'";

                        if (i < fieldNames.Length - 1)
                        {
                            fieldsGlued1 += ",";
                        }
                    }

                    cmd.CommandText = "UPDATE " + tableName + " SET " + fieldsGlued1
                        + " WHERE " + fkName + " = @" + fkName;
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@sales_detail_id", st.SalesDetailId);
                    cmd.Parameters.AddWithValue("@sales_id", st.SalesId);
                    cmd.Parameters.AddWithValue("@sales_detail_name", st.SalesDetailName);
                    cmd.Parameters.AddWithValue("@sales_detail_type", st.SalesDetailType);
                    cmd.Parameters.AddWithValue("@sales_detail_datetime", st.SalesDetailDatetime);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException)
                    {
                        // ... something code ....
                    }
                }
                conn.Close();
            }
            return result;
        }

        // insert item
        public static int AddItem(SalesDetails st)
        {
            int result = -1;

            List<string> defineFields = new List<string>();
            string[] defineFields1 = { };
            string[] defineFields2 = { };

            defineFields1 = fieldNames;
            foreach (string fieldName in fieldNames)
            {
                defineFields.Add("@" + fieldName);
            }
            defineFields2 = defineFields.ToArray();

            String fieldsGlued1 = String.Join(",", defineFields1);
            String fieldsGlued2 = String.Join(",", defineFields2); // prepareSQL

            using (SQLiteConnection conn = DBUnit.conn())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO " + tableName + "(" + fieldsGlued1 + ") VALUES (" + fieldsGlued2 + ")";
                    cmd.Prepare();

                    // new row number
                    st.SalesDetailId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@sales_detail_id", st.SalesDetailId);
                    cmd.Parameters.AddWithValue("@sales_id", st.SalesId);
                    cmd.Parameters.AddWithValue("@sales_detail_name", st.SalesDetailName);
                    cmd.Parameters.AddWithValue("@sales_detail_type", st.SalesDetailType);
                    cmd.Parameters.AddWithValue("@sales_detail_datetime", st.SalesDetailDatetime);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        // ... something code ....
                    }
                }
                conn.Close();
            }
            return result;
        }

        // delete item
        public static int DeleteItem(int rowId)
        {
            int result = -1;
            using (SQLiteConnection conn = DBUnit.conn())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "DELETE FROM " + tableName + " WHERE " + fkName + " = @row_id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@row_id", rowId);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        // ... something code ....
                    }
                }
                conn.Close();
            }
            return result;
        }
    }
}
