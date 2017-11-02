using MKValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkValidatorTest
{
    class MkValidatorTest
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Name = "Mohd Mukammil";
            employee.Email = "abc@gmail.com";
            employee.Age = 25;
            employee.MobileNumber = "7895869325";
            employee.Remarks = "Test Remarks";
            employee.Salary = "";

            string errorMessage = string.Empty;

            #region Method 1 To Get Error Message
            try
            {
                if(MKValidator.MKValidator.Check<Employee>(employee))
                {
                    // Do your work here
                }
                
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message; // Getting Error Message From MKValidator
            }
            #endregion

            #region Method 2 To Get Error Message 
            
            if (MKValidator.MKValidator.Check<Employee>(employee,ref errorMessage))
            {
                // Do your work here
            }
            Console.WriteLine("Error Message = " + errorMessage);
            #endregion
        }

        public class Employee
        {
            public int Id { get; set; }

            [ValidateRequired] // Required Validation Applied
            public string Name { get; set; }

            [ValidateEmail] // Email Validation Applied
            public string Email { get; set; }

            [ValidateRequired] // Required Validation Applied
            [ValidateRegularExpression(@"\d||\d.\d")] // Regular Expression Validation Applied
            public string Salary { get; set; }

            [ValidateLength(11)] // Length Validation Applied
            public string MobileNumber { get; set; }

            public string Remarks { get; set; }

            [ValidateNumber] // Number Validation Applied
            [ValidateRange(1, 150)] // Number Range Validation Applied
            public int Age { get; set; }
        }
    }
}
