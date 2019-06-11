using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    Animator anim;
    bool isFading = false;
    public Animator Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Healthbar.SetBool("HealthBarIsAppear", true);

    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        Healthbar.SetBool("HealthBarIsAppear", true);

        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        Healthbar.SetBool("HealthBarIsAppear", false);

        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }

}
