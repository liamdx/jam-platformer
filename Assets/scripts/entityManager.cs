using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityManager : MonoBehaviour
{

    private int entityType;

    private void Start()
    {
        entityType = 1;
        if (this.gameObject.tag == "Player")
        {
            setEntityType(0);
        }
    }

    public int getEntityType()
    {
        return entityType;
    }

    private void setEntityType(int newEntityType)
    {
        entityType = newEntityType;
    }

}
