using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Slider predatorSlider;
    [SerializeField] private Text predatorText;

    [SerializeField] private Slider preySlider;
    [SerializeField] private Text preyText;

    [SerializeField] private Slider aSlider;
    [SerializeField] private Text aText;

    [SerializeField] private Slider bSlider;
    [SerializeField] private Text bText;

    [SerializeField] private Slider cSlider;
    [SerializeField] private Text cText;

    [SerializeField] private Slider dSlider;
    [SerializeField] private Text dText;

    [SerializeField] private Slider dtSlider;
    [SerializeField] private Text dtText;

    [SerializeField] private Slider timeSlider;
    [SerializeField] private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        GameController.l = 50;

        predatorSlider.onValueChanged.AddListener((v) =>
        {
            predatorText.text = "Initial Predator Population:\n" + v.ToString("0");
            GameController.l = v;
        });


        GameController.h = 200;

        preySlider.onValueChanged.AddListener((v) =>
        {
            preyText.text = "Initial Prey Population:\n" + v.ToString("0");
            GameController.h = v;
        });


        GameController.a = 0.05f;

        aSlider.onValueChanged.AddListener((v) =>
        {
            aText.text = "Constant a Value:\n" + v.ToString("0.000");
            GameController.a = v;
        });


        GameController.b = 0.001f;

        bSlider.onValueChanged.AddListener((v) =>
        {
            bText.text = "Constant b Value:\n" + v.ToString("0.0000");
            GameController.b = v;
        });


        GameController.c = 0.03f;

        cSlider.onValueChanged.AddListener((v) =>
        {
            cText.text = "Constant c Value:\n" + v.ToString("0.000");
            GameController.c = v;
        });


        GameController.d = 0.0002f;

        dSlider.onValueChanged.AddListener((v) =>
        {
            dText.text = "Constant d Value:\n" + v.ToString("0.00000");
            GameController.d = v;
        });


        GameController.dt = 1;

        dtSlider.onValueChanged.AddListener((v) =>
        {
            dtText.text = "Delta T Step Size:\n" + v.ToString("0.00");
            GameController.dt = v;
        });


        GameController.interval = 0.25f;

        timeSlider.onValueChanged.AddListener((v) =>
        {
            timeText.text = "Time Between Calculations:\n" + v.ToString("0.00");
            GameController.interval = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SimulationScene()
    {
        SceneManager.LoadScene("Simulation");
    }
}
