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
    class OpAddresses
    {
        public static String tableName = "addresses";
        public static String fkName = "addr_id";
        public static String[] fieldNames = {
            "addr_id",
            "user_id",
            "addr_type",
            "addr_name",
            "addr_zipcode1",
            "addr_zipcode2",
            "addr_line1",
            "addr_line2",
            "addr_line3",
            "addr_line4",
            "addr_tel",
            "addr_phone",
            "addr_fax",
            "addr_email",
            "addr_content",
            "addr_countrycode",
            "addr_default",
            "addr_datetime"
        };
        public static Dictionary<string, string> fieldDict = new Dictionary<string, string>();

        // mapping field names
        static OpAddresses()
        {
            fieldDict.Add("addr_id", "주소번호");
            fieldDict.Add("user_id", "사용자");
            fieldDict.Add("addr_type", "주소유형");
            fieldDict.Add("addr_name", "주소이름");
            fieldDict.Add("addr_zipcode1", "우편번호1");
            fieldDict.Add("addr_zipcode2", "우편번호2");
            fieldDict.Add("addr_line1", "기본주소");
            fieldDict.Add("addr_line2", "상세주소1");
            fieldDict.Add("addr_line3", "상세주소2");
            fieldDict.Add("addr_line4", "상세주소3");
            fieldDict.Add("addr_tel", "전화번호");
            fieldDict.Add("addr_phone", "휴대전화");
            fieldDict.Add("addr_fax", "팩스번호");
            fieldDict.Add("addr_email", "이메일주소");
            fieldDict.Add("addr_content", "주소내용");
            fieldDict.Add("addr_countrycode", "국가코드");
            fieldDict.Add("addr_default", "기본값");
            fieldDict.Add("addr_datetime", "주소등록일자");
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
        public static List<Addresses> GetItems(int rowId)
        {
            List<Addresses> QueryItems = new List<Addresses>();
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
                                Addresses st = new Addresses();
                                st.AddrId = Int32.Parse(reader["addr_id"].ToString());
                                st.UserId = Int32.Parse(reader["user_id"].ToString());
                                st.AddrType = reader["addr_type"].ToString();
                                st.AddrName = reader["addr_name"].ToString();
                                st.AddrZipcode1 = reader["addr_zipcode1"].ToString();
                                st.AddrZipcode2 = reader["addr_zipcode2"].ToString();
                                st.AddrLine1 = reader["addr_line1"].ToString();
                                st.AddrLine2 = reader["addr_line2"].ToString();
                                st.AddrLine3 = reader["addr_line3"].ToString();
                                st.AddrLine4 = reader["addr_line4"].ToString();
                                st.AddrTel = reader["addr_tel"].ToString();
                                st.AddrPhone = reader["addr_phone"].ToString();
                                st.AddrFax = reader["addr_fax"].ToString();
                                st.AddrEmail = reader["addr_email"].ToString();
                                st.AddrContent = reader["addr_content"].ToString();
                                st.AddrCountrycode = reader["addr_countrycode"].ToString();
                                st.AddrDefault = Int32.Parse(reader["addr_default"].ToString());
                                st.AddrDatetime = DateTime.Parse(reader["addr_datetime"].ToString());
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
        public static int UpdateItem(Addresses st)
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

                    cmd.Parameters.AddWithValue("@addr_id", st.AddrId);
                    cmd.Parameters.AddWithValue("@user_id", st.UserId);
                    cmd.Parameters.AddWithValue("@addr_type", st.AddrType);
                    cmd.Parameters.AddWithValue("@addr_name", st.AddrName);
                    cmd.Parameters.AddWithValue("@addr_zipcode1", st.AddrZipcode1);
                    cmd.Parameters.AddWithValue("@addr_zipcode2", st.AddrZipcode2);
                    cmd.Parameters.AddWithValue("@addr_line1", st.AddrLine1);
                    cmd.Parameters.AddWithValue("@addr_line2", st.AddrLine2);
                    cmd.Parameters.AddWithValue("@addr_line3", st.AddrLine3);
                    cmd.Parameters.AddWithValue("@addr_line4", st.AddrLine4);
                    cmd.Parameters.AddWithValue("@addr_tel", st.AddrTel);
                    cmd.Parameters.AddWithValue("@addr_phone", st.AddrPhone);
                    cmd.Parameters.AddWithValue("@addr_fax", st.AddrFax);
                    cmd.Parameters.AddWithValue("@addr_email", st.AddrEmail);
                    cmd.Parameters.AddWithValue("@addr_content", st.AddrContent);
                    cmd.Parameters.AddWithValue("@addr_countrycode", st.AddrCountrycode);
                    cmd.Parameters.AddWithValue("@addr_default", st.AddrDefault);
                    cmd.Parameters.AddWithValue("@addr_datetime", st.AddrDatetime);

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
        public static int AddItem(Addresses st)
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
                    st.AddrId = GetLastNumber() + 1;

                    // set values
                    cmd.Parameters.AddWithValue("@addr_id", st.AddrId);
                    cmd.Parameters.AddWithValue("@user_id", st.UserId);
                    cmd.Parameters.AddWithValue("@addr_type", st.AddrType);
                    cmd.Parameters.AddWithValue("@addr_name", st.AddrName);
                    cmd.Parameters.AddWithValue("@addr_zipcode1", st.AddrZipcode1);
                    cmd.Parameters.AddWithValue("@addr_zipcode2", st.AddrZipcode2);
                    cmd.Parameters.AddWithValue("@addr_line1", st.AddrLine1);
                    cmd.Parameters.AddWithValue("@addr_line2", st.AddrLine2);
                    cmd.Parameters.AddWithValue("@addr_line3", st.AddrLine3);
                    cmd.Parameters.AddWithValue("@addr_line4", st.AddrLine4);
                    cmd.Parameters.AddWithValue("@addr_tel", st.AddrTel);
                    cmd.Parameters.AddWithValue("@addr_phone", st.AddrPhone);
                    cmd.Parameters.AddWithValue("@addr_fax", st.AddrFax);
                    cmd.Parameters.AddWithValue("@addr_email", st.AddrEmail);
                    cmd.Parameters.AddWithValue("@addr_content", st.AddrContent);
                    cmd.Parameters.AddWithValue("@addr_countrycode", st.AddrCountrycode);
                    cmd.Parameters.AddWithValue("@addr_default", st.AddrDefault);
                    cmd.Parameters.AddWithValue("@addr_datetime", st.AddrDatetime);

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
