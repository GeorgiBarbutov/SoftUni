using System;

class Program
{
    static void Main(string[] args)
    {
        string[] studentInfo = Console.ReadLine().Split(' ');
        string[] workerInfo = Console.ReadLine().Split(' ');

        try
        {
            Student student = CreateStudent(studentInfo);
            Worker worker = CreateWorker(workerInfo);
            Print(student, worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Print(Student student, Worker worker)
    {
        Console.WriteLine(student + Environment.NewLine);
        Console.WriteLine(worker);
    }

    private static Worker CreateWorker(string[] workerInfo)
    {
        string workerFirstName = workerInfo[0];
        string workerSecondName = workerInfo[1];
        decimal workerWeekSalary = decimal.Parse(workerInfo[2]);
        decimal workerHoursPerday = decimal.Parse(workerInfo[3]);

        Worker worker = new Worker(workerFirstName, workerSecondName, workerWeekSalary, workerHoursPerday);
        return worker;
    }

    private static Student CreateStudent(string[] studentInfo)
    {
        string studentFirstName = studentInfo[0];
        string studentSecondName = studentInfo[1];
        string studentFacultyNumber = studentInfo[2];

        Student student = new Student(studentFirstName, studentSecondName, studentFacultyNumber);
        return student;
    }
}

