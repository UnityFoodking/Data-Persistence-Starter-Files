using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save <TClass>(TClass _data) where TClass: new()
    {
       BinaryFormatter formatter = new BinaryFormatter();
       FileStream _stream = new FileStream(GetPath(),FileMode.OpenOrCreate, 
      FileAccess.ReadWrite, FileShare.None);
       formatter.Serialize(_stream,_data);
       _stream.Close();
    }

    public static TClass Load <TClass>() where TClass: new()
    {
        if(CheckIsFile())
        {
            TClass Emptydata = new TClass();
            Save(Emptydata);
            return Emptydata;
        }

        BinaryFormatter formatter = new BinaryFormatter();
       FileStream _stream = new FileStream(GetPath(),FileMode.Open,FileAccess.ReadWrite);
       TClass _data = (TClass)formatter.Deserialize(_stream);
       _stream.Close();
        return _data;
    }


    private static string GetPath()
    {
       Debug.Log(Application.persistentDataPath + @"/data.gnd");
       return Application.persistentDataPath + @"/data.gnd";
    }
   
   public static bool CheckIsFile()
   {
       return !File.Exists(GetPath());
   }   
}
