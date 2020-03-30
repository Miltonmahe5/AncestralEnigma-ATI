using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cargaAsincronica : MonoBehaviour
{
   // public Text m_Text;
    public Button m_Button;
    public string nombreEscena;
    public GameObject cargaPanel;

    void Start()
    {
        //Call the LoadButton() function when the user clicks this Button
        m_Button.onClick.AddListener(LoadButton);
        

    }

    void LoadButton()
    {
        //Start loading the Scene asynchronously and output the progress bar
        cargaPanel.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nombreEscena);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                cargaPanel.SetActive(false);
                asyncOperation.allowSceneActivation = true;
                //asyncOperation.allowSceneActivation = true;
                //Change the Text to show the Scene is ready
               // m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                //    //Activate the Scene
                //    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}