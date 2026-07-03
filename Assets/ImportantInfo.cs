using System;
using UnityEngine;

public static class ImportantInfo
{
    public static int level = 0;
    //Each index refers to a level
    public static int[] levelsRequestMax = { 2, 3, 3, 3, 4, 4, 4, 4, 5, 5 };
    public static int[] levelsRequestMin = { 1, 1, 2, 2, 2, 3, 3, 3, 3, 4 };

    public static int[] levelsNumIngredients = { 2, 2, 4, 4, 5, 6, 7, 9, 9, 9 };
    public static float[] customerSpawnRate = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
    public static int[] numCustomers = { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 };
}
