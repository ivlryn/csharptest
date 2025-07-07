using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace project
{
    internal class SaleService
    {
        private string connStr = "Server=ASUS\\SQLEXPRESS;Database=project;Trusted_Connection=True;";

        public List<SaleDto> GetSales(DateTime start, DateTime end, string filter = "")
        {
            List<SaleDto> sales = new List<SaleDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("GetSalesByDateAndName", conn))
                {   
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    cmd.Parameters.AddWithValue("@filter", filter);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new SaleDto
                            {
                                ProductCode = reader["PRODUCTCODE"].ToString(),
                                ProductName = reader["PRODUCTNAME"].ToString(),
                                Quantity = Convert.ToInt32(reader["QUANTITY"]),
                                UnitPrice = Convert.ToDecimal(reader["UNITPRICE"]),
                                SaleDate = Convert.ToDateTime(reader["SALEDATE"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("logs/errors.txt", $"[{DateTime.Now}] {ex}\n");
            }

            return sales;
        }
    }
}
