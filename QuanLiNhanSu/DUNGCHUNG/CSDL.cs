using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DUNGCHUNG
{
    internal class CSDL
    {
        private static string conSTR = @"Data Source=LAPTOP-4M6GTD3M;Initial Catalog=QL_NhanSu;Integrated Security=True";

        //Lấy danh sách
        public static DataTable LayDanhSach(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        //Thêm - sửa - xóa
        public static int ThemSuaXoa(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                con.Close();
            }
            return data;
        }
    }
}
