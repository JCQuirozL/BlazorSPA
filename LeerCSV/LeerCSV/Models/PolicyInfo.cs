using LINQtoCSV;

namespace LeerCSV.Models
{
    [Serializable]
    public class PolicyInfo
    {
        //LA PROPIEDAD INDEX DE CSVCOLUMN ATTRIBUTE SE USA SINO SE TIENEN ENCABEZADOS

        //OUTPUTFORMAT SERÁ EN LA SALIDA DE FORMATO EN CASO DE QUE SE REQUIERA, EJ FECHA:'dd-MM-yyyy'
        //MONEDA: 'C'
        [CsvColumn(Name = "POLIZA", FieldIndex =1)]
        public string Policy { get; set; }


        [CsvColumn(Name = "PRIMATOTAL", FieldIndex = 2, OutputFormat ="C")]
        public decimal PrimaTotal { get; set; }

        [CsvColumn(Name = "FECHAVALIDACION", FieldIndex = 3, OutputFormat ="dd-MM-yyyy")]
        public DateTime  FechaValidacion{ get; set; }

        [CsvColumn(Name = "FOLIOPAGO", FieldIndex = 4)]
        public string FolioPago { get; set; }

        [CsvColumn(Name = "BANCO", FieldIndex = 5)]
        public string Banco { get; set; }

        [CsvColumn(Name = "NUMEROCUENTA", FieldIndex = 6)]
        public string NumeroCuenta { get; set; }

        [CsvColumn(Name = "FECHADOCUMENTO", FieldIndex = 7, OutputFormat = "dd-MM-yyyy")]
        public DateTime FechaDocumento { get; set; }

        [CsvColumn(Name = "IMPORTEDEPOSITO", FieldIndex = 8, OutputFormat = "C")]
        public decimal ImporteDeposito { get; set; }

        [CsvColumn(Name = "REFERENCIA", FieldIndex = 9)]
        public string Referencia { get; set; }

        [CsvColumn(Name = "NUMCERT", FieldIndex = 10)]
        public int NumCert { get; set; }

        [CsvColumn(Name = "NUMFACT", FieldIndex = 11)]
        public int NumFact { get; set; }

        [CsvColumn(Name = "FECHAENVIOASE", FieldIndex = 12, OutputFormat = "dd-MM-yyyy")]
        public DateTime FechaEnvioASE { get; set; }

        [CsvColumn(Name = "CENTROEMISOR", FieldIndex = 13)]
        public string CentroEmisor { get; set; }
    }
}
