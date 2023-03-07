using Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

//enum TEEStDELETE Создает перечисление, которое будет видно во всех скриптах
//{
//    wwwww,wwww
//}

class TEEStDELETE : MonoBehaviour
{
    private string _myName;
    private string myName;
    private int buf;

    public UnityEvent Event;


    [AddComponentMenu("Transform/Follow Transform")]
    public class FollowTransform : MonoBehaviour
    {
            
    }
    [ColorUsageAttribute(false)] public Color UI;

    [ContextMenuItem("Something", "DoSomething")]      // Возможность вызвать функцию из контекстного меню свойства
    [ContextMenuItem("Something2", "DoSomething1")]      // Возможность вызвать функцию из контекстного меню свойства другая функция
    public string NameValues;


    [ContextMenu("Do Something")]    // создает возможность вызвать функцию через контекстное меню (три точки) "Do Something" — имя функции, далее сама функция(и)
    void DoSomething()
    {
        Debug.Log("Perform operation");
    }
    void DoSomething1()
    {
        Debug.Log("Pefrofm operation else");
    }
    
        
}
