using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public List<Transform> arrowsLocations;
    public List<GameObject> arrowsList;


    public GameObject arrow;

    public Text arrowNumberText;
    int arrowNumber = 0;
    void Start()
    {
        arrowsList.Add(arrow);
        arrowNumber++;
    }

    
    void Update()
    {
        arrowNumberText.text = "" + arrowNumber;
        Debug.Log(arrowNumber);


        for (var i = arrowsList.Count - 1; i > -1; i--)
        {
            if (arrowsList[i] == null)
                arrowsList.RemoveAt(i);
        }
    }

     void OnTriggerEnter(Collider other)
    {

      

        if (other.gameObject.tag == "+10")
        {
            for (int i = 0; i < 10; i++)
            {
                var newArrow = Instantiate(arrow, arrowsLocations[arrowNumber].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                newArrow.transform.parent = transform;
                arrowsList.Add(newArrow);
                arrowNumber++;
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "x2")
        {

            var lastArrowNumber = arrowNumber;
            for (int i = 0; i < lastArrowNumber; i++)
            {
                var newArrow = Instantiate(arrow, arrowsLocations[arrowNumber].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                newArrow.transform.parent = transform;
                arrowsList.Add(newArrow);
                arrowNumber++;
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "-10")
        {
          
            if (arrowsList.Count<=10)
            {
               
                if (arrowsList.Count == 1)
                {
                    arrowNumber = 1;
                }
                else
                {
                    for (int i = arrowsList.Count - 1; i > 0; i--)
                    {
                        Destroy(arrowsList[i].gameObject);
                      
                    }
                }
                arrowNumber = 1;
            }
            if (arrowsList.Count > 10)
            {
                

                for (int i = arrowsList.Count - 1; i >= arrowsList.Count - 10; i--)
                {
                    Destroy(arrowsList[i].gameObject);

                }
                arrowNumber = arrowNumber - 10;
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "÷2")
        {



            if (arrowsList.Count == 1)
            {
                arrowNumber = 1;
            }
            else
            {
                for (int i = arrowsList.Count - 1; i >= arrowsList.Count / 2; i--)
                {
                    Destroy(arrowsList[i].gameObject);

                }
                arrowNumber = arrowNumber / 2;
            }  

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {

            
            arrowsList[arrowNumber - 1].transform.parent = other.gameObject.transform.GetChild(2).transform;
            arrowsList.Remove(arrowsList[arrowNumber - 1]);
            arrowNumber--;
            
        }

       

       
    }
}
