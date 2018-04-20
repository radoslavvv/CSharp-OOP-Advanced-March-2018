using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });

            this.heroes.Add(heroName, hero);

            //bug
            result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> arguments)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);

        this.heroes[heroName].AddItem(newItem);


        //bug?
        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);

        return result;
    }

    public string AddRecipe(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IList<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, requiredItems);

        this.heroes[heroName].AddRecipe(newRecipe);

        //bug?
        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);

        return result;
    }

    public string Inspect(IList<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit(IList<string> argsList)
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;
        foreach (var hero in this.heroes.OrderByDescending(h => h.Value.PrimaryStats).ThenByDescending(h => h.Value.SecondaryStats))
        {
            sb.AppendLine($"{counter}. {hero.Value.GetType().Name}: {hero.Value.Name}");
            sb.AppendLine($"###HitPoints: {hero.Value.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Value.Damage}");
            sb.AppendLine($"###Strength: {hero.Value.Strength}");
            sb.AppendLine($"###Agility: {hero.Value.Agility}");
            sb.AppendLine($"###Intelligence: { hero.Value.Intelligence}");

            if(hero.Value.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.AppendLine($"###Items: {string.Join(", ", hero.Value.Items.Select(i=>i.Name))}");
            }

            counter++;
        }

        return sb.ToString().Trim();
    }


    private string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString().Trim();
    }
}