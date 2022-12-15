using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PoliciesInfo
/// </summary>
public class PoliciesInfo
{
    public String Policy { get; set; }
    public String Serial { get; set; }
    public String Invoice { get; set; }
    public String PaymentFolio { get; set; }
    public String Bank { get; set; }
    public String AccountNumber { get; set; }
    public DateTime DocumentDate { get; set; }
    public Decimal DepositAmount { get; set; }
    public String ReferenceId { get; set; }
    public String Economic { get; set; }
    public String DocumentNumber { get; set; }
    public PoliciesInfo()
    {
        Policy = String.Empty;
        Serial = String.Empty;
        Invoice = String.Empty;
        PaymentFolio = String.Empty;
        Bank = String.Empty;
        AccountNumber = String.Empty;
        DocumentDate = DateTime.Now;
        DepositAmount = Decimal.Zero;
        ReferenceId = String.Empty;
        Economic = String.Empty;
        DocumentNumber = String.Empty;


    }
    public PoliciesInfo(DataRow dataRow)
    {
        Policy = dataRow["Policy"].ToString();
        Serial = dataRow["Serial"].ToString();
        Invoice = dataRow["Invoice"].ToString();
        PaymentFolio = dataRow["PaymentFolio"].ToString();
        Bank = dataRow["Bank"].ToString();
        AccountNumber = dataRow["Account"].ToString();
        DocumentDate = DateTime.Parse(dataRow["DocumentDate"].ToString());
        DepositAmount = Decimal.Parse(dataRow["DepositAmount"].ToString());
        ReferenceId = dataRow["ReferenceId"].ToString();
        Economic = dataRow["Economic"].ToString();
        DocumentNumber = dataRow["DocumentNumber"].ToString();
    }


}