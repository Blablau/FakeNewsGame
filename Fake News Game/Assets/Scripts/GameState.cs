using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameState : MonoBehaviour {

    public int apocalypseMeter;
    public int geld;
    public GameObject createNewHeadlineButton;
    public GameObject submitNewHeadlineButton;
    public GameObject replaceButton1;
    public GameObject replaceButton2;
    public GameObject replaceButton3;
    public GameObject pictureButton;
    public GameObject feedBackText;
    public GameObject gameOverGut;
    public GameObject gameOverSchlecht;
    public GameObject Lueckentext;
    public GameObject Luecke;
    public GameObject newsBackground;
    public GameObject goodImage;
    public GameObject badImage;
    public GameObject worstImage;
    public GameObject newsImage;
    public GameObject dollarsymbol;
    public GameObject mask_Bar;
    private string feedBackTextText;
    private string[] headlineWithGap = new string[10]; //initialize this
    private string[] replaceOptions1 = new string[10]; //initialize this
    private string[] replaceOptions2 = new string[10]; //initialize this
    private string[] replaceOptions3 = new string[10]; //initialize this
    private string[] imageOptions = new string[] { "trump.jpg", "fakeNews.jpg", "obama.jpg", "trump2.jpg", "whiteHouse.jpg", 
                    "nuclear.jpg", "nuclear2.jpg", "nuclear3.jpg", "boat.jpg", "cow.jpg", "refugee.jpg" };
    private string image_GameOverSchlecht = "weltuntergang.jpg";
    private string image_GameOverGut = "closed.jpg";
    private string image_newsGood = "news_good.png";
    private string image_newsBad = "news_bad.png";
    private string image_newsVeryBad = "news_verybad.png";
    private string image_news = "newspaper.png";
    private Vector2 size = new Vector2(100, 100); // image size
    public int counter;
    private int replaceNumber;
    private int pictureCounter;
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
        pictureCounter = 1;
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
        Button btn6 = pictureButton.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn1.onClick.AddListener(createNewHeadlineButtonClicked);
        btn2.onClick.AddListener(submitNewHeadlineButtonClicked);
        btn3.onClick.AddListener(replaceButton1Clicked);
        btn4.onClick.AddListener(replaceButton2Clicked);
        btn5.onClick.AddListener(replaceButton3Clicked);
        btn6.onClick.AddListener(pictureButtonClicked);
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
                gameOver = true;
        }
        if(geld <= 0)
        {
            geld = 0;
            gameOverGutMethod();
            gameOver = true;
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
        goodImage.SetActive(false);
        badImage.SetActive(false);
        worstImage.SetActive(false);

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
            //newsBackground.SetActive(false);
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
    void pictureButtonClicked()
    {
        Debug.Log("pictureButtonClicked()");
        string path = "./Assets/Resources/Images/" + imageOptions[pictureCounter];
        Texture2D texture = loadImage(size, Path.GetFullPath(path));
        newsImage.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        pictureCounter++;
        if(pictureCounter == imageOptions.Length)
        {
            pictureCounter = 0;
        }
    }
    void setFeedbackText()
    {

        string path = "./Assets/Resources/Sprites/";
        newsBackground.SetActive(false);


        Debug.Log("setFeedbackText()");
        if (replaceNumber == 1)
        {
            goodImage.SetActive(true);
        } else if (replaceNumber == 2)
        {
            badImage.SetActive(true);
        } else if (replaceNumber == 3)
        {
            worstImage.SetActive(true);
        }

        replaceNumber = 0;
    }
    void gameOverGutMethod()
    {
        Debug.Log("gameOverGutMethod()");
        createNewHeadlineButton.SetActive(false);
        submitNewHeadlineButton.SetActive(false);
        replaceButton1.SetActive(false);
        replaceButton2.SetActive(false);
        replaceButton3.SetActive(false);
        feedBackText.SetActive(true);
        pictureButton.SetActive(false);
        apoMeterImage.enabled = false;
        goodImage.SetActive(false);
        badImage.SetActive(false);
        worstImage.SetActive(false);
        moneyText.enabled = false;
        apocalypseMeter = 0;
        dollarsymbol.SetActive(false);
        mask_Bar.SetActive(false);

        createArticleContent.SetActive(true);
        newsBackground.SetActive(true);
        newsImage.SetActive(true);
        dashboardContent.SetActive(true);

        Lueckentext.GetComponent<Text>().text = "Agency closed after\ntoo much FakeNews competition";
        string path = "./Assets/Resources/Images/" + image_GameOverGut;
        Texture2D texture = loadImage(size, Path.GetFullPath(path));
        newsImage.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

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
        goodImage.SetActive(false);
        badImage.SetActive(false);
        worstImage.SetActive(false);
        feedBackText.SetActive(true);
        pictureButton.SetActive(false);
        apoMeterImage.enabled = false;
        moneyText.enabled = false;
        apocalypseMeter = 0;
        dollarsymbol.SetActive(false);
        mask_Bar.SetActive(false);

        createArticleContent.SetActive(true);
        newsBackground.SetActive(true);
        newsImage.SetActive(true);
        dashboardContent.SetActive(true);

        Lueckentext.GetComponent<Text>().text = "People too afraid of future; Revolts\nagainst government insitutions underway!";
        string path = "./Assets/Resources/Images/" + image_GameOverSchlecht;
        Texture2D texture = loadImage(size, Path.GetFullPath(path));
        newsImage.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
            Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

        gameOverSchlecht.SetActive(true);
    }

    private static Texture2D loadImage(Vector2 size, string filePath)
    {

        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
        texture.filterMode = FilterMode.Trilinear;
        texture.LoadImage(bytes);

        return texture;
    }
}
