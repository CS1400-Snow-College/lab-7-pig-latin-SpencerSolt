//Spencer Solt, 10/14/25, Lab 7 - Pig Latin/ Encoder
Console.WriteLine("Hello, this program will collect a string and translate it into pig latin by taking words starting with a consonant, or a consonant cluster, move the cluster to the end and add 'AY'. Otherwise , If the word begins with a vowel and ends with a vowel just add 'way' to the end. Then encrypte it by generating a random number and shifting the characters by that amount.");
Console.Write("Please enter a phrase: ");
string? phrase = Console.ReadLine();
string[] arrayPhrase = phrase.Split(); //Takes the user input
string[] translatedPhrase = new string[arrayPhrase.Count()]; //Changed the user input into an array
//Move the first Consonant or consonant clusters to the end and add -ay
for (int i = 0; i < arrayPhrase.Count(); i++)
{
    //If there is a vowel at the start add -way
    if (arrayPhrase[i].ToLower().IndexOf("a") == 0 || arrayPhrase[i].ToLower().IndexOf("e") == 0 || arrayPhrase[i].ToLower().IndexOf("i") == 0 || arrayPhrase[i].ToLower().IndexOf("o") == 0 || arrayPhrase[i].ToLower().IndexOf("u") == 0)
        translatedPhrase[i] = arrayPhrase[i].Substring(0, arrayPhrase[i].Length) + "way";
    //Move the first Consonant (not vowels) or consonant clusters (not vowel groups) to the end and add -ay
    else
    {
        for (int x = 1; x < arrayPhrase[i].Length; x++) //Gets the length of the consonant or consonant cluster
            if (arrayPhrase[i].ToLower().IndexOf("a") == x || arrayPhrase[i].ToLower().IndexOf("e") == x || arrayPhrase[i].ToLower().IndexOf("i") == x || arrayPhrase[i].ToLower().IndexOf("o") == x || arrayPhrase[i].ToLower().IndexOf("u") == x || arrayPhrase[i].ToLower().IndexOf("y") == x)
                translatedPhrase[i] = arrayPhrase[i].ToLower().Substring(x, arrayPhrase[i].Length - x) + arrayPhrase[i].ToLower().Substring(0, x) + "ay";
    }
}
//Combines the translated pig latin into a single sentence and prints it
string pigLatin = string.Join(" ", translatedPhrase);
Console.WriteLine($"In pig latin that's: {pigLatin}");