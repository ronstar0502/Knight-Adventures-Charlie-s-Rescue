using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTesting : MonoBehaviour
{
    [SerializeField] private string stringToReverse;
    private int[] numberArray;
    private string[] stringArray;
    void Start()
    {
        numberArray = new int[] {11, 22, 33, 44, 55, 66, 77, 88 };
        stringArray = new string[] { "Hello", "World", "Class", "New", "Array", "List" };

        string revresedString = ReverseString(stringToReverse);
        print(revresedString);

        PrintEvenNumbers(numberArray);
        PrintStringArray(stringArray);

    }

    private string ReverseString(string word)
    {
        string result = "";
        for (int i=word.Length-1;i>=0;i--)
        {
            result += word[i];
        }
        result = char.ToUpper(result[0]) + result.Substring(1, result.Length - 2) + char.ToLower(result[result.Length - 1]);
        return result;
    }

    private void PrintEvenNumbers(int[] numbers)
    {
        string evenNumbers = "";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                evenNumbers += numbers[i]+" , ";
            }
        }
        print("even numbers: "+evenNumbers);
    }

    private void PrintStringArray(string[] words)
    {
        string result = "";
        foreach (string word in words)
        {
            result += word+" , ";
        }
        print("words: "+result);
    }
}
