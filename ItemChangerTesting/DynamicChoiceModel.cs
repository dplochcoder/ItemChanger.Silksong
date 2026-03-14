using Silksong.ModMenu.Elements;
using Silksong.ModMenu.Models;
using System.Collections.ObjectModel;

namespace ItemChangerTesting
{
    internal class DynamicChoiceModel : IChoiceModel<Test>
    {
        public DynamicChoiceModel()
        {
            groupCount = GetTestGroup().Count;
            if (Index < 0 || Index >= groupCount) Index = 0;
        }

        public Test Value
        {
            get
            {
                return GetTestGroup()[Index];
            }

            set
            {
                int before = Index;
                int after = GetTestGroup().IndexOf(value) is int i && i >= 0 ? i : throw new KeyNotFoundException(value.ToString());
                Index = after;
                if (before != after)
                {
                    OnValueChanged?.Invoke(Value);
                    OnRawValueChanged?.Invoke(Value);
                }
            }
        }
        private int Index
        {
            get => ItemChangerTestingPlugin.Instance.cfgTestIndex.Value;
            set
            {
                if (value < 0) value = groupCount - 1;
                else if (value >= groupCount) value = 0;

                int oldValue = Index;
                if (oldValue != value)
                {
                    ItemChangerTestingPlugin.Instance.cfgTestIndex.Value = value;
                    OnValueChanged?.Invoke(Value);
                    OnRawValueChanged?.Invoke(Value);
                }
            }
        }
        private int groupCount;

        public void UpdateFolder(object sender, EventArgs args)
        {
            groupCount = GetTestGroup().Count;
            Index = 0;
            OnValueChanged?.Invoke(Value);
            OnRawValueChanged?.Invoke(Value);
        }

        private ReadOnlyCollection<Test> GetTestGroup() => Test.TestGroups[ItemChangerTestingPlugin.Instance.cfgTestFolder.Value];

        public event Action<Test>? OnValueChanged;
        public event Action<object>? OnRawValueChanged;

        public LocalizedText DisplayString()
        {
            return Value.GetMetadata().MenuName;
        }

        public bool MoveLeft()
        {
            int i = Index;
            Index--;
            return i != Index;
        }

        public bool MoveRight()
        {
            int i = Index;
            Index++;
            return i != Index;
        }

        public Test GetValue() => Value;
        public bool SetValue(Test value)
        {
            try
            {
                Value = value;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
