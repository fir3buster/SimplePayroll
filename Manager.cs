namespace SimplePayroll;

// child class of Staff Class
public class Manager : Staff
{
    // field or variable
    private const float managerHourlyRate = 50;

    // property
    public int Allowance { get; private set; }

    // Constructor
    public Manager(string name) : base(name, managerHourlyRate) { }

    // method to override the CalculatePay() in parent class
    public override void CalculatePay()
    {
        // setting the values of basic pay and total pay by calling the calculatepay method from parent class
        // use 'base' keyword to call a virtual method from parent class
        base.CalculatePay();
        Allowance = 1000;
        if (HoursWorked > 160)
            TotalPay += Allowance;
        else Allowance = 0;
    }

    public override string ToString()
    {
        //return base.ToString();
        return "Name of Staff = " + NameOfStaff +
        ", Manager Hourly Rate = " + managerHourlyRate +
        ", Working Hours = " + HoursWorked +
        ", Basic Pay = " + BasicPay +
        ", Allowance = " + Allowance +
        ", Total Pay = " + TotalPay;
    }

}
