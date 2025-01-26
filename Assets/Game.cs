using UnityEngine;

public class Game : MonoBehaviour
{
    public MoveSet player;
    public Mixer mixer;
    public Transform camera;
    public Camera view;
    public Follower follow;
    public Generator gen;
    public GameObject buttonToDisabled;
    private Functions functions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        functions = GetComponent<Functions>();
        centerPos();
    }

    void centerPos()
    {
        follow.isFollow = false;
        camera.gameObject.transform.rotation = Quaternion.identity;
        camera.gameObject.transform.position = new Vector3(0, 9, -18);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        player.isMoving = true;
        follow.isFollow = true;
        gen.canSelectable = false;
        GetComponent<UIGestion>().closeMixer();
    }

    public void ModeView()
    {
        follow.isSlide = !follow.isSlide;
        gen.canSelectable = !gen.canSelectable;
        if (!follow.isSlide)
        {
            buttonToDisabled.SetActive(true);
            view.fieldOfView = 60f;
            centerPos();
        }
        else
        {
            buttonToDisabled.SetActive(false);
            (float x, float y) = scope();
            follow.maxWidth = x + 20f;
            follow.maxHeight = y + 10f;
            view.fieldOfView = 70f;
        }
    }

    (float, float) scope()
    {
        // trouver max Y
        float _y = 1f; float _x = 0;
        for (; _y > 0; _x += 0.5f)
        {
            _y = functions.RunDerived(_x);
        }
        float maxY = functions.RunAway(_x);

        //trouver max X
        _y = 1;
        for (_x = 0; _y > 0; _x += 0.5f)
        {
            _y = functions.RunAway(_x);
        }
        float maxX = _x;

        return (maxX, maxY);
    }

    public void ResetGame()
    {
        GetComponent<UIGestion>().showMixer();
        GetComponent<UIGestion>().closeResume();
        gen.canSelectable = true;
        player.ResetPlay();
        functions.ResetStack();
        mixer.ResetPlay();
        centerPos();
    }
}
