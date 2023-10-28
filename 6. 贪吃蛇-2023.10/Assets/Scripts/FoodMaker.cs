using UnityEngine;
using UnityEngine.UI;

public class FoodMaker : MonoBehaviour
{
    //单例，选中此行，Ctrl+r+e
    private static FoodMaker _instance;

    public int xlimit = 21;
    public int ylimit = 11;
    public int xoffset = 8;
    public GameObject foodPrefab;
    public GameObject rewardPrefab;
    public Sprite[] foodSprites;
    private Transform foodHolder;

    public static FoodMaker Instance { get => _instance; set => _instance = value; }

    // 脚本初始化的时候，将 Instance 赋值为 this
    void Awake()  
    {
        Instance = this;
    }

    void Start()
    {
        foodHolder = GameObject.Find("FoodHolder").transform;
        MakeFood(false);
    }

    public void MakeFood(bool isReward)
    {
        int index = Random.Range(0, foodSprites.Length);
        GameObject food = Instantiate(foodPrefab);
        food.GetComponent<Image>().sprite = foodSprites[index];
        food.transform.SetParent(foodHolder, false);
        int x = Random.Range(-xlimit + xoffset, xlimit);
        int y = Random.Range(-ylimit, ylimit);
        food.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        if (isReward)
        {
            GameObject reward = Instantiate(rewardPrefab);
            reward.transform.SetParent(foodHolder, false);
            x = Random.Range(-xlimit + xoffset, xlimit);
            y = Random.Range(-ylimit, ylimit);
            reward.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        }
    }
}
