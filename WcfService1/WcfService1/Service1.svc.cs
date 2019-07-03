using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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


        SqlConnection con = new SqlConnection("Data Source= localhost; " +
            "Initial Catalog= ContosoUniversity; " +
            "user id= sa; " +
            "password= 123; ");


        public string ValidateLogin(string user, string pwd)
        {
            string mensaje = "";

            List<string> UserPassword = new List<string>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios where Username= @user and PasswordUser = @pwd", con);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) {
                    mensaje = "User Encontrado";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string nombre = dt.Rows[i]["Username"].ToString();
                        string pass = dt.Rows[i]["PasswordUser"].ToString();

                        UserPassword.Add(nombre);
                        UserPassword.Add(pass);
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
