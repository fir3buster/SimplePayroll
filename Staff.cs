namespace SimplePayroll;

// contains basec information about an employee and porivdes a method for calculating basic pay
// serve as parent class of Manager class and Admin class
public class Staff
{
    // private field for hourly rate and working hours
    private float hourlyRate;
    private int hWorked; //(backing field for HoursWorked)

    // properties for total and basic pay, name of staff, and working hours from private field.
    public float TotalPay { get; protected set; }
    public float BasicPay { get; private set; }
    public string NameOfStaff { get; private set; }
    public int HoursWorked
    {
        get
        {
            return hWorked;
        }
        set
        {
            if (value > 0)
                hWorked = value;
            else hWorked = 0;
        }
    }

    // create a constructor with two parameters, name and rate.
    public Staff(string name, float rate)
    {
        NameOfStaff = name;
        hourlyRate = rate;
    }

    // create a virtual method or function,
    // virutal method is allowed to be overwritten in a derived class
    public virtual void CalculatePay()
    {
        Console.WriteLine("Calculate Pay...");
        BasicPay = hWorked * hourlyRate;
        TotalPay = BasicPay;
    }

    public override string ToString()
    {
        return "Name of Staff = " + NameOfStaff + 
                ", Hourly Rate = " + hourlyRate + 
                ", Working Hours = " + hWorked + 
                ", Basic Pay = " + BasicPay + 
                ", Total Pay = " + TotalPay;
    }


}
