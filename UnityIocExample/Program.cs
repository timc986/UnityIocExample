using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityIocExample
{
    public interface IEmployee
    {
    }
    public class Employee : IEmployee
    {
        private ICompany _Company;

        [InjectionConstructor]
        public Employee(ICompany tmpCompany)
        {
            _Company = tmpCompany;
        }

        public void DisplaySalary()
        {
            _Company.ShowSalary();
        }
    }

    public interface ICompany
    {
        void ShowSalary();
    }
    public class Company : ICompany
    {
        public void ShowSalary()
        {
            Console.WriteLine("Your salary is 40 K");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<ICompany, Company>();

            Employee emp = unitycontainer.Resolve<Employee>();
            emp.DisplaySalary();
            Console.ReadLine();
        }
    }
}
