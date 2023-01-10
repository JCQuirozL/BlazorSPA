using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "SAPService" en el código, en svc y en el archivo de configuración a la vez.
public class SAPService : ISAPService
{
    public PoliciesInfo GetPoliciesInfo(String policy, String invoice)
    {
        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        try
        {
            string Query = "SPGetData";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@policy", policy);
            cmd.Parameters.AddWithValue("@invoice", invoice);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dsPolicy = new DataSet();

            adapter.Fill(dsPolicy);


            if (dsPolicy.Tables[0].Rows.Count > 0)
            {
                DataRow drPolicy = dsPolicy.Tables[0].Rows[0];
                PoliciesInfo policyInfo = new PoliciesInfo(drPolicy);
                return policyInfo;
            }
            else
            {
                PoliciesInfo policyInfo = new PoliciesInfo();
                return policyInfo;
            }


        }
        catch (Exception)
        {

            throw;
        }
    }
}
