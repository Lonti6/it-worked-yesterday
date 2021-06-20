using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchAll : MonoBehaviour
{
    private InputField _field;
    private Dictionary<string, P> dic = new Dictionary<string, P>();
    public GameObject visible;
    public Transform _group;
    public GameObject prefub;
    private List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        _field = GetComponent<InputField>();
        dic["запись к доктору врачу гинеколог дерматолог кардиолог невролог окулист ортопед терапевт хирург эндокринолог"] = new P("SendMessage", "Запись к врачу");
        dic["вход быстрая регистрация"] = new P("Enter", "Вход в приложение");
        dic["вопрос специалист чат со кашель беспокоит"] = new P("chats", "Чат со специалистом");
        dic["карта екатеринбург поиск гармония медцентр"] = new P("Maps", "Ближайшие больницы на карте \n Запить к врачу");
        dic["пациент карта результаты иследований просмотр данных пользователя название исследования"] = new P("MedCard", "Пациент");
        dic["пациент карта результаты иследований просмотр данных пользователя название исследования"] = new P("MedCard", "Результаты иследований");
        dic["пациент карта результаты иследований просмотр данных пользователя название исследования"] = new P("MedCard", "Просмотр данных пользователя");
        dic["новости путин вакцинация президент россии москве короновирус"] = new P("news", "Новости");
        dic["тесты температура чувствуете себя усталым/вялым испытываете ли вы приступы сухого кашля"] = new P("Tests", "Тестирование");
    }

    public void onChangeText()
    {
        visible.SetActive(_field.text.Length > 0);
        if (_field.text.Length <= 0)
            return;

        var set = new HashSet<P>();

        var strs = _field.text.ToLower().Split(' ');
        foreach (var str in strs)
        {
            if (str.Length > 0)
                foreach (var pair in dic)
                {
                    if (pair.Key.Contains(str))
                        set.Add(pair.Value);
                }
        }

        if (set.Count == 0)
            set.Add(new P());

        foreach (var o in objects)
        {
            Destroy(o);
        }

        objects.Clear();

        foreach (var p in set)
        {
            var obj = Instantiate(prefub, _group, false);
            objects.Add(obj);
            var scene = obj.GetComponent<LoadingScene>();
            scene.sceneName = p.scene;
            obj.GetComponentInChildren<Text>().text = p.view;
        }
    }

    class P
    {
        public string scene = "Main";
        public string view = "Нет совпадений...";

        public P(string scene, string view)
        {
            this.scene = scene;
            this.view = view;
        }

        public P()
        {
        }

        protected bool Equals(P other)
        {
            return scene == other.scene && view == other.view;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((P) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((scene != null ? scene.GetHashCode() : 0) * 397) ^ (view != null ? view.GetHashCode() : 0);
            }
        }
    }
}