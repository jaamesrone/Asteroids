using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update


    public int score;
    public int lives;

    public void SaveToFile(string filePath)
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    public static SaveAndLoad LoadFromFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<SaveAndLoad>(json);
    }

}
