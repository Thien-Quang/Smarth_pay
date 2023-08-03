using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smarthr_pay
{
    public class employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public decimal PayRate { get; set; }
        public decimal PaidToDate { get; set; }
        public decimal PaidLastYear { get; set; }
        public decimal PayAmount { get; set; }
        public decimal TaxPercentage { get; set; }

        public double total = 0;

        public employee(int employeeId, string fullName, string department, decimal payRate, decimal paidToDate, decimal paidLastYear, decimal payAmount, decimal taxPercentage)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Department = department;
            PayRate = payRate;
            PaidToDate = paidToDate;
            PaidLastYear = paidLastYear;
            PayAmount = payAmount;
            TaxPercentage = taxPercentage;
            this.total = (double) payAmount * ((double)payRate - (double)taxPercentage);
        }
    }
   
}