namespace SimplePayroll;
public class FileReader
{
    List<Staff> myStaff = new List<Staff>();
    string[] result = new string[2];
    string path = "staff.txt";
    string[] separator = { ", " };
    // create a method to read .txt file that consists of the names and positions of the staff.
    public List<Staff> ReadFile()
    {
        if (File.Exists(path))
        {
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    result = sr.ReadLine().Split(separator, StringSplitOptions.None);
                    if (result[1] == "Manager")
                        myStaff.Add(new Manager(result[0]));
                    else if (result[1] == "Admin")
                        myStaff.Add(new Admin(result[0]));
                }
                sr.Close();
            }
        }
        else
        {
            Console.WriteLine("Error: File does not exists!");
        }
        return myStaff;
    }
}
