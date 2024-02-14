
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class NameRandomizer : MonoBehaviour
{
    public TMP_InputField inputFiealdText;
    public TextAsset nameFile;
    public string[] names;
    void Start()
    {
        names = nameFile.text.Split("\n");
    }

    public void GenerateName()
    {
        int rnd = Random.Range(0, names.Length);
        inputFiealdText.text = names[rnd];
    }
}
