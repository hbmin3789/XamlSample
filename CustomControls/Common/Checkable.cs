using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Common
{
    /// <summary>
    /// 일반 모델을 체크 할 수 있게 만듬
    /// </summary>
    public class Checkable : BindableBase
    {
        protected bool _isChecked = false;
        public virtual bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
    }

    public class CheckableTreeBase : Checkable
    {
        protected ObservableCollection<CheckableTreeBase> _childItems = new ObservableCollection<CheckableTreeBase>();
        public virtual ObservableCollection<CheckableTreeBase> ChildItems
        {
            get => _childItems;
            set => SetProperty(ref _childItems, value);
        }

        public override bool IsChecked 
        {
            get
            {

                return _isChecked;
            }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }

        protected bool GetChildCheck()
        {
            if(ChildItems.Count == 0)
            {
                return false;
            }
            var checkedList = ChildItems.Where(x => x.IsChecked).ToList();
            if(checkedList.Count == 0)
            {
                return null;
            }
            return checkedList.Count == ChildItems.Count;
        }
    }
}
