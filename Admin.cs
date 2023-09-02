namespace SimplePayroll;

// child class of parent class staff
public class Admin : Staff
{
    // field or variable
    private const float overtimeRate = 15.5f; //default type for 15.5 is double. use suffix 'f' to change to float type.
    private const float adminHourlyRate = 30;

    // property
    public float Overtime { get; private set; }

    // constructor
    public Admin(string name) : base(name, adminHourlyRate) { }

    // method
    public override void CalculatePay()
    {
        base.CalculatePay();
        if (HoursWorked > 160)
            Overtime = overtimeRate * (HoursWorked - 160);
        TotalPay += Overtime;
        // or use Overtime = (float)(overtimeRate * (HoursWorked - 160)); if the overtimerate is set to other type
    }

    public override string ToString()
    {
        return "Name of Staff = " + NameOfStaff +
        ", Admin Hourly Rate = " + adminHourlyRate +
        ", Working Hours = " + HoursWorked +
        ", Basic Pay = " + BasicPay +
        ", Overtime Pay = " + Overtime +
        ", Total Pay = " + TotalPay;
    }

}
