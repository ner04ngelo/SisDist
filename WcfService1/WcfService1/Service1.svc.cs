using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private SqlConnection con = new SqlConnection("Data Source= localhost; " +
            "Initial Catalog= Northwind; " +
            "user id= sa; " +
            "password= 123; ");


        public string ValidateProducts(int ProductsId)
        {
            string mensaje = "";

            List<string> Products = new List<string>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductName, QuantityPerUnit FROM Products where ProductID= @ProductsId", con);
                cmd.Parameters.AddWithValue("@ProductsId", ProductsId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    mensaje = "Producto Encontrado";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ProductName = dt.Rows[i]["ProductName"].ToString();
                        string QuantityPerUnit = dt.Rows[i]["QuantityPerUnit"].ToString();

                        Products.Add(ProductName);
                        Products.Add(QuantityPerUnit);
                    }
                }
                else
                {
                    mensaje = "No hubo coincidencia";
                }
                con.Close();
            }

            return mensaje;
        }


    }


}
