// See https://aka.ms/new-console-template for more information
using myTask;
using System.Globalization;
using System.Data;

UseData useData = new UseData();
Console.WriteLine("please enter CSV file path!");
//Here I entered C://Users//User//Desktop//משימת בית//data.csv my CSV file path. 
string filePath = Console.ReadLine();
while (!File.Exists(filePath))
{
    Console.WriteLine("INCORRECT PATH! enter again!");
    filePath = Console.ReadLine();
}
useData.csvData = useData.GetDataTabletFromCSVFile(filePath);
Console.WriteLine(useData.FindAvarageAge());
Console.WriteLine(useData.FindTotalNumberOfSpecificPeople());
Console.WriteLine(useData.FindAvarageOfSpecificPeople());