// See https://aka.ms/new-console-template for more information



using LeerCSV;


Console.WriteLine("POLICIES FOUND:");
AccesMethods.RetrieveNSaveLeasingData();
AccesMethods.ReadNSaveClipertData();
Console.ReadKey();