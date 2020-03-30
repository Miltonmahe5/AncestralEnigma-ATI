using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class reveladorPistas : MonoBehaviour {

    public string sceneGF;
    public Color loadToColor = Color.white;

    public float tiemGlitch;
    public GameObject decoGlitch;
    public Camera arcam;

    public GameObject canvas;
    public GameObject canvasMapa;


    public GameObject[] tarjetas;

    public bool renacimiento;
    public bool romano;
    public bool gF;

    public GameObject[] modelGeo;
    public GameObject[] modelHelio;
    public GameObject[] modelGF;



    public infoTeoria[] teorias;
    public Text teoria;
    public Text actor;
    public Text contTeoria;



    public Image imgCienti;


    public float posYGeo;





    //public Text nombreE, tamañoE, clasifiE, tempE, distanE, datoE;
    //public Image imageE;





    // Use this for initialization
    void Start() {
        canvasMapa.transform.localScale = new Vector3(1f, 0, 1f);
        canvas.transform.localScale = new Vector3(1f, 0, 1f);
        desCon(modelGeo);
        desCon(modelHelio);
        

        teoria.text = teorias[0].Titulo;
        actor.text = teorias[0].Subtitulo;
        contTeoria.text = teorias[0].Texto;
        imgCienti.sprite = teorias[0].imgCienti;




    }

    // Update is called once per frame
    void Update() {




        if (cartaTrack(tarjetas[0]) && cartaTrack(tarjetas[2]) && cartaTrack(tarjetas[3]) && cartaTrack(tarjetas[4])) {

            renacimiento = true;
            teoria.text = teorias[1].Titulo;
            actor.text = teorias[1].Subtitulo;
            contTeoria.text = teorias[1].Texto;
            imgCienti.sprite = teorias[1].imgCienti;
            apareceCon(modelHelio);



            //modelHelio.transform.localPosition = new Vector3(posAverage.x,0,posAverage.z);




        }
        else {

            renacimiento = false;
            
            desCon(modelHelio);


        }


        if (cartaTrack(tarjetas[0]) && cartaTrack(tarjetas[1]) && cartaTrack(tarjetas[6]))
        {

            romano = true;
            teoria.text = teorias[0].Titulo;
            actor.text = teorias[0].Subtitulo;
            contTeoria.text = teorias[0].Texto;
            imgCienti.sprite = teorias[0].imgCienti;
            apareceCon(modelGeo);
            //Vector3 posAverage = (tarjetas[0].transform.localPosition + tarjetas[1].transform.localPosition + tarjetas[6].transform.localPosition) / 3;
            //// modelGeo.transform.localPosition = posAverage;
            ////modelGeo.transform.localPosition = new Vector3(posAverage.x,0,posAverage.z);



        }
        else
        {

            romano = false;
            desCon(modelGeo);
            aparece();
        }


        if (cartaTrack(tarjetas[0]) && cartaTrack(tarjetas[8]) && cartaTrack(tarjetas[6]) && cartaTrack(tarjetas[3]))
        {

            gF= true;
            apareceCon(modelGF);




        }
        else
        {

            gF = false;
            desCon(modelGF);

        }




        if (romano || renacimiento || gF)
        {
            desaparece();
        }
        else {
            aparece();
        }




    }


    public void MostrarInfo()
    {

        if (renacimiento && canvas.transform.localScale.y != 1 ||
            romano && canvas.transform.localScale.y != 1)
        {

            

            Debug.Log("horrible");
            canvas.SetActive(true);
            canvas.GetComponent<Animator>().Play("frameLine_Appear");
            canvasMapa.GetComponent<Animator>().Play("frameLine_Disappear");




        }
        else
        {

            canvas.GetComponent<Animator>().Play("frameLine_Disappear");

        }


        if (gF) {

            StartCoroutine(glitch());

                //gameObject.GetComponent<AudioSource> ().Play();
               



        }

    }

    public void MostrarMapa()
    {

        if (canvasMapa.transform.localScale.y != 1)
        {
            canvasMapa.SetActive(true);
            canvasMapa.GetComponent<Animator>().Play("frameLine_Appear");
            canvas.GetComponent<Animator>().Play("frameLine_Disappear");

        }
        else
        {

            canvasMapa.GetComponent<Animator>().Play("frameLine_Disappear");

        }
    }

    public bool cartaTrack(GameObject carta) {
        return carta.GetComponent<DefaultTrackableEventHandler>().activo;
    }


    public void desaparece() {
        foreach (GameObject tarjeta in tarjetas)
        {
            tarjeta.transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    public void aparece()
    {
        foreach (GameObject tarjeta in tarjetas)
        {
            tarjeta.transform.GetChild(0).gameObject.SetActive(true);

        }
    }

    public void apareceCon(GameObject[] objetos) {

        foreach (GameObject objeto in objetos)
        {
            objeto.SetActive(true);
        }
    }
    public void desCon(GameObject[] objetos)
    {

        foreach (GameObject objeto in objetos)
        {
            objeto.SetActive(false);
        }
    }

    IEnumerator glitch() {

        decoGlitch.SetActive(true);
        arcam.GetComponent<GlitchEffect>().enabled = true;
        yield return new WaitForSeconds(tiemGlitch);
        Initiate.Fade(sceneGF, loadToColor, 0.3f);
        decoGlitch.SetActive(false);
        arcam.GetComponent<GlitchEffect>().enabled = false;
    }



}

   