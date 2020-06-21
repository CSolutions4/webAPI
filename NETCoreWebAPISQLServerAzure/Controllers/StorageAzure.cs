using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NETCoreWebAPISQLServerAzure.Controllers
{
    public class StorageAzure
    {
        public List<usuarios> ListadeUsuarios;
        public bool Almacenar(int CURP, string Nombre, string Sexo, int Edad, string Nscimiento, string registro, string direccion)
        {
            var connect = new SqlConnection
                ("Server=tcp:usuarios.database.windows.net,1433;" +
                "Initial Catalog=App_User;" +
                "Persist Security Info=False;" +
                "User ID=erikroot;" +
                "Password=6TeQ&KeraN16;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");
            var query = new SqlCommand
                ("INSERT INTO Datos (CURP, Nombre, Sexo, Edad, Nacimiento, Registro, Direccion) VALUES " +
                "('" + CURP + "','" + Nombre + "','" + Sexo + "','" + Edad + "', '" + Nacimiento + "', '" + Registro + "','" + Direccion + "')", connect);

            try
                {
                    connect.Open();
                    query.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
            catch (SqlException ex)
            {
                    connect.Close();
                    return false;
                    
            }
        }

        public List<Usuarios> Consulta(int CURP)
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                ("Server=tcp:usuarios.database.windows.net,1433;" +
                "Initial Catalog=App_users;" +
                "Persist Security Info=False;" +
                "User ID=erikroot;" +
                "Password=6TeQ&KeraN16;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");
            var cmd = new SqlCommand
                ("SELECT * From Datos WHERE ID ='" + CURP + "'", connect);
            connect.Open();
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Listadeusuarios = new List<Usuarios>();
            Usuarios usuario = new usuarios();
            Usuario.CURP = int.Parse((dt.Rows[0]["CURP"]).ToString());
            Usuario.Nombre = (dt.Rows[0]["Nombre"]).ToString();
            Usuario.Sexo = (dt.Rows[0]["Sexo"]).ToString();
            Usuario.Edad = int.Parse((dt.Rows[0]["Edad"]).ToString());
            Usuario.Nacimiento = (dt.Rows[0]["Nacimiento"]).ToString();
            Usuario.Registro = (dt.Rows[0]["Registro"]).ToString();
            Usuario.Direccion = (dt.Rows[0]["direccion"]).ToString();
            ListadeUsuarios.Add(user);

            return ListadeUsuarios;
        }
    }
}
