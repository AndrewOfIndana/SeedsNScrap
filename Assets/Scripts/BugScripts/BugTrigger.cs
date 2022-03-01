using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTrigger : MonoBehaviour
{
    void HitBug(float attackToDamage)
    {
        this.gameObject.SendMessageUpwards("DoDamage", attackToDamage);
    }
}
