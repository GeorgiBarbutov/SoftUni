using System;
using System.Collections.Generic;
using System.Linq;

public class DungeonMaster
{
    private List<Character> characterParty;
    private Stack<Item> itemsPool;
    private int lastSurvivorRounds;

    public DungeonMaster()
    {
        this.characterParty = new List<Character>();
        this.itemsPool = new Stack<Item>();
        lastSurvivorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        CharacterFactory characterFactory = new CharacterFactory();

        this.characterParty.Add(characterFactory.CreateCharacter(args[0], args[1], args[2]));

        return $"{args[2]} joined the party!";
    }
    public string AddItemToPool(string[] args)
    {
        ItemFactory itemFactory = new ItemFactory();

        this.itemsPool.Push(itemFactory.CreateItem(args[0]));

        return $"{args[0]} added to pool.";
    }
    public string PickUpItem(string[] args)
    {
        string characterName = args[0];

        Character character = this.characterParty.FirstOrDefault(x => x.Name == characterName);

        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }
        if (this.itemsPool.Count == 0)
        {
            throw new InvalidOperationException("No items left in pool!");
        }

        Item item = itemsPool.Pop();
        character.ReceiveItem(item);

        return $"{characterName} picked up {item.GetType().Name}!";
    }
    public string UseItem(string[] args)
    {
        string characterName = args[0];
        string itemName = args[1];

        Character character = characterParty.FirstOrDefault(x => x.Name == characterName);

        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        ItemFactory itemFactory = new ItemFactory();

        Item item = itemFactory.CreateItem(args[0]);
        character.UseItem(item);

        return $"{character.Name} used {itemName}.";
    }
    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character giver = characterParty.FirstOrDefault(x => x.Name == giverName);
        Character reciever = characterParty.FirstOrDefault(x => x.Name == receiverName);

        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        if (reciever == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        ItemFactory itemFactory = new ItemFactory();

        Item item = giver.Bag.GetItem(itemName);
        giver.UseItemOn(item, reciever);

        return $"{giverName} used {itemName} on {receiverName}.";
    }
    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character giver = characterParty.FirstOrDefault(x => x.Name == giverName);
        Character reciever = characterParty.FirstOrDefault(x => x.Name == receiverName);

        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        if (reciever == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        Item item = giver.Bag.GetItem(itemName);
        reciever.ReceiveItem(item);

        return $"{giverName} gave {receiverName} {itemName}.";
    }
    public string GetStats()
    {
        List<Character> sortedCharacterCollection = characterParty.OrderByDescending(x => x.IsAlive)
            .ThenByDescending(x => x.Health)
            .ToList();

        string result = String.Empty;

        foreach (var character in sortedCharacterCollection)
        {
            string status;
            if (character.IsAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }

            result += $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}" + Environment.NewLine;
        }

        return result;
    }
    public string Attack(string[] args)
    {
        string attackerName = args[0];
        string receiverName = args[1];

        Warrior attacker = (Warrior)characterParty.FirstOrDefault(x => x.Name == attackerName);
        Character receiver = characterParty.FirstOrDefault(x => x.Name == receiverName);

        if (attacker == null)
        {
            throw new ArgumentException($"Character {attackerName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }
        if (attacker.GetType().Name != "Warrior")
        {
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }

        attacker.Attack(receiver);

        string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

        if (!receiver.IsAlive)
        {
            result += Environment.NewLine + $"{receiver.Name} is dead!";
        }

        return result;
    }
    public string Heal(string[] args)
    {
        string healerName = args[0];
        string healingReceiverName = args[1];

        Cleric healer = (Cleric)characterParty.FirstOrDefault(x => x.Name == healerName);
        Character receiver = characterParty.FirstOrDefault(x => x.Name == healingReceiverName);

        if (healer == null)
        {
            throw new ArgumentException($"Character {healerName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {healingReceiverName} not found!");
        }
        if(healer.GetType().Name != "Cleric")
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }

        healer.Heal(receiver);

        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
    }
    public string EndTurn()
    {
        List<string> result = new List<string>();
        int aliveCharactersCount = 0;

        foreach (var character in this.characterParty)
        {
            if (character.IsAlive)
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                result.Add($"{character.Name} rests ({healthBeforeRest} => {character.Health})");

                aliveCharactersCount++;
            }
        }

        if (aliveCharactersCount == 0 || aliveCharactersCount == 1)
        {
            this.lastSurvivorRounds++;
        }

        return String.Join(Environment.NewLine, result);
    }
    public bool IsGameOver()
    {
        if(lastSurvivorRounds > 1)
        {
            Console.WriteLine("Final stats:");
            Console.WriteLine(GetStats());

            return true;
        }
        else
        {
            return false;
        }
    }

    public int LastSurvivorRounds
    {
        get { return lastSurvivorRounds; }
        private set { lastSurvivorRounds = value; }
    }
}

