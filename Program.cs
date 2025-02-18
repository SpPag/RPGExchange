using System.Diagnostics.Metrics;

int heroHP = 100;
int monsterHP = 100;
Random random = new Random();
int attackDamage;
string target;
int roundCounter = 0;

// Returns an appropriate color based on the HP level and whether it's the hero or monster.
ConsoleColor GetHPColor(int hp, bool isHerosTurn)
{
    // For demonstration, the color starts bright and dims as HP decreases.
    if (isHerosTurn)
    {
        if (hp > 50)
            return ConsoleColor.Green;       // Bright green at high HP
        else if (hp > 0)
            return ConsoleColor.DarkGreen;    // Very dim when HP is low
        else
            return ConsoleColor.DarkGray;
    }
    else // Monster's color logic
    {
        if (hp > 50)
            return ConsoleColor.Red;         // Bright red at high HP        
        else if (hp > 0)
            return ConsoleColor.DarkRed;    // Very dim when HP is low
        else
            return ConsoleColor.DarkGray;
    }
}

while (heroHP > 0 && monsterHP > 0)
{
    roundCounter += 1;

    attackDamage = random.Next(1, 11);
    if (roundCounter % 2 == 0)
    {
        target = "Hero";
        heroHP -= attackDamage;
        // Set color based on hero's HP and base color (green)
        Console.ForegroundColor = GetHPColor(heroHP, isHerosTurn: false);
    }
    else
    {
        target = "Monster";
        monsterHP -= attackDamage;
        // Set color based on monster's HP and base color (red)
        Console.ForegroundColor = GetHPColor(monsterHP, isHerosTurn: true);
    }

    Console.WriteLine($"{target} was damaged and lost {attackDamage} health and now has {(target == "Hero" ? heroHP : monsterHP)} health\n");

    // Simulate sound (console beep) for an added effect
    //Console.Beep(500, 200); // Frequency of 500Hz, duration 200ms

    await Task.Delay(400);
}
// Display the winner
Console.ForegroundColor = ConsoleColor.Cyan; // Set color to cyan for the final winner
Console.WriteLine(heroHP > 0 ? "Hero wins!" : "Monster wins!");

// Play a distinct sound when the battle ends
//Console.Beep(1000, 500); // High-pitched beep (1000Hz) for half a second

// Reset console color
Console.ResetColor();

Console.WriteLine("Press Enter to close the application");
Console.ReadLine();