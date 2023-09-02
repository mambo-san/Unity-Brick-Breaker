using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    [SerializeField] private TMP_InputField tmpInputField;


    public string PlayerName;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
        tmpInputField.onEndEdit.AddListener(TextMeshUpdated);
        PlayerName = "Anonymous";
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextMeshUpdated(string playerName)
    {

        if (PlayerName != null || PlayerName.Length != 0) 
        {
            PlayerName = playerName;
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    
}
