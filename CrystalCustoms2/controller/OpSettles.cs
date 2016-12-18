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
    class OpSettles
    {
        public static String tableName = "settles";
        public static String fkName = "settle_id";
        public static String[] fieldNames = {
            "settle_id",
            "invoice_id",
            "settle_name",
            "settle_serialnum",
            "settle_cyclenum",
            "settle_shipdate",
            "settle_cleardate",
            "settle_weight",
            "settle_weight_unit",
            "settle_remit",
            "settle_expand",
            "settle_balance",
            "settle_buy",
            "settle_sell",
            "settle_mblno",
            "settle_hblno",
            "settle_own",
            "settle_datetime"
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
        public static List<Settles> GetItems(int rowId)
        {
            List<Settles> QueryItems = new List<Settles>();
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
                                Settles st = new Settles();
                                st.SettleId = Int32.Parse(reader["settle_id"].ToString());
                                st.InvoiceId = Int32.Parse(reader["invoice_id"].ToString());
                                st.SettleName = reader["settle_name"].ToString();
                                st.SettleSerialnum = reader["settle_serialnum"].ToString();
                                st.SettleCycletime = reader["settle_cycletime"].ToString();
                                st.SettleShipdate = reader["settle_shipdate"].ToString();
                                st.SettleCleardate = reader["settle_cleardate"].ToString();
                                st.SettleWeight = reader["settle_weight"].ToString();
                                st.SettleWeightUnit = reader["settle_weight_unit"].ToString();
                                st.SettleRemit = Int32.Parse(reader["settle_remit"].ToString());
                                st.SettleExpend = Int32.Parse(reader["settle_expend"].ToString());
                                st.SettleBalance = Int32.Parse(reader["settle_balance"].ToString());
                                st.SettleBuy = reader["settle_buy"].ToString();
                                st.SettleSell = reader["settle_sell"].ToString();
                                st.SettleMblno = reader["settle_mblno"].ToString();
                                st.SettleHblno = reader["settle_hblno"].ToString();
                                st.SettleOwn = reader["settle_own"].ToString();
                                st.SettleDatetime = DateTime.Parse(reader["settle_datetime"].ToString());
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
        public static int UpdateItem(Settles st)
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

                    cmd.Parameters.AddWithValue("@settle_id", st.SettleId);
                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@settle_name", st.SettleName);
                    cmd.Parameters.AddWithValue("@settle_serialnum", st.SettleSerialnum);
                    cmd.Parameters.AddWithValue("@settle_cycletime", st.SettleCycletime);
                    cmd.Parameters.AddWithValue("@settle_shipdate", st.SettleShipdate);
                    cmd.Parameters.AddWithValue("@settle_cleardate", st.SettleCleardate);
                    cmd.Parameters.AddWithValue("@settle_weight", st.SettleWeight);
                    cmd.Parameters.AddWithValue("@settle_weight_unit", st.SettleWeightUnit);
                    cmd.Parameters.AddWithValue("@settle_remit", st.SettleRemit);
                    cmd.Parameters.AddWithValue("@settle_expand", st.SettleExpend);
                    cmd.Parameters.AddWithValue("@settle_balance", st.SettleBalance);
                    cmd.Parameters.AddWithValue("@settle_buy", st.SettleBuy);
                    cmd.Parameters.AddWithValue("@settle_sell", st.SettleSell);
                    cmd.Parameters.AddWithValue("@settle_mblno", st.SettleMblno);
                    cmd.Parameters.AddWithValue("@settle_hblno", st.SettleHblno);
                    cmd.Parameters.AddWithValue("@settle_own", st.SettleOwn);
                    cmd.Parameters.AddWithValue("@settle_datetime", st.SettleDatetime);

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
        public static int AddItem(Settles st)
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
                    st.SettleId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@settle_id", st.SettleId);
                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@settle_name", st.SettleName);
                    cmd.Parameters.AddWithValue("@settle_serialnum", st.SettleSerialnum);
                    cmd.Parameters.AddWithValue("@settle_cycletime", st.SettleCycletime);
                    cmd.Parameters.AddWithValue("@settle_shipdate", st.SettleShipdate);
                    cmd.Parameters.AddWithValue("@settle_cleardate", st.SettleCleardate);
                    cmd.Parameters.AddWithValue("@settle_weight", st.SettleWeight);
                    cmd.Parameters.AddWithValue("@settle_weight_unit", st.SettleWeightUnit);
                    cmd.Parameters.AddWithValue("@settle_remit", st.SettleRemit);
                    cmd.Parameters.AddWithValue("@settle_expand", st.SettleExpend);
                    cmd.Parameters.AddWithValue("@settle_balance", st.SettleBalance);
                    cmd.Parameters.AddWithValue("@settle_buy", st.SettleBuy);
                    cmd.Parameters.AddWithValue("@settle_mblno", st.SettleMblno);
                    cmd.Parameters.AddWithValue("@settle_hblno", st.SettleHblno);
                    cmd.Parameters.AddWithValue("@settle_own", st.SettleOwn);
                    cmd.Parameters.AddWithValue("@settle_datetime", st.SettleDatetime);

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
