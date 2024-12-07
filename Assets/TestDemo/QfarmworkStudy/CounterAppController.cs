using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    //定义一个moder对象
    public class CounterAppModer : AbstractModel
    {
        public int Count;
        public int num;
        protected override void OnInit()
        {
            Count = 0;
            num = 0;
        }
    }

    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            // 注册Model
            this.RegisterModel(new CounterAppModer());
        }
    }


    // Controller
    public class CounterAppController : MonoBehaviour,IController
    {
        // View
        public Button mBtnAdd;
        public Button mBtnSub;
        public Text mCountText;

        // Model
        private CounterAppModer mModel;

        void Start()
        {
            mModel = this.GetModel<CounterAppModer>();
           
            // 监听输入
            mBtnAdd.onClick.AddListener(() =>
            {
                // 交互逻辑
                mModel.Count++;
                // 表现逻辑
                UpdateView();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                // 交互逻辑
                mModel.Count--;
                // 表现逻辑
                UpdateView();
            });

            UpdateView();
        }

        void UpdateView()
        {
            mCountText.text = mModel.Count.ToString();
        }

        //指定架构
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnDestroy()
        {
            mModel = null;
        }
    }
}