using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetNameManadger : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static SetNameManadger _instanse;
    private DataSaveJSON _dataSaveJSON;
    [SerializeField] private Text HighText;
    [SerializeField] private InputField _inputField;

    public string NamePlayer { get; private set; }

    private void Awake() => _instanse = this;
    public void Start()
    {
        
        if(!SaveSystem.CheckIsFile())
        {  
            Debug.Log("File yes");
            _dataSaveJSON = SaveSystem.Load<DataSaveJSON>();
            HighText.text = string.Format("Best Score: {0} : {1}", _dataSaveJSON.NamePlayer,_dataSaveJSON.HighRecord);
        } 
         Debug.Log("File" + _dataSaveJSON.NamePlayer);
    }

    public void SaveNamePlayer()
    {
        NamePlayer = _inputField.text;
    }

}
