using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public StudentSystem()
    {
        Repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string command)
    {
        string[] studentInfo = command.Split();

        if (studentInfo[0] == "Create")
        {
            AddStudent(studentInfo);
        }
        else if (studentInfo[0] == "Show")
        {
            var name = studentInfo[1];
            if (Repo.ContainsKey(name))
            {
                ShowStudent(name);
            }
        }
    }

    private void ShowStudent(string name)
    {
        var student = Repo[name];
        string view = $"{student.Name} is {student.Age} years old.";

        if (student.Grade >= 5.00)
        {
            view += " Excellent student.";
        }
        else if (student.Grade < 5.00 && student.Grade >= 3.50)
        {
            view += " Average student.";
        }
        else
        {
            view += " Very nice person.";
        }

        Console.WriteLine(view);
    }

    private void AddStudent(string[] studentInfo)
    {
        var name = studentInfo[1];
        var age = int.Parse(studentInfo[2]);
        var grade = double.Parse(studentInfo[3]);

        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }
}
