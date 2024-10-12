using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private GameManager gm;
    public GameObject slicedFruit;
    public GameObject fruitJuice;
    public float rotationForce = 200;
    private Rigidbody rb;
    public int scorePoints;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }
    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(fruitJuice, /*new Vector3(transform.position.x, transform.position.y, 0)*/transform.position, fruitJuice.transform.rotation);
        Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in slicedRb)
        {
            rb.AddExplosionForce(130f, transform.position, 10);
            rb.velocity = rb.velocity * 1.2f;
        }

        Destroy(instantiatedFruit, 5);
        Destroy(instantiatedJuice, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade") 
        { 
            gm.UpdateTheScore(scorePoints);
            Destroy(gameObject);
            InstantiateSlicedFruit();
        }
        if(other.tag == "BottomTrigger")
        {
            gm.UpdateLives();
        }
    }
}
