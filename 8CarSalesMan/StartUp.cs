using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int N= int.Parse(Console.ReadLine());

            Dictionary<string,Engine> EnginesAll = new Dictionary<string, Engine>();

            for (int i = 1; i <= N; i++)
            {
                string[] ArrEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = ArrEngine[0];
                int power = int.Parse(ArrEngine[1]);

                int displacement= 0;
                string efficiency= "";

                if (ArrEngine.Length == 2)
                {
                    Engine newEngine = new Engine(model, power);
                    EnginesAll.Add(model,newEngine);

                }
                else if (ArrEngine.Length ==3)
                {
                    string thirdparameter = ArrEngine[2];
                    if (int.TryParse(thirdparameter, out int displacement1))
                    {
                        Engine newEngine = new Engine(model, power, displacement1);
                        EnginesAll.Add(model, newEngine);
                    }

                    else
                    {
                        string efficiency1 = ArrEngine[2];
                        Engine newEngine = new Engine(model, power, efficiency1);
                        EnginesAll.Add(model, newEngine);
                    }
                }
                else if (ArrEngine.Length == 4)
                {
                    displacement = int.Parse(ArrEngine[2]);
                    efficiency = ArrEngine[3];

                    Engine newEngine = new Engine(model, power,displacement,efficiency);
                    EnginesAll.Add(model, newEngine);
                }

                //Engine engine1 = new Engine();
                //engine1.Model = model;
                //engine1.Power = power;
                //engine1.Displacement = displacement;
                //engine1.Efficiency = efficiency;

              

            }

            
            List<Car> CarsAll = new List<Car>();
            
            
            int M = int.Parse(Console.ReadLine());

            for (int i = 1; i <= M; i++)
            {
                string[] ArrForCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                string model = ArrForCar[0];
                string  engine= ArrForCar[1];

                int weight= 0;
                string color= "";

                if (ArrForCar.Length == 2)
                {
                    Engine engine2 = EnginesAll[engine];// s Key access value Object Engine
                    Car car1 = new Car(model, engine2);
                    CarsAll.Add(car1);
                }
                else if (ArrForCar.Length==3)
                {
                    if (EnginesAll.ContainsKey(engine))
                    {
                        Engine engine2 = EnginesAll[engine];// s Key access value Object Engine

                        string thirdParam = ArrForCar[2]; // weight or color

                        if (int.TryParse(thirdParam, out int weight1))
                        {
                            Car car1 = new Car(model, engine2, weight);
                            CarsAll.Add(car1);
                        }


                        else
                        {
                            string color1 = ArrForCar[2];
                            Car car1 = new Car(model, engine2, color1);

                            CarsAll.Add(car1);

                        }

                            // Car car1 = new Car(model, engine2);
                            // CarsAll.Add(car1);

                            //weight = int.Parse(ArrForCar[2]);

                        }
                
                
                
                
                
                }
                else if (ArrForCar.Length == 4)
                {
                    if (EnginesAll.Any(e => e.Value.Model == engine))
                    {
                        weight = int.Parse(ArrForCar[2]);
                        color = ArrForCar[3];
                        Engine engine2 = EnginesAll[engine];// s Key access value Object Engine
                        Car car1 = new Car(model, engine2, weight, color);
                        CarsAll.Add(car1);
                    }
                 
                }

                //Car car1 = new Car();
               // car1.Model = model;

               // car1.Weight = weight;
               // car1.Color = color;
               // car1.Engine = engine2;

               
            }

            foreach (Car car in CarsAll)
            {

                //  Console.WriteLine(car.ToString());

                int displacement = car.Engine.Displacement;
                string efficiency = car.Engine.Efficiency;

                int weight = car.Weight;
                string color = car.Color;


                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (displacement == 0)
                {
                    Console.WriteLine("    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (efficiency == null)//"")
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {

                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                if (color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
