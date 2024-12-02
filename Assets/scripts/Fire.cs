using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] giftList;
    public GameObject giftSpawnPosition;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            System.Random random = new System.Random();
            int maRandom = random.Next(0, giftList.Length);
            var newgift = Instantiate(giftList[maRandom], giftSpawnPosition.transform.position, Quaternion.identity);
            Rigidbody giftRB = newgift.AddComponent<Rigidbody>();
            giftRB.useGravity = true;
        }
    }
}