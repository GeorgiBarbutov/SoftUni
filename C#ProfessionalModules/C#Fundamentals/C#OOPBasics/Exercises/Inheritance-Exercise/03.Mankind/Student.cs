using System;
using System.Linq;

public class Student : Human
{
    private string facultyNumber;

    public Student(string studentFirstName, string studentSecondName, string studentFacultyNumber)
        :base(studentFirstName, studentSecondName)
    {
        FacultyNumber = studentFacultyNumber;
    }

    public override string ToString()
    {
        return $"First Name: {base.FirstName}" + Environment.NewLine +
            $"Last Name: {base.SecondName}" + Environment.NewLine +
            $"Faculty number: {this.FacultyNumber}";
    }

    private string FacultyNumber
    {
        get { return facultyNumber; }

        set
        {
            if (value.Length < 5 || value.Length > 10 || value.Any(p => !Char.IsLetterOrDigit(p)))
                throw new ArgumentException("Invalid faculty number!");

            facultyNumber = value;
        }
    }

}