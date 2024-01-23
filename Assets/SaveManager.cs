using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            CreateSave();
        else if (Input.GetButtonDown("Fire1"))
            LoadSave();
    }

    private void CreateSave()
    {
        // S�rialiser la sauvegarde
        SaveStructure save = new SaveStructure();
        save.pv = playerController.NombreDePv;
        save.magie = playerController.NombreDeMagie;

        string json = JsonUtility.ToJson(save);
        Debug.Log(json);
        // Ecrire la sauvegarde sur le disque
        string savePath = Application.persistentDataPath + "/save.txt";
        Debug.Log(savePath);
        File.WriteAllText(savePath, json);
    }

    private void LoadSave()
    {
        // Lire la sauvegarde sur le disque
        string savePath = Application.persistentDataPath + "/save.txt";
        string saveData = File.ReadAllText(savePath);
        Debug.Log(saveData);
        // D�s�rialiser la sauvegarde
        SaveStructure saveStructure
            = JsonUtility.FromJson<SaveStructure>(saveData);
        Debug.Log(saveStructure.pv);
        Debug.Log(saveStructure.magie);
        // Interpr�tation/Application de la sauvegarde
        playerController.NombreDePv = saveStructure.pv;
        playerController.NombreDeMagie = saveStructure.magie;
    }
}
