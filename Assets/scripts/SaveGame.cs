using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{


    public static void SavedItems(QuizManager quizManager,QuizUI quizUI)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "//player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        saveData data = new saveData(quizManager,quizUI);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }
    public static saveData LoadData()
    {
        string path = Application.persistentDataPath + "//player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveData data = formatter.Deserialize(stream) as saveData;
            stream.Close();
            return data;
        }else
        {
            Debug.Log("error loading the file");
            return null;
        }
    }

}
