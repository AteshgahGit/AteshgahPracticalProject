using System;
using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.DependencyResolvers.Ninject;
using AteshgahPracticalProject.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AteshgahPracticalProject.Business.Tests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestInitialize]
        public void Invoice_Test_Initialize()
        {

        }


        [TestMethod]
        public void Check_SP_Loan_Amount_Counter_Is_Right()
        {
            EfInvoiceDal invoiceDal = new EfInvoiceDal();

            // Calculated Before
            decimal rightAmount = 105;

            decimal result = invoiceDal.SP_CalculateInvoiceAmount(3, 300, 3, 5);

            Assert.IsTrue(rightAmount == result);
        }
    }
}
