using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class manager_InfoPetroglifp : MonoBehaviour {

    public epocaInfo[] infoPiedra;
    public GameObject[] canvaInfo;
    public Image imgInfo;

    public Text tituInfo;
    public Text paso;
    int i = 0;

	// Use this for initialization
	void Start () {
        canvaInfo[i].SetActive(true);
        imgInfo.sprite = infoPiedra[i].petroImg;
        tituInfo.text = infoPiedra[i].EPOCA;
        paso.text = infoPiedra[i].instrucccion;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void der() {

        i++;
        if (i > infoPiedra.Length - 1)
        {
            i = 0;
        }
        int canva = 0;
        foreach (GameObject mostrar in canvaInfo) {
            if (canva == i)
            {
                mostrar.SetActive(true);
            }
            else {
                mostrar.SetActive(false);

            }
            canva++;
        }





        imgInfo.sprite = infoPiedra[i].petroImg;
        tituInfo.text = infoPiedra[i].EPOCA;
        paso.text = infoPiedra[i].instrucccion;


    }

    public void izq()
    {

        i--;
        if (i < 0)
        {
            i = infoPiedra.Length - 1;
        }
        int canva = 0;
        foreach (GameObject mostrar in canvaInfo)
        {
            if (canva == i)
            {
                mostrar.SetActive(true);
            }
            else
            {
                mostrar.SetActive(false);

            }
            canva++;
        }



        imgInfo.sprite = infoPiedra[i].petroImg;
        tituInfo.text = infoPiedra[i].EPOCA;
        paso.text = infoPiedra[i].instrucccion;


    }
}
