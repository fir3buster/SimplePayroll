namespace SimplePayroll;

public class PaySlip
{
    private int month;
    private int year;

    // access modifier for enum is private by default
    enum MonthsOfYear 
    {
        JAN = 1,
        FEB = 2,
        MAR = 3,
        APR = 4,
        MAY = 5,
        JUNE = 6,
        JUL = 7,
        AUG = 8,
        SEPT = 9,
        OCT = 10,
        NOV = 11,
        DEC = 12
    }

    // Constructor of payslip
    public PaySlip(int payMonth, int payYear)
    {
        month = payMonth;
        year = payYear;
    }

    // Method GeneratePaySlip()
    // Takes in a list of Staff objects and does not return anything.
    public void GeneratePaySlip(List<Staff> myStaff)
    {
        string path;
        foreach (Staff f in myStaff)
        {
            path = f.NameOfStaff + "" + year + "_" + month + ".txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                // creating a payslip
                sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year} ");
                sw.WriteLine("======================================");
                sw.WriteLine($"Name of Staff: {f.NameOfStaff}");
                sw.WriteLine($"Hours Worked: {f.HoursWorked}");
                sw.WriteLine("");
                sw.WriteLine($"Basic Pay: {f.BasicPay:C}");
                if (f.GetType() == typeof(Admin))
                    sw.WriteLine($"Overtime: {((Admin)f).Overtime:C}"); // cast f into Staff object to access the overtime property
                else if (f.GetType() == typeof(Manager))
                    sw.WriteLine($"Allowance: {((Manager)f).Allowance:C}"); //cast f into Manager object to access the allowance property
                sw.WriteLine("");
                sw.WriteLine("======================================");
                sw.WriteLine($"Total Pay: {f.TotalPay:C}");
                sw.WriteLine("======================================");
                sw.Close();
            }
        }
    }

    // Method GenerateSummary()
    // to generate a summary of employees who worked less than 10 hours in that month.
    public void GenerateSummary(List<Staff> staffCollection)
    {
        var result = from staffMember in staffCollection
                     where staffMember.HoursWorked < 10
                     orderby staffMember.NameOfStaff ascending
                     select new { staffMember.NameOfStaff, staffMember.HoursWorked };

        // path = where information of all staffmember worked less than 10 hours is recorded.
        string path = "summary" + year + "_" + month + ".txt";
        using (StreamWriter swStaff = new StreamWriter(path, false))
        {
            swStaff.WriteLine("Staff with less than 10 working hours.");
            swStaff.WriteLine("");

            foreach (var staffMember in result)
            {
                swStaff.WriteLine($"Name of Staff: {staffMember.NameOfStaff}, Hours Worked: {staffMember.HoursWorked}");
            }
            swStaff.Close();
        };
    }

    // Method override ToString()
    public override string ToString()
    {
        return "Month = " + month + " Year = " + year;
    }
}
