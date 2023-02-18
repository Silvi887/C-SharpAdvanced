

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Queue<int> textilesCol= new Queue<int>
     (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

Stack<int> medicamentsCol= new Stack<int>
          (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

//int CurrentTextile = textilesCol.Dequeue();
//int CurrentMedicament = medicamentsCol.Pop();

Dictionary<string, int> HealingItems= new Dictionary<string, int>();

HealingItems.Add("Patch",30);
HealingItems.Add("Bandage",40);
HealingItems.Add("MedKit",100);

Dictionary <string,int> CreatedHealingItems= new Dictionary<string,int>();


int Result = 0;
int Remain = 0;

while (textilesCol.Count >0  && medicamentsCol.Count>0)
{
    int MedicamnetEl = medicamentsCol.Peek() + Remain;
    Result = textilesCol.Peek() + MedicamnetEl;
    if (textilesCol.Count == 0 || medicamentsCol.Count == 0)
    {
        break;
    }
    bool IsEqual = false;
    foreach (var healing in HealingItems)
    {
        if (Result== healing.Value)
        {
            Remain = 0;
            if (!CreatedHealingItems.ContainsKey(healing.Key))
            {
                CreatedHealingItems.Add(healing.Key, 1);
            }
            else
            {
                CreatedHealingItems[healing.Key]++;//Increase Value
            }

            textilesCol.Dequeue(); //Remove
            medicamentsCol.Pop();
            IsEqual = true;
            break;
        }
    }

    if (!IsEqual)
    {
        if (textilesCol.Count > 0 || medicamentsCol.Count > 0)
        {
            if (Result > HealingItems["MedKit"])
            {
                if (!CreatedHealingItems.ContainsKey("MedKit"))
                {
                    CreatedHealingItems.Add("MedKit", 1);//Create
                }
                else
                {
                    CreatedHealingItems["MedKit"]++;//Increase Value
                }

                int currentTexile = textilesCol.Dequeue(); //Remove
                int CurrentMed = medicamentsCol.Pop();

                Remain = Result - HealingItems["MedKit"];//For med

                //int Newmedicament = CurrentMed + Remain;
                // medicamentsCol.Push(Newmedicament);

            }
            else
            {
                textilesCol.Dequeue(); //Remove
                int CurrentMed1 = medicamentsCol.Pop() + 10;
                medicamentsCol.Push(CurrentMed1);
                Remain = 0;
            }
        }
    }

}

//Print  textilesCol
 if (textilesCol.Count == 0 && medicamentsCol.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (textilesCol.Count == 0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (medicamentsCol.Count ==0)
{
    Console.WriteLine("Medicaments are empty.");
}



if (CreatedHealingItems.Count >0)
{
    foreach (var healing in CreatedHealingItems
                        .OrderByDescending(m=> m.Value)
                        .ThenBy(m => m.Key))
    {
        Console.WriteLine($"{healing.Key} - {healing.Value}");
    }
    
}

if (medicamentsCol.Count > 0)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("Medicaments left: ");
    sb.Append(String.Join(", ",medicamentsCol));
    Console.WriteLine(sb.ToString());
}

if (textilesCol.Count > 0)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("Textiles left: ");

    sb.Append((String.Join(", ", textilesCol)));
    Console.WriteLine(sb.ToString());

}