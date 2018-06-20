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
    public GameObject newsBackground;
    public GameObject newsImage;
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
        headlineWithGap[0] = "Obama says: \nTrump’s behaviour is _____";
        replaceOptions1[0] = "Childish";
        replaceOptions2[0] = "Immature";
        replaceOptions3[0] = "Stupid";
        headlineWithGap[1] = "Trump plans own army for _____";
        replaceOptions1[1] = "space"; // richtig
        replaceOptions2[1] = "border guards";
        replaceOptions3[1] = "white house";
        headlineWithGap[2] = "US: withdrawal from _____";
        replaceOptions1[2] = "Iraq";
        replaceOptions2[2] = "UNO"; // richtig
        replaceOptions3[2] = "mexican wall";
        headlineWithGap[3] = "Illegal crossing on external EU border \nthrough  _____";
        replaceOptions1[3] = "Trump";
        replaceOptions2[3] = "Icebear";
        replaceOptions3[3] = "Cow"; // richtig
        headlineWithGap[4] = "2017 there were _____ refugees \nin Germany!";
        replaceOptions1[4] = "34.880 syrian";
        replaceOptions2[4] = "60.000 syrian";
        replaceOptions3[4] = "60.000 terrorist";
        headlineWithGap[5] = "Investigations proved: _____the Brexit vote!";
        replaceOptions1[5] = "Twitter bots affected \n";
        replaceOptions2[5] = "Twitter bots didn’t \naffect ";
        replaceOptions3[5] = "Twitter bots didn’t \nexist until after ";
        headlineWithGap[6] = "North Korean leader and Trump \ndiscussed _____";
        replaceOptions1[6] = "nuclear disarmament";
        replaceOptions2[6] = "nuclear wars";
        replaceOptions3[6] = "nuclear wars in the future";
        headlineWithGap[7] = "School shooter killed: \n_____";
        replaceOptions1[7] = "17 people";
        replaceOptions2[7] = "17 children";
        replaceOptions3[7] = "17 children like in video game shooter";


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
                //gameOverSchlechtMethod();
        }
        if(geld <= 0)
        {
            geld = 0;
                //gameOverGutMethod();
        }
        }

    }


    void createNewHeadlineButtonClicked()
    {
        Debug.Log("createNewHeadlineButtonClicked()");
        Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        //Luecke.GetComponent<Text>().text = "_____";
        replaceNumber = 0;
        //createNewHeadlineButton.SetActive(false);
        //submitNewHeadlineButton.SetActive(true);
        //replaceButton1.SetActive(true);
        //replaceButton2.SetActive(true);
        //replaceButton3.SetActive(true);
        //feedBackText.SetActive(false);
        createArticleContent.SetActive(true);
        newsBackground.SetActive(true);
        newsImage.SetActive(true);
        dashboardContent.SetActive(false);

        if (counter < 7)
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
            newsBackground.SetActive(false);
            newsImage.SetActive(false);
            dashboardContent.SetActive(true);
        }
    }
    void replaceButton1Clicked()
    {
        Debug.Log("replaceButton1Clicked()");
        replaceNumber = 1;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        string newText = text.Replace("_____", replaceOptions1[counter]);
        Lueckentext.GetComponent<Text>().text = newText;
    }
    void replaceButton2Clicked()
    {
        Debug.Log("replaceButton2Clicked()");
        replaceNumber = 2;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        string newText = text.Replace("_____", replaceOptions2[counter]);
        Lueckentext.GetComponent<Text>().text = newText;
    }
    void replaceButton3Clicked()
    {
        Debug.Log("replaceButton3Clicked()");
        replaceNumber = 3;
        string text = Lueckentext.GetComponent<Text>().text = headlineWithGap[counter];
        string newText = text.Replace("_____", replaceOptions3[counter]);
        Lueckentext.GetComponent<Text>().text = newText;
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
