using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Write_text : MonoBehaviour
{
    private int inc = 0;
    public int start = 0;
    private TextMeshProUGUI text;
    public int font;
    public string textToW = "Missions du drone D.I.I.C. :\n    - Exploration\n    - Identification de départ de feu\n    - Lanceur d'allertes\n    - Travail en essaim\n    - Résiliance du système\n";
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        isRunning = true;
        int l = textToW.Length;
        if (l > inc-start && inc-start >= 0) {
            if (!textToW[inc-start].Equals(' ')) {
                text.text = textToW.Substring(0, inc-start)+"l";
            } else {
                text.text = textToW.Substring(0, inc-start);
            }
        } else if(l < inc-start){
            text.text = textToW;
        }
        inc = inc + 1;
        yield return new WaitForSeconds(0.005f);
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize = font;
        if (!isRunning) StartCoroutine(waiter());
    }
}

//Projet : D.I.I.C. (Drone d'Identification d'Incendie Coopérant)
//Missions du drone D.I.I.C. :\n    - Exploration\n    - Identification de départ de feu\n    - Lanceur d'allertes\n    - Travail en essaim\n    - Résiliance du système\n
//Pour remplir ces missions, le drone D.I.I.C. quadrille une zone et identifie les départs de feu. Il peut travailler en equipe pour augmenter la zone de couverture et avoir un plus haut critère de résilliance.