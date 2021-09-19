using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSerializeFields : MonoBehaviour
{
    public Rigidbody2D Rb => rb;
    public GameObject TopSet => topSet;
    public GameObject BottomSet => bottomSet;
    public GameObject SideSet => sideSet;
    public Animator TopSetAnimator => topSetAnimator;
    public Animator BottomSetAnimator => bottomSetAnimator;
    public Animator SideSetAnimator => sideSetAnimator;
    public List<Animator> SideWings => sideWings;
    public Animator BottomWings => bottomWings;
    public Animator TopWings => topWings;
    public GameObject BottomSmallFire => bottomSmallFire;
    public GameObject TopSmallFire => topSmallFire;
    public GameObject SideSmallFire => sideSmallFire;
    public GameObject BottomMediumFire => bottomMediumFire;
    public GameObject TopMediumFire => topMediumFire;
    public GameObject SideMediumFire => sideMediumFire;
    public GameObject BottomBigFire => bottomBigFire;
    public GameObject TopBigFire => topBigFire;
    public GameObject SideBigFire => sideBigFire;

    [SerializeField]
    private Rigidbody2D rb = null;
    [SerializeField]
    private GameObject topSet = null;
    [SerializeField]
    private GameObject bottomSet = null;
    [SerializeField]
    private GameObject sideSet = null;
    [SerializeField]
    private Animator topSetAnimator = null;
    [SerializeField]
    private Animator bottomSetAnimator = null;
    [SerializeField]
    private Animator sideSetAnimator = null;

    [SerializeField]
    private List<Animator> sideWings = null;
    [SerializeField]
    private Animator bottomWings = null;
    [SerializeField]
    private Animator topWings = null;

    [SerializeField]
    private GameObject bottomSmallFire = null;
    [SerializeField]
    private GameObject topSmallFire = null;
    [SerializeField]
    private GameObject sideSmallFire = null;

    [SerializeField]
    private GameObject bottomMediumFire = null;
    [SerializeField]
    private GameObject topMediumFire = null;
    [SerializeField]
    private GameObject sideMediumFire = null;

    [SerializeField]
    private GameObject bottomBigFire = null;
    [SerializeField]
    private GameObject topBigFire = null;
    [SerializeField]
    private GameObject sideBigFire = null;
}
