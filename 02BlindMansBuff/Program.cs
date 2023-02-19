
using System;
using System.Linq;

string[] Dimention = Console.ReadLine().
    Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();



int N = int.Parse(Dimention[0]);

int M = int.Parse(Dimention[1]);
string[,] PlayGround = new string[N, M];

for (int row = 0; row < N; row++)
{
    string[] Entered = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    for (int col = 0; col < M; col++)
    {
        PlayGround [row, col] = Entered[col];
    }

}

//CounOponents
int AllOponents = 0;

//Random rnd = new Random();
int PlayerRows = 0;
int PlayerCols = 0;

int PlayerRowPrevios = 0;
int PlayerColsPrevios = 0;

string command = "";

int TouchesOp = 0;
int Moves = 0;

for (int row = 0; row < PlayGround.GetLength(0); row++)
{

    for (int col = 0; col < PlayGround.GetLength(1); col++)
    {
        if(PlayGround[row, col] == "P")
        {
            AllOponents++;
        }
        if (PlayGround[row, col] =="B")
        {
             PlayerRows =row;
             PlayerCols = col;
        }
    }
  
}



while ((command= Console.ReadLine())!= "Finish")
{

     PlayerRowPrevios = PlayerRows;
     PlayerColsPrevios = PlayerCols;

    if (TouchesOp == AllOponents)
    {
        PlayGround[PlayerRows, PlayerCols] = "B";
        break;
    }

    //if (TouchesOp == AllOponents)
    //{
    //    break;
    //}
    if (command == "down")
    {
       
            PlayerRows++;
        
        //int Currentpos = ++PlayerRows;
        //if (Currentpos >=0 && Currentpos <N)
        //{
            
        //}6
        //else
        //{
        //    PlayerRows--;
        //}
       
    }
    if (command == "up")
    {
        
            PlayerRows--;
        
           
      }
    if (command == "left")
    {
       
            PlayerCols--;
        

        //PlayerCols--;
    }
    if (command == "right")
    {
        // int Currentpos = ++PlayerCols;

        PlayerCols++;

    }

    if (isVAlidMove(PlayGround, PlayerRows, PlayerCols))
    {

        if (PlayGround[PlayerRows, PlayerCols] == "-")//Kletkata poziciqta
        {
            Moves++;
        }

        if (PlayGround[PlayerRows, PlayerCols] == "P")//Kletkata poziciqta
        {

          
           // PlayGround[PlayerRowPrevios, PlayerColsPrevios] = "-";
            Moves++;
            TouchesOp++;
        }
        if (PlayGround[PlayerRows, PlayerCols] == "O")
        {
            PlayerRows = PlayerRowPrevios;
            PlayerCols= PlayerColsPrevios;
        }
        if (TouchesOp == 3)
        {
            break;
        }
    }
    PlayGround[PlayerRowPrevios, PlayerColsPrevios] = "-";
    PlayGround[PlayerRows, PlayerCols] = "B";

}

bool isVAlidMove(string[,] matrix, int playerrow, int playercol)
{
    if ((playerrow >=0 && playerrow<matrix.GetLength(0)) && (playercol >= 0 && playercol < matrix.GetLength(1)))
    {
        return true;
    }
   
        return false;
    
}



Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {TouchesOp} Moves made: {Moves}");
//Console.WriteLine();



//for (int row = 0; row < PlayGround.GetLength(0); row++)
//{

//    for (int col = 0; col < PlayGround.GetLength(1); col++)
//    {

//        Console.Write(PlayGround[row, col]+" ");
       
//    }
//    Console.WriteLine();

//}
