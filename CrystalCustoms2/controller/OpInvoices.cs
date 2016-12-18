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
    class OpInvoices
    {
        public static String tableName = "invoices";
        public static String fkName = "invoice_id";
        public static String[] fieldNames = {
            "invoice_id",
            "invoice_name",
            "invoice_currency",
            "invoice_amount",
            "invoice_domestic_amount",
            "invoice_datetime"
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
        public static List<Invoices> GetItems(int rowId)
        {
            List<Invoices> QueryItems = new List<Invoices>();
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
                                Invoices st = new Invoices();
                                st.InvoiceId = Int32.Parse(reader["invoice_id"].ToString());
                                st.InvoiceName = reader["invoice_name"].ToString();
                                st.InvoiceCurrency = reader["invoice_currency"].ToString();
                                st.InvoiceAmount = Int32.Parse(reader["invoice_amount"].ToString());
                                st.InvoiceDomesticAmount = Int32.Parse(reader["invoice_domestic_amount"].ToString());
                                st.InvoiceDatetime = DateTime.Parse(reader["invoice_datetime"].ToString());
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
        public static int UpdateItem(Invoices st)
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

                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@invoice_name", st.InvoiceName);
                    cmd.Parameters.AddWithValue("@invoice_currency", st.InvoiceCurrency);
                    cmd.Parameters.AddWithValue("@invoice_amount", st.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@invoice_domestic_amount", st.InvoiceDomesticAmount);
                    cmd.Parameters.AddWithValue("@invoice_datetime", st.InvoiceDatetime);

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
        public static int AddItem(Invoices st)
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
                    st.InvoiceId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@invoice_id", st.InvoiceId);
                    cmd.Parameters.AddWithValue("@invoice_name", st.InvoiceName);
                    cmd.Parameters.AddWithValue("@invoice_currency", st.InvoiceCurrency);
                    cmd.Parameters.AddWithValue("@invoice_amount", st.InvoiceAmount);
                    cmd.Parameters.AddWithValue("@invoice_domestic_amount", st.InvoiceDomesticAmount);
                    cmd.Parameters.AddWithValue("@invoice_datetime", st.InvoiceDatetime);

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
