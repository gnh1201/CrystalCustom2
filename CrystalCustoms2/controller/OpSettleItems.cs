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
    class OpSettleItems
    {
        public static String tableName = "settle_items";
        public static String fkName = "settle_item_id";
        public static String[] fieldNames = {
            "settle_item_id",
            "settle_id",
            "settle_item_name",
            "settle_item_type",
            "settle_item_amount",
            "settle_item_vat",
            "settle_item_datetime"
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
                                string strLastNum = reader["LASTNUM"].ToString();
                                if(!strLastNum.Equals("")) { 
                                    last_num = Int32.Parse(reader["LASTNUM"].ToString());
                                } else
                                {
                                    last_num = 0;
                                }
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
        public static List<SettleItems> GetItems(int rowId)
        {
            List<SettleItems> QueryItems = new List<SettleItems>();
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
                                SettleItems st = new SettleItems();
                                st.SettleItemId = Int32.Parse(reader["settle_item_id"].ToString());
                                st.SettleId = Int32.Parse(reader["settle_id"].ToString());
                                st.SettleItemName = reader["settle_item_name"].ToString();
                                st.SettleItemType = reader["settle_item_type"].ToString();
                                st.SettleItemAmount = reader["settle_item_amount"].ToString();
                                st.SettleItemVat = reader["settle_item_vat"].ToString();
                                st.SettleItemDatetime = DateTime.Parse(reader["settle_item_datetime"].ToString());
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
        public static int UpdateItem(SettleItems st)
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

                    cmd.Parameters.AddWithValue("@settle_item_id", st.SettleItemId);
                    cmd.Parameters.AddWithValue("@settle_id", st.SettleId);
                    cmd.Parameters.AddWithValue("@settle_item_name", st.SettleItemName);
                    cmd.Parameters.AddWithValue("@settle_item_type", st.SettleItemType);
                    cmd.Parameters.AddWithValue("@settle_item_amount", st.SettleItemAmount);
                    cmd.Parameters.AddWithValue("@settle_item_vat", st.SettleItemVat);
                    cmd.Parameters.AddWithValue("@settle_item_datetime", st.SettleItemDatetime);

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
        public static int AddItem(SettleItems st)
        {
            int result = -1;

            List<string> defineFields = new List<string>();
            string[] defineFields1 = { };
            string[] defineFields2 = { };

            defineFields1 = fieldNames;
            foreach(string fieldName in fieldNames)
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
                    st.SettleItemId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@settle_item_id", st.SettleItemId);
                    cmd.Parameters.AddWithValue("@settle_id", st.SettleId);
                    cmd.Parameters.AddWithValue("@settle_item_name", st.SettleItemName);
                    cmd.Parameters.AddWithValue("@settle_item_type", st.SettleItemType);
                    cmd.Parameters.AddWithValue("@settle_item_amount", st.SettleItemAmount);
                    cmd.Parameters.AddWithValue("@settle_item_vat", st.SettleItemVat);
                    cmd.Parameters.AddWithValue("@settle_item_datetime", st.SettleItemDatetime);

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
