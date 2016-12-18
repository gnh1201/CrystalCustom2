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
    class OpSales
    {
        public static String tableName = "sales";
        public static String fkName = "sales_id";
        public static String[] fieldNames = {
            "sales_id",
            "customer_id",
            "product_id",
            "stock_id",
            "sales_qty",
            "sales_unitprice",
            "sales_vat",
            "sales_vatrate",
            "sales_cost",
            "sales_profit",
            "sales_datetime"
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
        public static List<Sales> GetItems(int rowId)
        {
            List<Sales> QueryItems = new List<Sales>();
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
                                Sales st = new Sales();
                                st.SalesId = Int32.Parse(reader["sales_id"].ToString());
                                st.ProductId = Int32.Parse(reader["product_id"].ToString());
                                st.StockId = Int32.Parse(reader["stock_id"].ToString());
                                st.SalesQty = Int32.Parse(reader["sales_qty"].ToString());
                                st.SalesUnitprice = Int32.Parse(reader["sales_unitprice"].ToString());
                                st.SalesVat = Int32.Parse(reader["sales_vat"].ToString());
                                st.SalesVatrate = float.Parse(reader["sales_vatrate"].ToString());
                                st.SalesCost = Int32.Parse(reader["sales_cost"].ToString());
                                st.SalesProfit = Int32.Parse(reader["sales_profix"].ToString());
                                st.SalesDatetime = DateTime.Parse(reader["sales_datetime"].ToString());
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
        public static int UpdateItem(Sales st)
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

                    cmd.Parameters.AddWithValue("@sales_id", st.SalesId);
                    cmd.Parameters.AddWithValue("@customer_id", st.CustomerId);
                    cmd.Parameters.AddWithValue("@product_id", st.ProductId);
                    cmd.Parameters.AddWithValue("@stock_id", st.StockId);
                    cmd.Parameters.AddWithValue("@sales_qty", st.SalesQty);
                    cmd.Parameters.AddWithValue("@sales_unitprice", st.SalesUnitprice);
                    cmd.Parameters.AddWithValue("@sales_vat", st.SalesVat);
                    cmd.Parameters.AddWithValue("@sales_vatrate", st.SalesVatrate);
                    cmd.Parameters.AddWithValue("@sales_cost", st.SalesCost);
                    cmd.Parameters.AddWithValue("@sales_profit", st.SalesProfit);
                    cmd.Parameters.AddWithValue("@sales_datetime", st.SalesDatetime);

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
        public static int AddItem(Sales st)
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
                    st.ProductId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@sales_id", st.SalesId);
                    cmd.Parameters.AddWithValue("@customer_id", st.CustomerId);
                    cmd.Parameters.AddWithValue("@product_id", st.ProductId);
                    cmd.Parameters.AddWithValue("@stock_id", st.StockId);
                    cmd.Parameters.AddWithValue("@sales_qty", st.SalesQty);
                    cmd.Parameters.AddWithValue("@sales_unitprice", st.SalesUnitprice);
                    cmd.Parameters.AddWithValue("@sales_vat", st.SalesVat);
                    cmd.Parameters.AddWithValue("@sales_vatrate", st.SalesVatrate);
                    cmd.Parameters.AddWithValue("@sales_cost", st.SalesCost);
                    cmd.Parameters.AddWithValue("@sales_profit", st.SalesProfit);
                    cmd.Parameters.AddWithValue("@sales_datetime", st.SalesDatetime);

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
