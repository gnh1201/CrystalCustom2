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
    class OpStockItemHistory
    {
        public static String tableName = "stock_item_history";
        public static String fkName = "stock_item_history_id";
        public static String[] fieldNames = {
            "stock_item_history_id",
            "stock_item_id",
            "stock_history_id",
            "stock_item_history_name",
            "stock_item_history_type",
            "stock_item_history_change",
            "stock_item_history_datetime"
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
        public static List<StockItemHistory> GetItems(int rowId)
        {
            List<StockItemHistory> QueryItems = new List<StockItemHistory>();
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
                                StockItemHistory st = new StockItemHistory();
                                st.StockItemHistoryId = Int32.Parse(reader["stock_item_history"].ToString());
                                st.StockItemId = Int32.Parse(reader["stock_item_id"].ToString());
                                st.StockHistoryId = Int32.Parse(reader["stock_history_id"].ToString());
                                st.StockItemHistoryType = reader["stock_item_history_type"].ToString();
                                st.StockItemHistoryChange = Int32.Parse(reader["stock_item_history_change"].ToString());
                                st.StockItemHistoryDatetime = DateTime.Parse(reader["stock_item_history_datetime"].ToString());
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
        public static int UpdateItem(StockItemHistory st)
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

                    cmd.Parameters.AddWithValue("@stock_item_history_id", st.StockItemHistoryId);
                    cmd.Parameters.AddWithValue("@stock_item_id", st.StockItemId);
                    cmd.Parameters.AddWithValue("@stock_history_id", st.StockHistoryId);
                    cmd.Parameters.AddWithValue("@stock_item_history_name", st.StockItemHistoryName);
                    cmd.Parameters.AddWithValue("@stock_item_history_type", st.StockItemHistoryType);
                    cmd.Parameters.AddWithValue("@stock_item_history_change", st.StockItemHistoryChange);
                    cmd.Parameters.AddWithValue("@stock_item_history_datetime", st.StockItemHistoryDatetime);

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
        public static int AddItem(StockItemHistory st)
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
                    st.StockItemHistoryId = GetLastNumber() + 1;
              
                    // set values
                    cmd.Parameters.AddWithValue("@stock_item_history_id", st.StockItemHistoryId);
                    cmd.Parameters.AddWithValue("@stock_item_id", st.StockItemId);
                    cmd.Parameters.AddWithValue("@stock_history_id", st.StockHistoryId);
                    cmd.Parameters.AddWithValue("@stock_item_history_name", st.StockItemHistoryName);
                    cmd.Parameters.AddWithValue("@stock_item_history_type", st.StockItemHistoryType);
                    cmd.Parameters.AddWithValue("@stock_item_history_change", st.StockItemHistoryChange);
                    cmd.Parameters.AddWithValue("@stock_item_history_datetime", st.StockItemHistoryDatetime);

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
