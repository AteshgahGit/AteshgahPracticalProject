using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.Concrete.Managers;
using AteshgahPracticalProject.Business.DependencyResolvers.Ninject;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            ILoanService loanManager = InstanceFactory.GetInstance<ILoanService>();
            IInvoiceService invoiceManager = InstanceFactory.GetInstance<IInvoiceService>();

            //CalculateModel model = new CalculateModel
            //{
            //    ClientID = random.Next(1, 25),
            //    InterestRate = (decimal)random.Next(5, 20) / 100,
            //    LoanAmount = random.Next(1,50)*100,
            //    LoanPeriod = random.Next(3,24)
            //};

            //List<Invoice> calculatedInvoices = invoiceManager.GetCalculatedInvoices(model);
            //Console.WriteLine($"Goturulen Kredit Miqdari: {model.LoanAmount} \n__________________________\n");
            //foreach (var item in calculatedInvoices)
            //{
            //    Console.WriteLine($"Odenilecek Mebleg: {item.Amount} \nOdeme Tarixi: {item.DueDate} \n----------------------\n");
            //}

            //decimal result = invoiceManager.CalculateInvoiceAmount(3,(decimal)300,3,(decimal)0.05);

            //Console.WriteLine(result);

            //var invoiceList = invoiceManager.GetAll();
            //var loanList = loanManager.GetAll();
            //var invoice = invoiceManager.Get(5);
            //var loan = loanManager.Get(5);

            //Console.WriteLine(invoiceList.Count);
            //Console.WriteLine(loanList.Count);
            //Console.WriteLine("-----");
            //Console.WriteLine(invoice.Amount);
            //Console.WriteLine(loan.Amount);

            invoiceManager.Get(5);

            Console.WriteLine("Thrown");

            Console.ReadLine();
        }
    }
}
