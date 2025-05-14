using UnityEngine;
public class SoundManager : MonoBehaviour
{
    void Start()
    {
        FakeSound sound1 = new FakeSound();
    }
}

public class FakeSound
{
    public FakeSound()
    {
        Debug.Log("Spiller en sang... SNYDT!!!");
    }
}
