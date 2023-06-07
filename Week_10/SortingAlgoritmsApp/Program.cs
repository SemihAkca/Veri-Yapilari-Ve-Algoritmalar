using Business.Conrete;
using DataAccess.Concrete;
using Entities;
using SortingAlgoritms;


Console.WriteLine("Seçim yap:");
Console.WriteLine("1-> BubbleSort");
Console.WriteLine("2-> InsertionSort");
Console.WriteLine("3-> MergeSort");
Console.WriteLine("4-> QuickSort");


var employeeManager = new EmployeeManager(new EfEmployeeDal());

var secim = System.Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
var employees = employeeManager.GetEmployees();

if (secim == 1) // Maaşları BubbleSort ile sıralar
{
    var secimList = new List<double>();
    foreach (var employee in employees)
    {
        secimList.Add(employee.Salary);
    }

    var newSecimList = secimList.ToArray();
    BubbleSort.Sort(newSecimList);
    newSecimList.ToList().ForEach(salary => Console.WriteLine($"Salary:  {salary}"));
    return;
}

if (secim == 2) //İsimleri InsertioneSort ile sıralar
{
    var secimList = new List<string>();
    foreach (var employee in employees)
    {
        secimList.Add(employee.FirstName);
    }

    var newSecimList = secimList.ToArray();
    InsertionSort.Sort(newSecimList);
    newSecimList.ToList().ForEach(firstName => Console.WriteLine(firstName));
    return;
}

if (secim == 3) //Soyisimleri MergeSort ile sıralar
{
    var secimList = new List<string>();
    foreach (var employee in employees)
    {
        secimList.Add(employee.LastName);
    }

    var newSecimList = secimList.ToArray();
    MergeSort.Sort(newSecimList);
    newSecimList.ToList().ForEach(lastName => Console.WriteLine(lastName));
    return;
}

if (secim == 4) //Maaşları QuickSort ile sıralar
{
    var secimList = new List<double>();
    foreach (var employee in employees)
    {
        secimList.Add(employee.Salary);
    }

    var newSecimList = secimList.ToArray();
    QuickSort.Sort(newSecimList);
    newSecimList.ToList().ForEach(salary => Console.WriteLine(salary));
    return;
}
else
{
    Console.WriteLine("Geçersiz seçim!");
    Console.ReadLine();
}

