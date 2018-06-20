using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public int apocalypseMeter;
    public int geld;
    public GameObject createNewHeadlineButton;
    public GameObject submitNewHeadlineButton;
    public GameObject replaceButton1;
    public GameObject replaceButton2;
    public GameObject replaceButton3;
    public GameObject feedBackText;
    public GameObject gameOverGut;
    public GameObject gameOverSchlecht;
    public GameObject Lueckentext;
    public GameObject Luecke;
    private string feedBackTextText;
    private string[] headlineWithGap = new string[10]; //initialize this
    private string[] replaceOptions1 = new string[10]; //initialize this
    private string[] replaceOptions2 = new string[10]; //initialize this
    private string[] replaceOptions3 = new string[10]; //initialize this
    public int counter;
    private int replaceNumber;
    public bool gameOver;

    public Image apoMeterImage;
    public Text moneyText;
    public GameObject createArticleContent;
    public GameObject dashboardContent;

    // Use this for initialization
    void Start () {
        
        apocalypseMeter = 0;
        geld = 1000;
        counter = 0;
        replaceNumber = 0;
        gameOver = false;
        headlineWithGap[0] = "Obama says: \nTrump’s behaviour is";
        replaceOptions1[0] = "Childish";
        replaceOptions2[0] = "Immature";
        replaceOptions3[0] = "Stupid";
        headlineWithGap[1] = "Trump plans own army for";
        replaceOptions1[1] = "space";
        replaceOptions2[1] = "border guards";
        replaceOptions3[1] = "white house";
        headlineWithGap[2] = "US: withdrawal from";
        replaceOptions1[2] = "Iraq";
        replaceOptions2[2] = "UNO";
        replaceOptions3[2] = "mexican wall";

        Button btn1 = createNewHeadlineButton.GetComponent<Button>();
        Button btn2 = submitNewHeadlineButton.GetComponent<Button>();
        Button btn3 = replaceButton1.GetComponent<Button>();
        Button btn4 = replaceButton2.GetComponent<Button>();
        Button btn5 = replaceButton3.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn1.onClick.AddListener(createNewHeadlineButtonClicked);
        btn2.onClick.AddListener(submitNewHeadlineButtonClicked);
        btn3.onClick.AddListener(replaceButton1Clicked);
        btn4.onClick.AddListener(replaceButton2Clicked);
        btn5.onClick.AddListener(replaceButton3Clicked);
        createNewHeadlineButtonClicked();
        

    }
	
	// Update is called once per frame
	void Update () {

        apoMeterImage.fillAmount = (float)apocalypseMeter / 100;
        moneyText.text = geld.ToString();

        if (!gameOver) {
        if(apocalypseMeter > 100)
        {
                gameOverSchlechtMethod();
        }
        if(geld <= 0)
        {
            geld = 0;
                gameOverGutMethod();
        }
        }

    }


    void createNewHeadlineButtonClicked()
    {
        Debug.Log("createNewHeadlineButtonClicked()");
        Lueckentext.GetComponent<Text>().text = headlineWithGap[counter] + " _____";
        //Luecke.GetComponent<Text>().text = "_____";
        replaceNumber = 0;
        //createNewHeadlineButton.SetActive(false);
        //submitNewHeadlineButton.SetActive(true);
        //replaceButton1.SetActive(true);
        //replaceButton2.SetActive(true);
        //replaceButton3.SetActive(true);
        //feedBackText.SetActive(false);
        createArticleContent.SetActive(true);
        dashboardContent.SetActive(false);

        if (counter < 2)
        {
            replaceButton1.GetComponentInChildren<Text>().text = replaceOptions1[counter];
            replaceButton2.GetComponentInChildren<Text>().text = replaceOptions2[counter];
            replaceButton3.GetComponentInChildren<Text>().text = replaceOptions3[counter];
        }

    }

    void submitNewHeadlineButtonClicked()
    {
        Debug.Log("submitNewHeadlineButtonClicked()");
        if (replaceNumber != 0)
        {
            if(replaceNumber == 1)
            {
                geld += Random.Range(50, 100);
                

            } else if (replaceNumber == 2)
            {
                geld += Random.Range(100, 200);
                apocalypseMeter += Random.Range(5, 15);
            } else if (replaceNumber == 3)
            {
                geld += Random.Range(500, 1000);
                apocalypseMeter += Random.Range(25, 30);
            }
            setFeedbackText();
            counter++;
            geld -= 500; //MIETE
            //createNewHeadlineButton.SetActive(true);
            //submitNewHeadlineButton.SetActive(false);
            //feedBackText.SetActive(true);
            //replaceButton1.SetActive(false);
            //replaceButton2.SetActive(false);
            //replaceButton3.SetActive(false);
            createArticleContent.SetActive(false);
            dashboardContent.SetActive(true);
        }
    }
    void replaceButton1Clicked()
    {
        Debug.Log("replaceButton1Clicked()");
        replaceNumber = 1;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        Lueckentext.GetComponent<Text>().text = text + " " + replaceOptions1[counter];
    }
    void replaceButton2Clicked()
    {
        Debug.Log("replaceButton2Clicked()");
        replaceNumber = 2;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        Lueckentext.GetComponent<Text>().text = text + " " + replaceOptions2[counter];
    }
    void replaceButton3Clicked()
    {
        Debug.Log("replaceButton3Clicked()");
        replaceNumber = 3;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        Lueckentext.GetComponent<Text>().text = text + " " + replaceOptions3[counter];
    }
    void setFeedbackText()
    {
        Debug.Log("setFeedbackText()");
        if (replaceNumber == 1)
        {
            feedBackTextText = "gut";
        } else if (replaceNumber == 2)
        {
            feedBackTextText = "nicht gut";
        } else if (replaceNumber == 3)
        {
            feedBackTextText = "schlecht";
        }
    }
    void gameOverGutMethod()
    {
        Debug.Log("gameOverGutMethod()");
        //TODO: GAMEOVER GUT
        createNewHeadlineButton.SetActive(false);
        submitNewHeadlineButton.SetActive(false);
        replaceButton1.SetActive(false);
        replaceButton2.SetActive(false);
        replaceButton3.SetActive(false);
        feedBackText.SetActive(false);

        gameOverGut.SetActive(true);
    }
    void gameOverSchlechtMethod()
    {
        Debug.Log("gameOverSchlechtMethod()");
        createNewHeadlineButton.SetActive(false);
        submitNewHeadlineButton.SetActive(false);
        replaceButton1.SetActive(false);
        replaceButton2.SetActive(false);
        replaceButton3.SetActive(false);
        feedBackText.SetActive(false);
        //TODO: GAMEOVER SCHLECHT
        gameOverSchlecht.SetActive(true);
    }
}
