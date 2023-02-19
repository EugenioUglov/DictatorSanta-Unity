using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStrings : MonoBehaviour
{
    private Dictionary<string, string> strings = new Dictionary<string, string>();

    private void Awake()
    {
        // strings.Add(Key.workersarecold.ToString(), "Santa! Our workers are cold. We need to take urgent action.\nBuy warm clothes for your subordinates for 400 gold?");
        // strings.Add(Key.paymentсomplaint.ToString(), "Our workers are thinking that not getting enough paid and they went on strike.\nDo you want to shoot half of the workers?");
        // strings.Add(Key.killedemployeesresult.ToString(), "Shed blood. The rest of the workers are scared. Dark silence. The remaining workers dutifully continue to work in fear.");
        // strings.Add(Key.brokenpresents.ToString(), "Part of the presents were broken.\nTake money from employees who caused this problem (300 gold)?");
        // strings.Add(Key.productiveday.ToString(), "A good day! Today, more products have been created than required. Employees are in good spirits.\nRelease all workers a few hours early?");
        // strings.Add(Key.covid.ToString(), "Some employees took Covid.\nSend them for treatment?");
        // strings.Add(Key.pandemic.ToString(), "Symptoms begin to show up in other workers as well. It looks like a pandemic.");
        // strings.Add(Key.magicelixir.ToString(), "Boss, can we drink a glass of magic elixir in order to work better?\nIt's a colorless elixir that's a little intoxicating, but you want to make us happy at work, don't you?");
        // strings.Add(Key.injuretment.ToString(), "Our employee was injured at work. Allocate 100 gold for his treatment?");
        // strings.Add(Key.goodsdamage.ToString(), "One of the employees accidentally damaged the goods. The cost of new materials will be 250 gold.\nExecute an employee?");
        // strings.Add(Key.sniffing.ToString(), "Santa, I saw a colleague sniffing fairy dust.\nFire the junkie?");
        // strings.Add(Key.toxicsubstances.ToString(), "Employees complain about toxic substances that are used to reduce the cost of goods.\nStop production for 2 days and allocate 1000 gold to buy quality materials?");
        // strings.Add(Key.tiredemployees.ToString(), "Subordinates collapse from exhaustion and beg for one day off.\nAgree?");
        // strings.Add(Key.ditructedemployees.ToString(), "Subordinates were often distracted from work due to poor working conditions.\nMonitor subordinates and punish if they were observed by doing something instead of work?");
        
        

        // strings.Add(Key.happyemployeesresult.ToString(), "Employees are happy of your decision. They are motivated to work even harder.");
        // strings.Add(Key.happyemployeesoncomebackresult.ToString(), "Employees are happy with this decision and are ready to work with great diligence after returning to work.");
        // strings.Add(Key.workintoxicresult.ToString(), "Employees are very frustrated and work in a toxic environment. Part of the team quit their jobs.");
        // strings.Add(Key.magicelixirresult.ToString(), "Partial drop efficiency. They also interfere with the rest of the work.");
        // strings.Add(Key.difficultconditionsresult.ToString(), "Employees are working with their remaining strength and curse such working conditions.. Part of the team quit their jobs.");
        // strings.Add(Key.frustratedemployeesresult.ToString(), "Employees are very frustrated to work in this kind of condition.\nPart of the team quit their jobs.");

        // strings.Add(Key.goodchristmasfinal.ToString(), "Your subordinates are satisfied with your rule!\n You did a good job and this Christmas will be unforgettable!");
        // strings.Add(Key.nightmarechristmasfinal.ToString(), "Your subordinates are horrified by your rule!\n You made this Christmas a nightmare for all the inhabitants of the planet!");
        // strings.Add(Key.sadchristmasfinal.ToString(), "Production has stopped. This Christmas people will pass in sadness.");
        // strings.Add(Key.noemployeesfinal.ToString(), "You have no more employees.\n");
        // strings.Add(Key.nogoldfinal.ToString(), "You have no more gold.\n");
        // strings.Add(Key.laborinfo.ToString(), "The labor of the workers is paid.");
        // strings.Add(Key.goldinfo.ToString(), "gold for each worker per a day.");

        // SARA CHANGES.

        strings.Add(Key.workersarecold.ToString(), "Santa! Our workers are cold. We need to take urgent action.\nBuy warm clothes for your subordinates for 400 gold?");
        strings.Add(Key.paymentсomplaint.ToString(), "Our workers are saying they don't get paid enough so they went on strike.\nDo you want to shoot half of the workers?");
        strings.Add(Key.killedemployeesresult.ToString(), "Bloodshed. The rest of the workers are scared. Dark silence. The remaining workers dutifully continue to work in fear.");
        strings.Add(Key.brokenpresents.ToString(), "Part of the presents were broken.\nTake money from the employees who caused this problem (300 gold)?");
        strings.Add(Key.productiveday.ToString(), "A good day! Today, more toys have been created than the ones required. The employees are in good spirits.\nRelease all workers a few hours early?");
        strings.Add(Key.covid.ToString(), "Some employees took COWID virus.\nSend them to the hospital for treatment?");
        strings.Add(Key.pandemic.ToString(), "Symptoms begin to show in other workers as well. Looks like a pandemic.");
        strings.Add(Key.magicelixir.ToString(), "Boss, can we drink a glass of magic elixir in order to work better?\nIt's a colorless elixir that's a little intoxicating, but you want to make us happy at work, don't you?");
        strings.Add(Key.injuretment.ToString(), "One of our employees was injured at work. Allocate 100 gold for his treatment?");
        strings.Add(Key.goodsdamage.ToString(), "One of the employees accidentally damaged the goods. The cost of new materials will be 250 gold.\nExecute an employee?");
        strings.Add(Key.sniffing.ToString(), "Santa, I saw a colleague sniffing fairy dust.\nFire the junkie?");
        strings.Add(Key.toxicsubstances.ToString(), "Employees complain about toxic substances that are used to reduce the cost of toys.\nStop production for 2 days and allocate 1000 gold to buy quality materials?");
        strings.Add(Key.tiredemployees.ToString(), "Subordinates collapse from exhaustion and beg for one day off.\nAgree?");
        strings.Add(Key.ditructedemployees.ToString(), "Subordinates were often distracted from work due to poor working conditions.\nMonitor subordinates and punish them if they are observed doing something instead of working?");
       
        strings.Add(Key.wagesComplaints.ToString(), "The workers are complaining about their wages not being enough. Increase salary by 20 gold for each employee?");
        strings.Add(Key.saleWorkers.ToString(), "Boss, there is an opportunity to earn extra money, hehe. We get 5,000 gold if we transfer 3 of our workers to Krampus Entertainment. The organization, of course, is shady and their practices are unclear, but the money is good. Sell ​​workers?");
        strings.Add(Key.gunForAnimalOrder.ToString(), "Sir, an order came in from an unknown gentleman. He will pay 2000 gold if we craft a weapon for hunting animals. Accept this job?");
        strings.Add(Key.fireResistance.ToString(), "Recently, we have produced many goods with highly flammable substances. The factory is not adequately equipped with fire fighting equipment. Buy fire safety equipment for 1000 gold?");
        strings.Add(Key.foodForMagicalDeer.ToString(), "Food for the magical reindeers is over. Buy pet food for 200 gold?");
        strings.Add(Key.giftTheft.ToString(), "Sir, we have a thieving employee who is taking some of the Christmas presents for himself. Fire him?");
        strings.Add(Key.sabotage.ToString(), "I saw how one of our employees is trying to sabotage our work by planting fireworks in different places of the factory, which can be blown up at any moment. Fire him?");
        strings.Add(Key.hardmachines.ToString(), "Boss, the workers are complaining that the gift making equipment is very difficult to operate. Can we afford to spend 4,000 gold. to buy new assembling machines? ");



        strings.Add(Key.happyemployeesresult.ToString(), "Employees are happy with your decision. They are motivated to work even harder.");
        strings.Add(Key.happyemployeesoncomebackresult.ToString(), "Employees are happy with this decision and are ready to work with great diligence after returning.");
        strings.Add(Key.workintoxicresult.ToString(), "Employees are very frustrated and work in a toxic environment. Part of the staff quit their job.");
        strings.Add(Key.magicelixirresult.ToString(), "Partial drop efficiency. They also interfere with the rest of the work.");
        strings.Add(Key.difficultconditionsresult.ToString(), "Employees are working with their remaining strength and curse such working conditions.. Part of the staff quit their job.");
        strings.Add(Key.frustratedemployeesresult.ToString(), "Employees are very frustrated to work in this kind of condition.\nPart of the staff quit their job.");


        strings.Add(Key.amazingchristmasfinal.ToString(), "Your subordinates are satisfied with your rule!\n You did a good job and this Christmas will be unforgettable!");
        strings.Add(Key.nightmarechristmasfinal.ToString(), "Your subordinates are horrified by your rule!\n You made this Christmas a nightmare for all the inhabitants of the planet!");
        strings.Add(Key.sadchristmasfinal.ToString(), "Production has stopped. This Christmas will be spent in sadness by all the inhabitants of the world.");
        strings.Add(Key.noemployeesfinal.ToString(), "You have no more employees.\n");
        strings.Add(Key.nogoldfinal.ToString(), "You have no more gold.\n");
        strings.Add(Key.goodchristmasfinal.ToString(), "It will be a good Christmas.");
        strings.Add(Key.nosatisfiedworkersfinal.ToString(), "However the workers were not satisfied with your rule at the factory.");
        strings.Add(Key.laborinfo.ToString(), "The labor of the workers is paid.");
        strings.Add(Key.goldinfo.ToString(), "gold for each worker per day.");
    }

    public enum Key
    {
        workersarecold,
        paymentсomplaint,
        brokenpresents,
        productiveday,
        covid,
        magicelixir,
        pandemic,
        goodsdamage,
        sniffing,
        tiredemployees,
        injuretment,
        ditructedemployees,
        toxicsubstances,
        hardmachines,
        sabotage,
        giftTheft,
        foodForMagicalDeer,
        fireResistance,
        gunForAnimalOrder,
        saleWorkers,
        wagesComplaints,

        workintoxicresult,
        killedemployeesresult,
        happyemployeesresult,
        magicelixirresult,
        happyemployeesoncomebackresult,
        difficultconditionsresult,
        frustratedemployeesresult,

        noemployeesfinal,
        nogoldfinal,
        goodchristmasfinal,
        amazingchristmasfinal,
        sadchristmasfinal,
        nightmarechristmasfinal,
        nosatisfiedworkersfinal,

        laborinfo,
        goldinfo
    }

    public string GetString(Key key)
    {
        return strings[key.ToString()];
    }
}
