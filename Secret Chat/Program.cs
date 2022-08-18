using System;

namespace Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputMassage = Console.ReadLine();
            string command = Console.ReadLine();

            while (command!= "Reveal")
            {
                string[] tokans = command.Split(":|:");
                string action = tokans[0];

                switch (action)
                {
                    case "InsertSpace":
                        int index = int.Parse(tokans[1]);
                        inputMassage = inputMassage.Insert(index, " ");
                        Console.WriteLine(inputMassage);
                        break;
                    case "Reverse":
                        string substringReverse = tokans[1];
                        int indexReverse = inputMassage.IndexOf(substringReverse);

                        if (indexReverse != -1)
                        {
                            inputMassage = inputMassage.Remove(indexReverse, substringReverse.Length);

                            for (int i = substringReverse.Length - 2; i >= 0; i--)
                            {
                                substringReverse += substringReverse[i];
                                substringReverse = substringReverse.Remove(i, 1);
                            }
                            inputMassage += substringReverse;
                            Console.WriteLine(inputMassage); ;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string substring = tokans[1];
                        string replacement = tokans[2];
                        int indexSubstring = inputMassage.IndexOf(substring);

                        if (indexSubstring != -1)
                        {
                            inputMassage = inputMassage.Replace(substring, replacement);
                        }
                        Console.WriteLine(inputMassage);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {inputMassage}");
        }
    }
}
