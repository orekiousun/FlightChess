using QxFramework.Core;

public class LogicModuleBase
{
    public virtual void Init()
    {
    }

    protected bool RegisterData<T>(out T data, string key = "Default") where T : GameDataBase, new()
    {
        return QXData.Instance.InitData<T>(out data, key);
    }

    protected void SetModify<T>(T data, string key = "Default") where T : GameDataBase, new()
    {
        QXData.Instance.SetModify<T>(data, this, key);
    }

    public virtual void Awake()
    {
    }

    public virtual void Update(float deltaTime)
    {
    }
    public virtual void LateUpdate(float deltaTime)
    {
    }

    public virtual void FixedUpdate(float fixedDeltaTime)
    {
    }

    public virtual void OnDestroy()
    {
    }
}