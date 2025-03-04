using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAnimals : MonoBehaviour
{
    public List<GameObject> dogs = new List<GameObject>();
    public List<GameObject> cats = new List<GameObject>();
    public List<GameObject> chickens = new List<GameObject>();
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Dog(Clone)":
                dogs.Add(other.gameObject);
                TurnOffAura(dogs);
                PlusMoneyPickUpAnimal(); // this function to plus more money when player pickup animal
                break;
            case "Kitty(Clone)":
                cats.Add(other.gameObject);
                TurnOffAura(cats);
                PlusMoneyPickUpAnimal();
                break;
            case "Chicken(Clone)":
                chickens.Add(other.gameObject);
                TurnOffAura(chickens);
                PlusMoneyPickUpAnimal();
                break;
        }
    }

    private void Update()
    {
        UpdateAnimalPositions(dogs, new Vector3(-2f, 0, -5f));
        UpdateAnimalPositions(cats, new Vector3(2f, 0, -5f));
        UpdateAnimalPositions(chickens, new Vector3(0, 20f, 0));     
    }

    private void UpdateAnimalPositions(List<GameObject> animals, Vector3 offset)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            Vector3 positionOffset = offset * (i + 1);
            if (animals == chickens)
            {
                positionOffset.y = 17 + i * 3;
            }
            animals[i].transform.position = Manager_Input.Instance.transformPlayer.position + positionOffset;
        }
    }

    private void TurnOffAura(List<GameObject> animals)
    {
        foreach (GameObject animalObject in animals)
        {
            AnimalTurnOffAura animal = animalObject.GetComponent<AnimalTurnOffAura>();
            if (animal != null)
            {
                animal.PickUp();
            }
        }
    }

    private void PlusMoneyPickUpAnimal()
    {
        PlayerPrefs.SetFloat("Current Money", PlayerPrefs.GetFloat("Current Money") + 10);
        SystemPlusMoney.Instance.g_currnetMoney += 10;
    }
}
