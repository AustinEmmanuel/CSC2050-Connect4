using UnityEngine;

public class Checker 
{
    public string color; // The color of the checker
    public bool isEmpty; // Indicates if the checker is empty or not

    public Checker(string color)
    {
        this.color = color;
        this.isEmpty = false;
    }

    public Checker()
    {
        this.color = "N/A";
        this.isEmpty = true;
    }
}

