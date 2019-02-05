using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        CreateListOfTrainers(trainers);
        UpdatePokemons(trainers);
        Print(trainers);
    }

    private static void Print(List<Trainer> trainers)
    {
        List<Trainer> sortedTrainerList = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

        foreach (var trainer in sortedTrainerList)
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.NumberOfPokemons()}");
        }
    }

    private static void UpdatePokemons(List<Trainer> trainers)
    {
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                trainer.CheckForElement(input);
            }
        }
    }

    private static void CreateListOfTrainers(List<Trainer> trainers)
    {
        string input;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] inputArguments = input.Split(' ');

            Pokemon pokemon = new Pokemon(inputArguments.Skip(1).ToArray());

            string trainerName = inputArguments[0];
            Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

            if (trainers.Contains(trainer))
            {
                trainers[trainers.IndexOf(trainer)].AddPokemonToList(pokemon);
            }
            else
            {
                Trainer newTrainer = new Trainer(trainerName, pokemon);
                trainers.Add(newTrainer);
            }
        }
    }
}

