using UnityEngine;
using UniRx;

public class SerializedReactivePropertyExample : MonoBehaviour
{
    [SerializeField]
    IntReactiveProperty intProperty = new IntReactiveProperty(0);

    [SerializeField]
    LongReactiveProperty longProperty = new LongReactiveProperty(0L);

    [SerializeField]
    FloatReactiveProperty floatProperty = new FloatReactiveProperty(0.0F);

    [SerializeField]
    DoubleReactiveProperty doubleProperty = new DoubleReactiveProperty(0.0);

    [SerializeField]
    ByteReactiveProperty byteProperty = new ByteReactiveProperty(0);

    [SerializeField]
    BoolReactiveProperty boolProperty = new BoolReactiveProperty(false);

    [SerializeField]
    StringReactiveProperty stringProperty = new StringReactiveProperty("");

    [SerializeField]
    Vector2ReactiveProperty vector2Property = new Vector2ReactiveProperty(Vector2.zero);

    [SerializeField]
    Vector3ReactiveProperty vector3Property = new Vector3ReactiveProperty(Vector3.zero);

    [SerializeField]
    Vector4ReactiveProperty vector4Property = new Vector4ReactiveProperty(Vector4.zero);

    [SerializeField]
    QuaternionReactiveProperty quaternionProperty = new QuaternionReactiveProperty(Quaternion.identity);

    [SerializeField]
    ColorReactiveProperty colorProperty = new ColorReactiveProperty(Color.black);

    [SerializeField]
    BoundsReactiveProperty boundsProperty = new BoundsReactiveProperty(new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 100)));

    [SerializeField]
    AnimationCurveReactiveProperty animationCurveProperty = new AnimationCurveReactiveProperty(AnimationCurve.Linear(0.0F, 0.0F, 1.0F, 1.0F));

    void Start()
    {
        intProperty.Subscribe(it => Debug.Log(it));
        longProperty.Subscribe(it => Debug.Log(it));
        floatProperty.Subscribe(it => Debug.Log(it));
        doubleProperty.Subscribe(it => Debug.Log(it));
        byteProperty.Subscribe(it => Debug.Log(it));
        boolProperty.Subscribe(it => Debug.Log(it));
        stringProperty.Subscribe(it => Debug.Log(it));
        vector2Property.Subscribe(it => Debug.Log(it));
        vector3Property.Subscribe(it => Debug.Log(it));
        vector4Property.Subscribe(it => Debug.Log(it));
        quaternionProperty.Subscribe(it => Debug.Log(it));
        colorProperty.Subscribe(it => Debug.Log(it));
        boundsProperty.Subscribe(it => Debug.Log(it));
        animationCurveProperty.Subscribe(it => Debug.Log(it));
    }
}
