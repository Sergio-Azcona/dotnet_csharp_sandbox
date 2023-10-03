// https://learn.microsoft.com/en-us/training/modules/write-first-c-sharp-method/3-exercise-create-your-first-method
// stopping place= https://learn.microsoft.com/en-us/training/modules/write-first-c-sharp-method/5-exercise-build-code-with-methods


  // void DisplayRandomNumbers()
  // {
  //     Random random = new Random();

  //     for (int i = 0; i < 5; i++)
  //     {
  //         Console.WriteLine($"Randos = {random.Next(1,20)}");
  //     }
  // }

  // DisplayRandomNumbers();

  // static int AddNums(int num1, int num2)
  // {
  //   int result = num1 + num2;
  //   return (result);
  // }

  // int sumNums = AddNums(6,14);
  // Console.Write(sumNums);


  // int[] arrayN = { 0,2,4,6,8 };
  // int numberLuck = 8;

  // static int FindNum(int[] arr, int num)
  // {
  //   for (int i = 0; i < arr.Length; i++)
  //     {
  //       if (arr[i] == num)
  //         {
  //           return num;
  //         }

  //     }
  //     return -1;
  // }

  // int result = FindNum(arrayN, numberLuck);
  // Console.WriteLine($"\nlucky number is {result}");


int[] times = {800, 1200, 1600, 2000};
int diff = 0;

Console.WriteLine("Enter current GMT");
int currentGMT = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Current Medicine Schedule:");
DisplayTimes();

Console.WriteLine("Enter new GMT");
int newGMT = Convert.ToInt32(Console.ReadLine());

if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
{
    Console.WriteLine("Invalid GMT");
}
else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0) 
{
    diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
    AdjustTimes();
} 
else 
{
    diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
    AdjustTimes();
}

Console.WriteLine("New Medicine Schedule:");
DisplayTimes();

void DisplayTimes()
{
    /* Format and display medicine times */
    foreach (int val in times)
    {
        string time = val.ToString();
        int len = time.Length;

        if (len >= 3)
        {
            time = time.Insert(len - 2, ":");
        }
        else if (len == 2)
        {
            time = time.Insert(0, "0:");
        }
        else
        {
            time = time.Insert(0, "0:0");
        }

        Console.Write($"{time} ");
    }
    Console.WriteLine();
}

void AdjustTimes() 
{
    /* Adjust the times by adding the difference, keeping the value within 24 hours */
    for (int i = 0; i < times.Length; i++) 
    {
        times[i] = ((times[i] + diff)) % 2400;
    }
}