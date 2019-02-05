using System;

public class Player
{
    private string name;
    private int overallSkill;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;

        CalculateOverallSkill();
    }

    private void CalculateOverallSkill()
    {
        OverallSkill = Endurance + Sprint + Dribble + Passing + Shooting;
    }

    public int OverallSkill
    {
        get { return overallSkill; }
        private set { overallSkill = value; }
    }

    public string Name
    {
        get { return name; }

        private set
        {
            if (String.IsNullOrEmpty(value.Trim()))
                throw new ArgumentException("A name should not be empty.");

            name = value;
        }
    }

    public int Shooting
    {
        get { return shooting; }

        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Shooting should be between 0 and 100.");

            shooting = value;
        }
    }

    public int Passing
    {
        get { return passing; }

        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Passing should be between 0 and 100.");

            passing = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }

        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Dribble should be between 0 and 100.");

            dribble = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }

        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Sprint should be between 0 and 100.");

            sprint = value;
        }
    }

    public int Endurance
    {
        get { return endurance; }

        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Endurance should be between 0 and 100.");

            endurance = value;
        }
    }
}

