

namespace MilRegistros
{
    using System.Data.SqlClient;
    public static class InsertingClass
    {
        public static String CString { get; set; } = "Data Source=lsng201.facileasing.com.mx;Initial Catalog=InsuranceMX;Persist Security Info=True;User ID=conninfopath;Password=L34s1ng#Q4l1t7;TrustServerCertificate=true;";
        public static void Insertar()
        {

            SqlConnection cnx = new SqlConnection(CString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                String policyValue = "8A2S65000";

                cmd.Connection = cnx;

                cnx.Open();
                for (var i = 1; i <= 1000; i++)
                {
                    if (i < 10)
                    {
                        policyValue = "8A2S65000";
                        policyValue = policyValue + i.ToString();
                    }
                    else if (i < 100)
                    {
                        policyValue = "8A2S6500";
                        policyValue = policyValue + i.ToString();
                    }
                    else if (i == 1000)
                    {
                        policyValue = "8A2S65";
                        policyValue = policyValue + i.ToString();

                    }
                    else
                    {
                        policyValue = "8A2S650";
                        policyValue = policyValue + i.ToString();
                    }

                    cmd.CommandText = "INSERT INTO PoliciesCollection SELECT PCF.PolicyFileId, PIS.PolicyInfoId,1,'" +
                        policyValue + "',PIS.Serial, PCF.TotalPremium,PIS.PaymentFolio,PIS.Bank,PIS.AccountNumber,PIS.DepositAmount,PIS.DepositDate, PIS.ReferenceId, PCF.Certificate,PCF.Invoice,PCF.IssueDate, PCF.EmmiterCenter, 0,null,GETDATE(),null FROM PolicyCollectionFile PCF INNER JOIN PolicyInformationService PIS ON PCF.Policy = PIS.Policy WHERE PCF.Policy = '8A2S650010'";
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine($"{i} Registro(s) insertados correctamente...{policyValue}");
                    }
                    else
                    {
                        Console.WriteLine($"No hay registros que insertar");
                        break;
                    }

                }

                cnx.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
        }
    }
}
