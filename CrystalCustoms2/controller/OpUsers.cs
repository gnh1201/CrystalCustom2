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
    class OpUsers
    {
        public static String tableName = "users";
        public static String fkName = "user_id";
        public static String[] fieldNames = {
            "user_id",
            "user_no",
            "addr_id",
            "user_name",
            "user_password",
            "user_level",
            "user_type",
            "user_gender",
            "user_birth",
            "user_content",
            "user_status",
            "user_datetime",
            "user_last_login"
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
        public static List<Users> GetItems(int rowId)
        {
            List<Users> QueryItems = new List<Users>();
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
                                Users st = new Users();
                                st.UserId = Int32.Parse(reader["user_id"].ToString());
                                st.UserNo = Int32.Parse(reader["user_no"].ToString());
                                st.AddrId = Int32.Parse(reader["addr_id"].ToString());
                                st.UserName = reader["user_name"].ToString();
                                st.UserPassword = reader["user_password"].ToString();
                                st.UserLevel = reader["user_level"].ToString();
                                st.UserType = reader["user_type"].ToString();
                                st.UserGender = reader["user_gender"].ToString();
                                st.UserBirth = reader["user_birth"].ToString();
                                st.UserContent = reader["user_content"].ToString();
                                st.UserStatus = reader["user_status"].ToString();
                                st.UserDatetime = DateTime.Parse(reader["user_datetime"].ToString());
                                st.UserLastLogin = DateTime.Parse(reader["user_last_login"].ToString());
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
        public static int UpdateItem(Users st)
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

                    cmd.Parameters.AddWithValue("@user_id", st.UserId);
                    cmd.Parameters.AddWithValue("@user_no", st.UserNo);
                    cmd.Parameters.AddWithValue("@addr_id", st.AddrId);
                    cmd.Parameters.AddWithValue("@user_name", st.UserName);
                    cmd.Parameters.AddWithValue("@user_password", st.UserPassword);
                    cmd.Parameters.AddWithValue("@user_level", st.UserLevel);
                    cmd.Parameters.AddWithValue("@user_type", st.UserType);
                    cmd.Parameters.AddWithValue("@user_gender", st.UserGender);
                    cmd.Parameters.AddWithValue("@user_birth", st.UserBirth);
                    cmd.Parameters.AddWithValue("@user_content", st.UserContent);
                    cmd.Parameters.AddWithValue("@user_status", st.UserStatus);
                    cmd.Parameters.AddWithValue("@user_datetime", st.UserDatetime);
                    cmd.Parameters.AddWithValue("@user_last_login", st.UserLastLogin);

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
        public static int AddItem(Users st)
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
                    st.UserId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@user_id", st.UserId);
                    cmd.Parameters.AddWithValue("@user_no", st.UserNo);
                    cmd.Parameters.AddWithValue("@addr_id", st.AddrId);
                    cmd.Parameters.AddWithValue("@user_name", st.UserName);
                    cmd.Parameters.AddWithValue("@user_password", st.UserPassword);
                    cmd.Parameters.AddWithValue("@user_level", st.UserLevel);
                    cmd.Parameters.AddWithValue("@user_type", st.UserType);
                    cmd.Parameters.AddWithValue("@user_gender", st.UserGender);
                    cmd.Parameters.AddWithValue("@user_birth", st.UserBirth);
                    cmd.Parameters.AddWithValue("@user_content", st.UserContent);
                    cmd.Parameters.AddWithValue("@user_status", st.UserStatus);
                    cmd.Parameters.AddWithValue("@user_datetime", st.UserDatetime);
                    cmd.Parameters.AddWithValue("@user_last_login", st.UserLastLogin);

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
