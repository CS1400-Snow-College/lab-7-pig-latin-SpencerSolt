//Spencer Solt, 10/14/25, Lab 7 - Pig Latin/ Encoder
Console.WriteLine("Hello, this program will collect a string and translate it into pig latin by taking words starting with a consonant, or a consonant cluster, move the cluster to the end and add 'AY'. Otherwise , If the word begins with a vowel and ends with a vowel just add 'way' to the end. Then encrypte it by generating a random number and shifting the characters by that amount.");
Console.Write("Please enter a phrase: "); //Takes the user input
string? phrase = Console.ReadLine(); //'Fried chicken is going to taste amazing' is a good test phrase
string[] arrayPhrase = phrase.Split(); 
string[] translatedPhrase = new string[arrayPhrase.Count()]; //Changed the user input into an array
//Move the first Consonant or consonant clusters to the end and add -ay
for (int i = 0; i < arrayPhrase.Count(); i++)
{
    //If there is a vowel at the start add -way
    if (arrayPhrase[i].ToLower().IndexOf("a") == 0 || arrayPhrase[i].ToLower().IndexOf("e") == 0 || arrayPhrase[i].ToLower().IndexOf("i") == 0 || arrayPhrase[i].ToLower().IndexOf("o") == 0 || arrayPhrase[i].ToLower().IndexOf("u") == 0)
        translatedPhrase[i] = arrayPhrase[i].Substring(0, arrayPhrase[i].Length) + "way";
    //Move the first Consonant or consonant cluster to the end and add -ay
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
//Generates a random number to be used for the offset
Random rand = new Random(); int randomOffset = rand.Next(1, 26);
string[] offsetPhrase = new string[translatedPhrase.Count()];
//Offsets the letters of the pig latin
for (int i = 0; i < translatedPhrase.Count(); i++)
{
    string offsetWord = "";
    char offsetLetter = (char)97;
    for (int x = 0; x < translatedPhrase[i].Length; x++)
    {
        offsetLetter = translatedPhrase[i].ElementAt(x);
        //Ensures that the letters will loop back to a once it hits z and change
        for (int z = 0; z < randomOffset; z++)
        {
            if ((int)offsetLetter == 122) //Turns z into a
                offsetLetter = (char)97;
            else //Turns a letter into the next one
                offsetLetter = (char)(offsetLetter.GetHashCode() + 1);
        }
        offsetWord = offsetWord + offsetLetter; //Combines the letters back into a word
    }
    offsetPhrase[i] = offsetWord; //Adds the offset word into an array
}
//Joins all of the values in the array into a single string
string encryptedPhrase = string.Join(" ", offsetPhrase);
Console.WriteLine($"We can encrypt it as: {encryptedPhrase}");