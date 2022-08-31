using LeerCSV.Models;
using LINQtoCSV;

namespace LeerCSV
{
    public static class AccesMethods
    {
        public static void ReadNSaveClipertData()
        {
            try
            {
                var fileDescription = new CsvFileDescription()
                {
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true,
                    SeparatorChar = ',',
                    UseFieldIndexForReadingData = false,
                    //EnforceCsvColumnAttribute = true,
                };

                var csvContext = new CsvContext();
                var collection = csvContext.Read<ClipertDataCSV>("C:\\Users\\XMX7686\\Desktop\\file.csv", fileDescription);


                List<ClipertDataCSV> ClipertData = new();

                foreach (var item in collection)
                {
                    ClipertData.Add(item);
                }

                ClipertDataCSV[] array = ClipertData.ToArray();

                if (Service.CreatePFC(array))
                {
                    Console.WriteLine("Clipert data created succesfully...\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }

        }

        public static void RetrieveNSaveLeasingData()
        {
            try
            {
                var fileDescription = new CsvFileDescription()
                {
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true,
                    SeparatorChar = ',',
                    UseFieldIndexForReadingData = false,
                };

                var csvContext = new CsvContext();
                var collection = csvContext.Read<GetPolicyInfoVM>("C:\\Users\\XMX7686\\Desktop\\file.csv", fileDescription);



                List<string> Params = new();
                foreach (var policy in collection)
                {
                    Console.WriteLine(policy.Policy);
                    Params.Add(policy.Policy);
                }


                List<LeasingVM> Result = Service.GetPoliciesList(Params);


                //Saber de qué póliza no se encontró info en el server de leasing
                var notFoundP = Params.Where(p => !Result.Any(x => p == x.policy)).ToList();

                LeasingVM[] LeasingData = Result.ToArray();

                if (Service.CreatePIService(LeasingData))
                {
                    Console.WriteLine("Leassing data created succesfully...\n");

                    Console.WriteLine("Policies with no info: ");
                    foreach (var policy in notFoundP)
                    {
                        Console.WriteLine($"Policy number: {policy}...");
                    }

                }

                //foreach (var item in Result)
                //{
                //    Console.WriteLine($"{item.paymentFolio} | {item.bank} | {item.issueDate} ");
                //}
            }
            catch (Exception)
            {

                throw;
            }

            //Result[1].policy




        }

    }


}
