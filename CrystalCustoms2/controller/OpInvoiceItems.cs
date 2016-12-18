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
    class OpInvoiceItems
    {
        public static String tableName = "invoice_items";
        public static String fkName = "invoice_item_id";
        public static String[] fieldNames = {
            "invoice_item_id",
            "invoice_id",
            "stock_id",
            "invoice_item_desc",
            "invoice_item_qty",
            "invoice_item_price",
            "invoice_item_unit",
            "invoice_item_amount",
            "invoice_item_vat",
            "invoice_item_vatrate",
            "invoice_item_datetime"
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
        public static List<InvoiceItems> GetItems(int rowId)
        {
            List<InvoiceItems> QueryItems = new List<InvoiceItems>();
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
                                InvoiceItems st = new InvoiceItems();
                                st.InvoiceId = Int32.Parse(reader["invoice_id"].ToString());
                                st.StockId = Int32.Parse(reader["stock_id"].ToString());
                                st.InvoiceItemDesc = reader["invoice_item_desc"].ToString();
                                st.InvoiceItemQty = Int32.Parse(reader["invoice_item_qty"].ToString());
                                st.InvoiceItemAmount = Int32.Parse(reader["invoice_item_amount"].ToString());
                                st.InvoiceItemVat = Int32.Parse(reader["invoice_item_vat"].ToString());
                                st.InvoiceItemVatrate = float.Parse(reader["invoice_item_vatrate"].ToString());
                                st.InvoiceItemDatetime = DateTime.Parse(reader["invoice_item_datetime"].ToString());
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
        public static int UpdateItem(InvoiceItems st)
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

                    cmd.Parameters.AddWithValue("@invoice_item_id", st.InvoiceItemId);
                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@stock_id", st.StockId);
                    cmd.Parameters.AddWithValue("@invoice_item_desc", st.InvoiceItemDesc);
                    cmd.Parameters.AddWithValue("@invoice_item_qty", st.InvoiceItemQty);
                    cmd.Parameters.AddWithValue("@invoice_item_unit", st.InvoiceItemUnit);
                    cmd.Parameters.AddWithValue("@invoice_item_amount", st.InvoiceItemAmount);
                    cmd.Parameters.AddWithValue("@invoice_item_vat", st.InvoiceItemVat);
                    cmd.Parameters.AddWithValue("@invoice_item_vatrate", st.InvoiceItemVatrate);
                    cmd.Parameters.AddWithValue("@invoice_item_datetime", st.InvoiceItemDatetime);

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
        public static int AddItem(InvoiceItems st)
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
                    st.InvoiceItemId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@invoice_item_id", st.InvoiceItemId);
                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@stock_id", st.StockId);
                    cmd.Parameters.AddWithValue("@invoice_item_desc", st.InvoiceItemDesc);
                    cmd.Parameters.AddWithValue("@invoice_item_qty", st.InvoiceItemQty);
                    cmd.Parameters.AddWithValue("@invoice_item_unit", st.InvoiceItemUnit);
                    cmd.Parameters.AddWithValue("@invoice_item_amount", st.InvoiceItemAmount);
                    cmd.Parameters.AddWithValue("@invoice_item_vat", st.InvoiceItemVat);
                    cmd.Parameters.AddWithValue("@invoice_item_vatrate", st.InvoiceItemVatrate);
                    cmd.Parameters.AddWithValue("@invoice_item_datetime", st.InvoiceItemDatetime);

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
