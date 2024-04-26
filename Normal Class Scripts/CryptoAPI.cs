using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using static UnityEditor.PlayerSettings;

public class CryptoAPI : MonoBehaviour
{
    public string outputString = "[System.Serializable]\n\n public class Crypto \n{ ";
    void Start()
    {
        makeOutput();
        displayOutput();
    }
    public void makeOutput()
    {
        string filePath = "Assets/Scripts/crypto_text.txt";
        if (File.Exists(filePath))
        {
            try
            {

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(":");

                        outputString += "public string " + parts[0].Trim().Substring(1, parts[0].Trim().Length - 2) + ";//" + parts[1].Trim().Substring(1, parts[1].Trim().Length - 2) + "\n";
                    }

                }
            }
            catch (Exception ex)
            {
                print("An error occurred while reading the file:");
                print(ex.Message);
            }
            outputString += "\npublic Crypto(";
            try
            {

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;


                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(":");
                        outputString += "string " + parts[0].Trim().Substring(1, parts[0].Trim().Length - 2) + ", ";

                    }
                }
            }

            catch (Exception ex)
            {
                print("An error occurred while reading the file:");
                print(ex.Message);
            }
            outputString += ")\n{\n";
            try
            {

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(":");

                        outputString += "this." + parts[0].Trim().Substring(1, parts[0].Trim().Length - 2) + " = " + parts[0].Trim().Substring(1, parts[0].Trim().Length - 2) + ";\n";
                    }
                    outputString += "}\n}";
                }
            }

            catch (Exception ex)
            {
                print("An error occurred while reading the file:");
                print(ex.Message);
            }
        }
        else
        {
            print("The file does not exist.");
        }
    }

    public void displayOutput()
    {
        print(outputString);
    }

}