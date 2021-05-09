using System;
using System.Linq;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            CompanyContext context = new CompanyContext();
            var emp = context.Employees.Where(x => x.Id == 1)
                
                .Include(x => x.Projects)
                .FirstOrDefault();

            context.Entry(emp).Reference(x => x.PassportInfo).Load();
            context.Entry(emp).Collection(x => x.Projects).Load();


            // var employee = context.Employees.Find(1);
            //employee.FirstName = "BB";
            //
            // var empToRemove = context.Employees.Find(4);
            // context.Employees.Remove(empToRemove);
            //
            // context.Employees.Remove(new Employee {Id = 4});
            //
            //
            // context.SaveChanges();

            // foreach (var employee in employees)
            // {
            //     Console.Out.WriteLine(employee);
            // }

        }
    }
}
