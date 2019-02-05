using System;

public class Dough
{
    const int CALORIES_PER_GRAM = 2;

    private string flourType;
    private string bakingTechnique;
    private double weight;
    private double totalCalories;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
        CalculateTotalCalories();
    }

    private void CalculateTotalCalories()
    {
        double flourTypeModifier = 1;
        double bakingTechniqueModifier = 1;

        SetModifiers(ref flourTypeModifier, ref bakingTechniqueModifier);

        TotalCalories = (CALORIES_PER_GRAM * Weight) * flourTypeModifier * bakingTechniqueModifier;
    }

    private void SetModifiers(ref double flourTypeModifier, ref double bakingTechniqueModifier)
    {
        if (FlourType == "White")
            flourTypeModifier = 1.5;
        else if (FlourType == "Wholegrain")
            flourTypeModifier = 1.0;

        if (BakingTechnique == "Crispy")
            bakingTechniqueModifier = 0.9;
        else if (BakingTechnique == "Chewy")
            bakingTechniqueModifier = 1.1;
        else if (BakingTechnique == "Homemade")
            bakingTechniqueModifier = 1.0;
    }

    public double TotalCalories
    {
        get { return totalCalories; }
        private set { totalCalories = value; }
    }

    private double Weight
    {
        get { return weight; }

        set
        {
            if (value < 1 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");

            weight = value;
        }
    }

    private string BakingTechnique
    {
        get { return bakingTechnique; }

        set
        {
            if (!(value == "Crispy" || value == "Chewy" || value == "Homemade"))
                throw new ArgumentException("Invalid type of dough.");

            bakingTechnique = value;
        }
    }

    private string FlourType
    {
        get { return flourType; }

        set
        {
            if (!(value == "White" || value == "Wholegrain"))
                throw new ArgumentException("Invalid type of dough.");

            flourType = value;
        }
    }
}

