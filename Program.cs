namespace SimplePayroll;

public class Program
{
    static void Main(string[] args)
    {
        List<Staff> myStaff1 = new List<Staff>();
        FileReader fr = new FileReader(); // return a list
        int month = 0;
        int year = 0;

        // Prompt User to input the year and month 
        while (year == 0)
        {
            Console.Write("\nPlease enter the year: ");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "You did not enter an integer. Please enter an integer.");
            }
        }

        while (month == 0)
        {
            Console.Write("\nPlease enter the month: ");
            try
            {
                month = Convert.ToInt32(Console.ReadLine());
                if (!(1 <= month && month <= 12))
                {
                    Console.WriteLine("Error: Please enter a value between 1 to 12");
                    month = 0;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "You did not enter an integer. Please enter an integer.");
            }
        }


        myStaff1 = fr.ReadFile();
        for (int i = 0; i < myStaff1.Count; i++)
        {
            try
            {
                // Input number of hours worked for all the staff. New staff can be added in staff.txt
                Console.Write($"\nEnter hours worked for {myStaff1[i].NameOfStaff}: ");
                myStaff1[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                myStaff1[i].CalculatePay();

                Console.WriteLine(myStaff1[i].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                i--;
            }
        }

        PaySlip ps = new PaySlip(month, year);
        ps.GeneratePaySlip(myStaff1);
        ps.GenerateSummary(myStaff1);

        Console.WriteLine($"\nPaySlip for Year: {year} Month: {month} is generated!");
        Console.Read();
    }


}