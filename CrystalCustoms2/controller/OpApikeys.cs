using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalCustoms2.model;
using CrystalCustoms2.common;
using System.Data.SQLite;
using System.Windows;
using System.Globalization;

namespace CrystalCustoms2.controller
{
    class OpApikeys
    {
        public static String tableName = "apikeys";
        public static String fkName = "key_id";
        public static String[] fieldNames = {
            "key_id",
            "key_type",
            "key_name",
            "key_desc",
            "key_code",
            "key_count",
            "key_lastused",
            "key_datetime"
        };
        public static Dictionary<string, string> fieldDict = new Dictionary<string, string>();
        public static string datetimeFormat = "yyyy-MM-dd HH:mm:ss";

        // mapping field names
        static OpApikeys()
        {
            fieldDict.Add("key_id", "인증키번호");
            fieldDict.Add("key_type", "인증키유형");
            fieldDict.Add("key_name", "인증키이름");
            fieldDict.Add("key_desc", "인증키설명");
            fieldDict.Add("key_code", "인증키코드");
            fieldDict.Add("key_datetime", "인증키등록일자");
        }

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
        public static List<Apikeys> GetItems(int rowId)
        {
            List<Apikeys> QueryItems = new List<Apikeys>();
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
                                Apikeys st = new Apikeys();
                                st.KeyId = Int32.Parse(reader["key_id"].ToString());
                                st.KeyType = reader["key_type"].ToString();
                                st.KeyName = reader["key_name"].ToString();
                                st.KeyDesc = reader["key_desc"].ToString();
                                st.KeyCode = reader["key_code"].ToString();
                                st.KeyCount = Int32.Parse(reader["key_count"].ToString());
                                try {
                                    st.KeyLastused = DateTime.Parse(reader["key_lastused"].ToString());
                                } catch(Exception e)
                                {
                                    st.KeyLastused = DateTime.Now;
                                }
                                try
                                {
                                    st.KeyDatetime = DateTime.Parse(reader["key_datetime"].ToString());
                                } catch(Exception e)
                                {
                                    st.KeyDatetime = DateTime.Now;
                                }

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
        public static int UpdateItem(Apikeys st)
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
                        fieldsGlued1 += fieldNames[i] + " = @" + fieldNames[i];

                        if (i < fieldNames.Length - 1)
                        {
                            fieldsGlued1 += ",";
                        }
                    }

                    // 기존 정보 읽기
                    List<Apikeys> oldStList = GetItems(st.KeyId);
                    if (oldStList.Count > 0)
                    {
                        // 이전 정보
                        Apikeys oldSt = oldStList.First();

                        // 변경정보 입력
                        cmd.CommandText = "UPDATE " + tableName + " SET " + fieldsGlued1
                            + " WHERE " + fkName + " = @" + fkName;
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@key_id", st.KeyId);
                        cmd.Parameters.AddWithValue("@key_type", st.KeyType);
                        cmd.Parameters.AddWithValue("@key_name", st.KeyName);
                        cmd.Parameters.AddWithValue("@key_desc", st.KeyDesc);
                        cmd.Parameters.AddWithValue("@key_code", st.KeyCode);
                        cmd.Parameters.AddWithValue("@key_count", oldSt.KeyCount);
                        cmd.Parameters.AddWithValue("@key_lastused", oldSt.KeyLastused.ToString(datetimeFormat));
                        cmd.Parameters.AddWithValue("@key_datetime", oldSt.KeyDatetime.ToString(datetimeFormat));

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException)
                        {
                            // ... something code ....
                        }
                    }
                }
                conn.Close();
            }
            return result;
        }

        // insert item
        public static int AddItem(Apikeys st)
        {
            int result = -1;
            string nowDatetime = DateTime.Now.ToString(datetimeFormat);

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
                    st.KeyId = GetLastNumber() + 1;

                    // set key count is 0
                    st.KeyCount = 0;

                    // set KeyLastused, KeyDatetime is now
                    st.KeyLastused = DateTime.Now;
                    st.KeyDatetime = DateTime.Now;

                    // set values
                    cmd.Parameters.AddWithValue("@key_id", st.KeyId);
                    cmd.Parameters.AddWithValue("@key_type", st.KeyType);
                    cmd.Parameters.AddWithValue("@key_name", st.KeyName);
                    cmd.Parameters.AddWithValue("@key_desc", st.KeyDesc);
                    cmd.Parameters.AddWithValue("@key_code", st.KeyCode);
                    cmd.Parameters.AddWithValue("@key_count", st.KeyCount);
                    cmd.Parameters.AddWithValue("@key_lastused", st.KeyLastused.ToString(datetimeFormat));
                    cmd.Parameters.AddWithValue("@key_datetime", st.KeyDatetime.ToString(datetimeFormat));

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

        // 이름으로 키 추출
        public static List<string> GetKeyByName(string keyName)
        {
            List<string> QueryItems = new List<string>();
            try
            {
                using (SQLiteConnection conn = DBUnit.conn())
                {
                    conn.Open();
                    string sql = "SELECT * FROM " + tableName + " WHERE key_name = '" + keyName + "'";

                    if(keyName.Equals(false))
                        return QueryItems;

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                QueryItems.Add(reader["key_code"].ToString());
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

        // 인증키 사용횟수 증가
        public static int UsedCountUp(string keyName)
        {
            int result = -1;
            string nowDatetime = DateTime.Now.ToString(datetimeFormat);

            using (SQLiteConnection conn = DBUnit.conn())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "UPDATE " + tableName + " SET ";
                    cmd.CommandText += "key_count = key_count + 1, key_lastused = @key_lastused WHERE key_name = @key_name";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@key_name", nowDatetime);
                    cmd.Parameters.AddWithValue("@key_name", keyName);

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

        // 예외 처리
        public void FormatException(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch { }
        }
    }
}
